using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Linq;
using NorthDB.Models;
using NorthDB.Context;
using TechTalk.SpecFlow;
using Microsoft.Extensions.Options;

namespace NorthDB.Tests
{
    public class Config
    {
        //private readonly NorthStepDefinitions _stepDefinitions;
        public Config()
        {
            //_stepDefinitions = new NorthStepDefinitions();
        }
        public static void Main(string[] args)
        {
            ShowData();
            AddData();
            UpdateData();
            DeleteData();
        }

        public static void ShowData()
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

        public static void AddData()
        {
            using (NorthwindContext db = new NorthwindContext())
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
        }

        public static void UpdateData()
        {
            using (NorthwindContext db = new NorthwindContext())
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
        }

        public static void DeleteData()
        {
            using (NorthwindContext db = new NorthwindContext())
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
