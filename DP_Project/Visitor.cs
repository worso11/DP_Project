using System;

namespace DP_Project
{
    public static class Visitor
    {
        public static void Visit()
        {
            foreach (var dataBase in DbManager.DataBases)
            {
                dataBase.AcceptVisitor();
            }
        }
        public static void VisitPrimary(DataBase dataBase)
        {
            if (!dataBase.Database.Exists()) { dataBase.IsActive = false; }
            if (dataBase.IsActive) return;
            Console.WriteLine("### Baza " + dataBase.name + " przechodzi w stan Inactive ###");
            dataBase.State = new Inactive(dataBase);
            DbManager.SetPrimary();
        }
        
        public static void VisitSecondary(DataBase dataBase)
        {
            if (!dataBase.Database.Exists()) { dataBase.IsActive = false; }
            if (dataBase.IsActive) return;
            
            Console.WriteLine("### Baza " + dataBase.name + " przechodzi w stan Inactive ###");
            dataBase.State = new Inactive(dataBase);
        }
        
        public static void VisitInactive(DataBase dataBase)
        {
            // Zakomentowane ze względu na symulację rozłączenia bazy danych
            //if (dataBase.Database.Exists()) { dataBase.IsActive = true; }
            if (!dataBase.IsActive) return;

            dataBase.Unit.UpdateFromQueue(dataBase);
            Console.WriteLine("### Baza " + dataBase.name + " przechodzi w stan Secondary ###");
            dataBase.State = new Secondary(dataBase);
        }
    }
}