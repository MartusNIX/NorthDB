using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Linq;
using NorthDB.Models;
using NorthDB.Context;

namespace NorthDB.Tests
{
    class Config
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<NorthwindContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;


            using (NorthwindContext db = new NorthwindContext(options))
            {
                var categories = db.Categories.ToList();
                Console.WriteLine("Current data:");
                foreach (Category c in categories)
                {
                    Console.WriteLine($"{c.CategoryId}.{c.CategoryName}.{c.Description}");
                }
            }

            using (NorthwindContext db = new NorthwindContext(options))
            {
                Category category1 = new Category
                {
                    CategoryName = "Drinks",
                    Description = "Water, Juice, Cidre"
                };

                db.Categories.Add(category1);
                db.SaveChanges();
            }

            using (NorthwindContext db = new NorthwindContext(options))
            {
                var categories = db.Categories.ToList();
                Console.WriteLine("Current data:");
                foreach (Category c in categories)
                {
                    Console.WriteLine($"{c.CategoryId}.{c.CategoryName}.{c.Description}");
                }
            }
        }
    }
}