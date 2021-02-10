using System;
using System.Collections.Generic;
using System.Linq;

namespace DP_Project
{
    // Klasa zarządzająca bazami danych
    public static class DbManager
    {
        public static DataBase Primary;
        public static List<DataBase> DataBases;

        // Funkcja ustawiająca bazę danych na stan Primary
        public static void SetPrimary()
        {
            Primary = null;
            while (Primary == null)
            {
                Console.WriteLine("### Searching for primary... ###");
                foreach (var dataBase in DataBases.Where(dataBase => dataBase.IsActive))
                {
                    Primary = dataBase;
                    Primary.ChangeState(new Primary(Primary));
                    Console.WriteLine("### Baza " + dataBase.name + " przechodzi w stan Primary ###");
                    break;
                }
            }
        }
    }
}