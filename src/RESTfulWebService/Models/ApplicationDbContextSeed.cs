using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulWebService.Models
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedDataAsync(ApplicationDbContext context)
        {
            if (!context.Products.Any() && !context.Suppliers.Any() && !context.Categories.Any())
            {
                List<Supplier> Suppliers = new()
                {
                    new Supplier { Name = "Splash Dudes", City = "San Jose" },
                    new Supplier { Name = "Soccer Town", City = "Chicago" },
                    new Supplier { Name = "Chess Co", City = "New York" }
                };

                List<Category> Categories = new()
                {
                    new Category { Name = "Watersports" },
                    new Category { Name = "Soccer" },
                    new Category { Name = "Chess" },
                };

                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Price = 275,
                        Category = Categories[1],
                        Supplier = Suppliers[0]
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Price = 48.95m,
                        Category = Categories[2],
                        Supplier = Suppliers[1]
                    },
                    new Product
                    {
                        Name = "Soccer Ball",
                        Price = 19.50m,
                        Category = Categories[0],
                        Supplier = Suppliers[2]
                    },
                    new Product
                    {
                        Name = "Corner Flags",
                        Price = 34.95m,
                        Category = Categories[0],
                        Supplier = Suppliers[0]
                    },
                    new Product
                    {
                        Name = "Stadium",
                        Price = 79500,
                        Category = Categories[1],
                        Supplier = Suppliers[2]
                    },
                    new Product
                    {
                        Name = "Thinking Cap",
                        Price = 16,
                        Category = Categories[1],
                        Supplier = Suppliers[0]
                    },
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Price = 29.95m,
                        Category = Categories[2],
                        Supplier = Suppliers[2]
                    },
                    new Product
                    {
                        Name = "Human Chess Board",
                        Price = 75,
                        Category = Categories[1],
                        Supplier = Suppliers[2]
                    },
                    new Product
                    {
                        Name = "Bling-Bling King",
                        Price = 1200,
                        Category = Categories[2],
                        Supplier = Suppliers[1]
                    });

                await context.SaveChangesAsync();
            }
        }
    }
}

