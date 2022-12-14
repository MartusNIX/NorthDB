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
        public static async Task Main(string[] args)
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

                var categories = db.Categories.ToList();
                Console.WriteLine("Data after adding:");
                foreach (Category c in categories)
                {
                    Console.WriteLine($"{c.CategoryId}.{c.CategoryName}.{c.Description}");
                }
            }

            using (NorthwindContext db = new NorthwindContext(options))
            {
                Category category = db.Categories.ToList()[8];
                if (category != null)
                {
                    category.CategoryName = "Alcohol";
                    category.Description = "Wine, Cidre, Beer";
                    db.Categories.Update(category);
                    db.SaveChanges();
                }

                var categories = db.Categories.ToList();
                Console.WriteLine("Data after updating:");
                foreach (Category c in categories)
                {
                    Console.WriteLine($"{c.CategoryId}.{c.CategoryName}.{c.Description}");
                }
            }

            using (NorthwindContext db = new NorthwindContext(options))
            {
                Category category = db.Categories.ToList()[8];
                if (category != null)
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();
                }

                var categories = db.Categories.ToList();
                Console.WriteLine("Data after deleting:");
                foreach (Category c in categories)
                {
                    Console.WriteLine($"{c.CategoryId}.{c.CategoryName}.{c.Description}");
                }
            }

        }
    }
}