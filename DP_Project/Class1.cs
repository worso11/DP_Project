using System.Data.Entity;
using DP_Project.Migrations;

namespace DP_Project
{
    public class Class1
    {
        static void Main(string[] args)
        {
            var context = new ProjectDbContext();
            context.Database.Initialize(true);
            var product = new Product()
            {
                Name = "Zeszyt",
                Category = "Szkoła",
                Discontinued = false
            };
            //context.Products.Attach(product);
            //context.Products.Remove(product);
            context.Products.Add(product);
            context.SaveChanges();
            
            System.Console.WriteLine("Hello World!");
        }
    }
}