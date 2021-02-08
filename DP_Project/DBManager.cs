using System;
using System.Collections.Generic;

namespace DP_Project
{
    public static class DbManager
    {
        private static DataBase Primary;
        public static List<DataBase> DataBases;

        public static void SetPrimary()
        {
            while (Primary == null)
            {
                Console.WriteLine("Searching for primary...");
                foreach (var dataBase in DataBases)
                {
                    if (dataBase.IsActive)
                    {
                        Primary = dataBase;
                        Primary.ChangeState(new Primary(Primary));
                        break;
                    }
                }
            }
        }
    }
}