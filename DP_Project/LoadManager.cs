using System;
using System.Collections.Generic;

namespace DP_Project
{
    public static class LoadManager
    {
        static void Main()
        {
            DbManager.DataBases = new List<DataBase>();
            
            for (var i = 0; i < 5; i++)
            {
                DataBase db = new DataBase("mssql" + i);
                DbManager.DataBases.Add(db);
                if (!db.Database.Exists())
                {
                    db.IsActive = false;
                }
                Console.WriteLine("mssql" + i +":" + db.Database.Exists());
            }

            int k = 0;
            DbManager.SetPrimary();
            var action = "";
            DbManager.DataBases[0].IsActive = false;
            while (action != "Wyjście")
            {
                Visitor.Visit();
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
                    default:
                    {
                        if (action != "Wyjście")
                        {
                            Console.WriteLine("Nie ma takiej komendy");
                        }

                        break;
                    }
                }

                if (k == 2)
                {
                    DbManager.DataBases[0].IsActive = true;
                }

                k += 1;
            }
            Console.WriteLine("Koniec działania programu");
        }
    }
}