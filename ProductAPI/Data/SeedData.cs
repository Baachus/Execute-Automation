using System.Collections.Generic;
using System.Linq;

namespace ProductAPI.Data
{
    public static class SeedData
    {
        public static void Seed(this ProductDbContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>()
                {
                    new Product()
                    {
                        Name = "Keyboard",
                        Description = "Gaming Keybaord with lights",
                        Price = 150,
                        ProductType = ProductType.PERIPHARALS
                    },
                    new Product()
                    {
                        Name = "Mouse",
                        Description = "Gaming Mouse",
                        Price = 40,
                        ProductType = ProductType.PERIPHARALS
                    },
                    new Product()
                    {
                        Name = "Monitor",
                        Description = "HD Monitor",
                        Price = 400,
                        ProductType = ProductType.MONITOR
                    },
                    new Product()
                    {
                        Name = "Cabinet",
                        Description = "Business Cabinet with lights",
                        Price = 60,
                        ProductType = ProductType.EXTERNAL
                    }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}