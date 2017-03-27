namespace BabyStore.Migrations.StoreConfiguration
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    internal sealed class StoreConfiguration : DbMigrationsConfiguration<BabyStore.DAL.StoreContext>
    {
        public StoreConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BabyStore.DAL.StoreContext context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Clothes" },
                new Category { Name = "Play and Toys" },
                new Category { Name = "Feeding" },
                new Category { Name = "Medicine" },
                new Category { Name= "Travel" },
                new Category { Name= "Sleeping" }
            };
            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product { Name = "Sleep Suit", Description="For sleeping or general wear",Price=4.99M, CategoryID=categories.Single( c => c.Name == "Clothes").ID },
                new Product { Name = "Vest", Description="For sleeping or general wear", Price=2.99M, CategoryID=categories.Single( c => c.Name == "Clothes").ID },
                new Product { Name = "Orange and Yellow Lion", Description="Makes a squeaking noise", Price=1.99M, CategoryID=categories.Single( c => c.Name =="Play and Toys").ID  },
                new Product { Name = "Blue Rabbit", Description="Baby comforter", Price=2.99M, CategoryID=categories.Single( c => c.Name == "Play and Toys").ID },
                new Product { Name = "3 Pack of Bottles", Description="For a leak free drink everytime", Price=24.99M, CategoryID=categories.Single( c => c.Name == "Feeding").ID },
                new Product { Name = "3 Pack of Bibs", Description="Keep your baby dry when feeding", Price=8.99M, CategoryID=categories.Single( c => c.Name == "Feeding").ID  },
                new Product { Name = "Powdered Baby Milk", Description="Nutritional and Tasty", Price=9.99M, CategoryID=categories.Single( c => c.Name == "Feeding").ID  },
                new Product { Name = "Pack of 70 Disposable Nappies", Description="Dry and secure nappies with snug fit", Price=19.99M, CategoryID=categories.Single( c => c.Name == "Feeding").ID  },
                new Product { Name = "Colic Medicine", Description="For helping with baby colic pains", Price=4.99M, CategoryID=categories.Single( c => c.Name == "Medicine").ID  },
                new Product { Name = "Reflux Medicine", Description="Helps to prevent milk regurgitation and sickness", Price=4.99M, CategoryID=categories.Single( c => c.Name == "Medicine").ID  },
                new Product { Name = "Black Pram and Pushchair System", Description="Convert from pram to pushchair, with raincover", Price=299.99M, CategoryID=categories.Single( c => c.Name == "Travel").ID  },
                new Product { Name = "Car Seat", Description="For safe car travel", Price=49.99M, CategoryID= categories.Single( c => c.Name == "Travel").ID  },
                new Product { Name = "Moses Basket", Description="Plastic moses basket", Price=75.99M, CategoryID=categories.Single( c => c.Name == "Sleeping").ID  },
                new Product { Name = "Crib", Description="Wooden crib", Price=35.99M, CategoryID= categories.Single( c => c.Name == "Sleeping").ID  },
                new Product { Name = "Cot Bed", Description="Converts from cot into bed for older children", Price=149.99M, CategoryID=categories.Single( c => c.Name == "Sleeping").ID  },
                new Product { Name = "Circus Crib Bale", Description="Contains sheet, duvet and bumper", Price=29.99M, CategoryID=categories.Single( c => c.Name == "Sleeping").ID  },
                new Product { Name = "Loved Crib Bale", Description="Contains sheet, duvet and bumper", Price=35.99M, CategoryID=categories.Single( c => c.Name == "Sleeping").ID  }
            };

            products.ForEach(c => context.Products.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var images = new List<ProductImage>
            {
                new ProductImage { FileName="SleepSuit1.JPG" },
                new ProductImage { FileName="SleepSuit2.JPG" },
                new ProductImage { FileName="Vest1.JPG" },
                new ProductImage { FileName="Vest2.JPG" },
                new ProductImage { FileName="Lion1.JPG" },
                new ProductImage { FileName="Rabbit1.JPG" },
                new ProductImage { FileName="Bottles1.JPG" },
                new ProductImage { FileName="Bottles2.JPG" },
                new ProductImage { FileName="Bottles3.JPG" },
                new ProductImage { FileName="Bibs1.JPG" },
                new ProductImage { FileName="Bibs2.JPG" },
                new ProductImage { FileName="Milk1.JPG" },
                new ProductImage { FileName="Nappies1.JPG" },
                new ProductImage { FileName="Nappies2.JPG" },
                new ProductImage { FileName="Nappies3.JPG" },
                new ProductImage { FileName="ColicMedicine1.JPG" },
                new ProductImage { FileName="Reflux1.JPG" },
                new ProductImage { FileName="Pram1.JPG" },
                new ProductImage { FileName="Pram2.JPG" },
                new ProductImage { FileName="Pram3.JPG" },
                new ProductImage { FileName="CarSeat1.JPG" },
                new ProductImage { FileName="CarSeat2.JPG" },
                new ProductImage { FileName="Moses1.JPG" },
                new ProductImage { FileName="Moses2.JPG" },
                new ProductImage { FileName="Crib1.JPG" },
                new ProductImage { FileName="Crib2.JPG" },
                new ProductImage { FileName="Bed1.JPG" },
                new ProductImage { FileName="Bed2.JPG" },
                new ProductImage { FileName="CircusBale1.JPG" },
                new ProductImage { FileName="CircusBale2.JPG" },
                new ProductImage { FileName="CircusBale3.JPG" },
                new ProductImage { FileName="LovedBale1.JPG" },
            };

            images.ForEach(c => context.ProductImages.AddOrUpdate(p => p.FileName, c));
            context.SaveChanges();

            var imageMappings = new List<ProductImageMapping>
            {
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "SleepSuit1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Sleep Suit").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "SleepSuit2.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Sleep Suit").ID, ImageNumber = 1 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Vest1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Vest").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Vest2.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Vest").ID, ImageNumber = 1 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Lion1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Orange and Yellow Lion").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Rabbit1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Blue Rabbit").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Bottles1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "3 Pack of Bottles").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Bottles2.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "3 Pack of Bottles").ID, ImageNumber = 1 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Bottles3.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "3 Pack of Bottles").ID, ImageNumber = 2 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Bibs1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "3 Pack of Bibs").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Bibs2.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "3 Pack of Bibs").ID, ImageNumber = 1 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Milk1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Powdered Baby Milk").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Nappies1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Pack of 70 Disposable Nappies").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Nappies2.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Pack of 70 Disposable Nappies").ID, ImageNumber = 1 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Nappies3.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Pack of 70 Disposable Nappies").ID, ImageNumber = 2 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "ColicMedicine1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Colic Medicine").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Reflux1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Reflux Medicine").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Pram1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Black Pram and Pushchair System").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Pram2.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Black Pram and Pushchair System").ID, ImageNumber = 1 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Pram3.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Black Pram and Pushchair System").ID, ImageNumber = 2 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "CarSeat1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Car Seat").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "CarSeat2.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Car Seat").ID, ImageNumber = 1 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Moses1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Moses Basket").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Moses2.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Moses Basket").ID, ImageNumber = 1 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Crib1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Crib").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Crib2.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Crib").ID, ImageNumber = 1 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Bed1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Cot Bed").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "Bed2.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Cot Bed").ID, ImageNumber = 1 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "CircusBale1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Circus Crib Bale").ID, ImageNumber = 0 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "CircusBale2.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Circus Crib Bale").ID, ImageNumber = 1 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "CircusBale3.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Circus Crib Bale").ID, ImageNumber = 2 },
                new ProductImageMapping { ProductImageID= images.Single(i => i.FileName == "LovedBale1.JPG").ID,
                    ProductID = products.Single( c=> c.Name == "Loved Crib Bale").ID, ImageNumber = 0 },
            };

            imageMappings.ForEach(c => context.ProductImageMappings.AddOrUpdate(im => im.ProductImageID, c));
            context.SaveChanges();

        }
    }
}
