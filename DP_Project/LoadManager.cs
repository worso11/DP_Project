using System;
using System.Collections.Generic;

namespace DP_Project
{
    public static class LoadManager
    {
        static void Main(string[] args)
        {
            DbManager.DataBases = new List<DataBase>();
            
            for (var i = 0; i < 2; i++)
            {
                DbManager.DataBases.Add(new DataBase("mssql" + i));
            }
            DbManager.SetPrimary();

            var context = DbManager.DataBases[0];
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

            Console.WriteLine("Koniec działania programu");
        }
    }
}