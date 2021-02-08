using System;
using System.Linq;

namespace DP_Project
{
    public static class UpdateDb
    {
        public static Product Add(DataBase ctx)
        {
            Console.WriteLine("Podaj nazwę produktu: ");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj nazwę kategorii: ");
            string category = Console.ReadLine();
            Console.WriteLine("Czy produkt jest na przecenie? (T/N): ");
            string isDisc = Console.ReadLine();
            bool disc = false;
            while (isDisc != "T" && isDisc != "N")
            {
                Console.WriteLine("Niepoprawna odpowiedź, wpisz \"T\" lub \"N\":");
                isDisc = Console.ReadLine();
            }
            if (isDisc == "T")
            {
                disc = true;
            }
            ctx.Database.Initialize(true);
            var product = new Product()
            {
                Name = name,
                Category = category,
                Discontinued = disc
            };
            ctx.Products.Add(product);
            ctx.SaveChanges();
            ctx.Version += 1;

            return product;
        }

        public static void Add(Product product)
        {
            foreach (var dataBase in DbManager.DataBases.Where(dataBase => dataBase != DbManager.Primary))
            {
                dataBase.Products.Add(product);
                dataBase.SaveChanges();
                dataBase.Version += 1;
            }
        }

        public static Product Delete(DataBase ctx)
        {
            Console.WriteLine("Podaj id produktu do usunięcia: ");
            string inputId = Console.ReadLine();
            int id;
            while(!Int32.TryParse(inputId, out id))
            {
                Console.WriteLine("Niepoprawna odpowiedź, wpisz liczbę:");
                inputId = Console.ReadLine();
            }
            
            ctx.Database.Initialize(true);
            var product = new Product()
            {
                Id = id
            };
            
            ctx.Products.Attach(product);
            ctx.Products.Remove(product);
            ctx.SaveChanges();
            ctx.Version += 1;

            return product;
        }
        
        public static void Delete(Product product)
        {
            foreach (var dataBase in DbManager.DataBases.Where(dataBase => dataBase != DbManager.Primary))
            {
                dataBase.Products.Attach(product);
                dataBase.Products.Remove(product);
                dataBase.SaveChanges();
                dataBase.Version += 1;
            }
        }
    }
}