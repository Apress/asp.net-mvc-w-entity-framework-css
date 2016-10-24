using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BabyStoreCore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<StoreContext>();

            if (context.Database == null)
            {
                throw new Exception("DB is null");
            }

            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var feeding = context.Categories.Add(new Category { Name = "Feeding" }).Entity;
            var sleeping = context.Categories.Add(new Category { Name = "Sleeping" }).Entity;

            context.Products.AddRange(
                new Product
                {
                    Name = "Milk",
                    Description = "Tasty anti-reflux milk",
                    Price = 9.99M,
                    Category = feeding
                },
                new Product
                {
                    Name = "SleepSuit",
                    Description = "Comfortable sleep wear",
                    Price = 3.99M,
                    Category = sleeping
                }
             );

            context.SaveChanges();
        }
    }
}
