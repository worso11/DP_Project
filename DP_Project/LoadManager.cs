using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace DP_Project
{
    public static class LoadManager
    {
        static void Main()
        {
            DbManager.DataBases = new List<DataBase>();
            
            for (var i = 0; i < 6; i++)
            {
                DataBase db = new DataBase("mssql" + i);
                DbManager.DataBases.Add(db);
                if (!db.Database.Exists())
                {
                    db.IsActive = false;
                }
                Console.WriteLine("mssql" + i +":" + db.Database.Exists());
            }
            
            DbManager.SetPrimary();
            var action = "";
            Thread visiting = new Thread(new ThreadStart(WatchDog.Check));
            visiting.Start();
            while (action != "Wyjście")
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Podaj akcję:\n - Dodawanie\n - Usuwanie\n - Odczyt \n - Wyjście");
                Console.WriteLine("--------------------");
                action = Console.ReadLine();
                Console.Clear();
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
                    case "Wyjście":
                        Console.WriteLine("Koniec działania programu");
                        visiting.Abort();
                        return;
                    default:
                    {
                        Console.WriteLine("Nie ma takiej komendy");
                        break;
                    }
                }
            }
        }
    }
}