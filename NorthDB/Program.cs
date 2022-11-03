using System;
using System.Linq;

namespace NorthDB
{
    class Program
    {
        static void Main(string[] args)
        { 
            using (NorthwindContext db = new NorthwindContext())
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