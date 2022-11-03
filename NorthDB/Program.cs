using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using NorthDB;
using System.Linq;

namespace NorthDB
{
    class Program
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
            Console.Read();
        }
    }
}