using BabyStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabyStore.Models
{
    public class Basket
    {
        private string BasketID { get; set; }
        private const string BasketSessionKey = "BasketID";
        private StoreContext db = new StoreContext();

        private string GetBasketID()
        {
            if (HttpContext.Current.Session[BasketSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[BasketSessionKey] =
                 HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid tempBasketID = Guid.NewGuid();
                    HttpContext.Current.Session[BasketSessionKey] = tempBasketID.ToString();
                }
            }
            return HttpContext.Current.Session[BasketSessionKey].ToString();
        }

        public static Basket GetBasket()
        {
            Basket basket = new Basket();
            basket.BasketID = basket.GetBasketID();
            return basket;
        }

        public void AddToBasket(int productID, int quantity)
        {
            var basketLine = db.BasketLines.FirstOrDefault(b => b.BasketID == BasketID && b.ProductID
             == productID);

            if (basketLine == null)
            {
                basketLine = new BasketLine
                {
                    ProductID = productID,
                    BasketID = BasketID,
                    Quantity = quantity,
                    DateCreated = DateTime.Now
                };
                db.BasketLines.Add(basketLine);
            }
            else
            {
                basketLine.Quantity += quantity;
            }
            db.SaveChanges();
        }

        public void RemoveLine(int productID)
        {
            var basketLine = db.BasketLines.FirstOrDefault(b => b.BasketID == BasketID && b.ProductID
             == productID);
            if (basketLine != null)
            {
                db.BasketLines.Remove(basketLine);
            }
            db.SaveChanges();
        }

        public void UpdateBasket(List<BasketLine> lines)
        {
            foreach (var line in lines)
            {
                var basketLine = db.BasketLines.FirstOrDefault(b => b.BasketID == BasketID &&
                 b.ProductID == line.ProductID);
                if (basketLine != null)
                {
                    if (line.Quantity == 0)
                    {
                        RemoveLine(line.ProductID);
                    }
                    else
                    {
                        basketLine.Quantity = line.Quantity;
                    }
                }
            }
            db.SaveChanges();
        }

        public void EmptyBasket()
        {
            var basketLines = db.BasketLines.Where(b => b.BasketID == BasketID);
            foreach (var basketLine in basketLines)
            {
                db.BasketLines.Remove(basketLine);
            }
            db.SaveChanges();
        }

        public List<BasketLine> GetBasketLines()
        {
            return db.BasketLines.Where(b => b.BasketID == BasketID).ToList();
        }

        public decimal GetTotalCost()
        {
            decimal basketTotal = decimal.Zero;

            if (GetBasketLines().Count > 0)
            {
                basketTotal = db.BasketLines.Where(b => b.BasketID == BasketID).Sum(b => b.Product.Price
                 * b.Quantity);
            }

            return basketTotal;
        }

        public int GetNumberOfItems()
        {
            int numberOfItems = 0;
            if (GetBasketLines().Count > 0)
            {
                numberOfItems = db.BasketLines.Where(b => b.BasketID == BasketID).Sum(b => b.Quantity);
            }

            return numberOfItems;
        }

        public void MigrateBasket(string userName)
        {
            //find the current basket and store it in memory using ToList()
            var basket = db.BasketLines.Where(b => b.BasketID == BasketID).ToList();

            //find if the user already has a basket or not and store it in memory using ToList()
            var usersBasket = db.BasketLines.Where(b => b.BasketID == userName).ToList();

            //if the user has a basket then add the current items to it
            if (usersBasket != null)
            {
                //set the basketID to the username
                string prevID = BasketID;
                BasketID = userName;
                //add the lines in anonymous basket to the user's basket
                foreach (var line in basket)
                {
                    AddToBasket(line.ProductID, line.Quantity);
                }
                //delete the lines in the anonymous basket from the database
                BasketID = prevID;
                EmptyBasket();
            }
            else
            {
                //if the user does not have a basket then just migrate this one
                foreach (var basketLine in basket)
                {
                    basketLine.BasketID = userName;
                }

                db.SaveChanges();
            }
            HttpContext.Current.Session[BasketSessionKey] = userName;
        }

        public decimal CreateOrderLines(int orderID)
        {
            decimal orderTotal = 0;

            var basketLines = GetBasketLines();

            foreach (var item in basketLines)
            {
                OrderLine orderLine = new OrderLine
                {
                    Product = item.Product,
                    ProductID = item.ProductID,
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.Product.Price,
                    OrderID = orderID
                };

                orderTotal += (item.Quantity * item.Product.Price);
                db.OrderLines.Add(orderLine);
            }

            db.SaveChanges();
            EmptyBasket();
            return orderTotal;
        }
    }
}
