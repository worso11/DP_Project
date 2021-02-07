using System;

namespace DP_Project
{
    public class UpdateDB
    {
        public static void Add(DataBase ctx)
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
        }

        public static void Delete(DataBase ctx)
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
        }
    }
}