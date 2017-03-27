using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BabyStore.DAL;
using BabyStore.ViewModels;
using System.Threading.Tasks;
using System.Data.Entity;



namespace BabyStore.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();

        public async Task<ActionResult> Index()
        {
            var topSellers = (from topProducts in db.OrderLines
                              where (topProducts.ProductID != null)
                              group topProducts by topProducts.Product into topGroup
                              select new BestSellersViewModel
                              {
                                  Product = topGroup.Key,
                                  SalesCount = topGroup.Sum(o => o.Quantity),
                                  ProductImage = topGroup.Key.ProductImageMappings.OrderBy(pim => pim.ImageNumber).FirstOrDefault().ProductImage.FileName
                              }).OrderByDescending(tg => tg.SalesCount).Take(4);

            return View(await topSellers.ToListAsync());
        }

        public ActionResult About(string id)
        {
            ViewBag.Message = "Your application description page. You entered the ID " + id;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}