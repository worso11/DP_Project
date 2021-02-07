using System;
using System.Data.Entity;
using System.Net.Sockets;
using DP_Project.Migrations;

namespace DP_Project
{
    public class Class1
    {
        static void Main(string[] args)
        {
            var context = new ProjectDbContext();
            string action = "";
            while (action != "Wyjście")
            {
                Console.WriteLine("Podaj akcję:\n - Dodawanie\n - Usuwanie\n - Odczyt \n - Wyjście");
                action = Console.ReadLine();
                if (action == "Dodawanie")
                {
                    UpdateDB.Add(context);
                } else if (action == "Usuwanie")
                {
                    UpdateDB.Delete(context);
                }else if (action == "Odczyt")
                {
                    Console.WriteLine("Produkty:");
                    foreach (var product in context.Products) {Console.WriteLine(product.Name + " z kategorii " + product.Category);}
                }else if (action != "Wyjście")
                {
                    Console.WriteLine("Nie ma takiej komendy");
                }
            }

            System.Console.WriteLine("Koniec działania programu");
        }
    }
}