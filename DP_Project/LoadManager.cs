using System;
using System.Collections.Generic;

namespace DP_Project
{
    public static class LoadManager
    {
        static void Main()
        {
            DbManager.DataBases = new List<DataBase>();
            
            for (var i = 0; i < 2; i++)
            {
                DbManager.DataBases.Add(new DataBase("mssql" + i));
            }
            DbManager.SetPrimary();

            var action = "";
            while (action != "Wyjście")
            {
                Visitor.Visit();
                Console.WriteLine("Podaj akcję:\n - Dodawanie\n - Usuwanie\n - Odczyt \n - Wyjście");
                action = Console.ReadLine();
                
                switch (action)
                {
                    case "Dodawanie":
                        DbManager.Primary.Write();
                        break;
                    case "Usuwanie":
                        DbManager.Primary.Delete();
                        break;
                    case "Odczyt":
                        LoadBalancer.GetBase().Read();
                        break;
                    default:
                    {
                        if (action != "Wyjście")
                        {
                            Console.WriteLine("Nie ma takiej komendy");
                        }

                        break;
                    }
                }
            }
            Console.WriteLine("Koniec działania programu");
        }
    }
}