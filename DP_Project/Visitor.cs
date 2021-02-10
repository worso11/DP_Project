using System;

namespace DP_Project
{
    // Klasa implementująca wzorzec Visitor
    public static class Visitor
    {
        // Funkcja wywołująca Visitora dla każdej bazy danych
        public static void Visit()
        {
            foreach (var dataBase in DbManager.DataBases)
            {
                dataBase.AcceptVisitor();
            }
        }
        
        // Funkcja Visitora dla bazy danych w stanie Primary
        public static void VisitPrimary(DataBase dataBase)
        {
            if (!dataBase.Database.Exists()) { dataBase.IsActive = false; }
            if (dataBase.IsActive) return;
            
            Console.WriteLine("### Baza " + dataBase.name + " przechodzi w stan Inactive ###");
            dataBase.ChangeState(new Inactive(dataBase));
            DbManager.SetPrimary();
        }
        
        // Funkcja Visitora dla bazy danych w stanie Secondary
        public static void VisitSecondary(DataBase dataBase)
        {
            if (!dataBase.Database.Exists()) { dataBase.IsActive = false; }
            if (dataBase.IsActive) return;
            
            Console.WriteLine("### Baza " + dataBase.name + " przechodzi w stan Inactive ###");
            dataBase.ChangeState(new Inactive(dataBase));
        }
        
        // Funkcja Visitora dla bazy danych w stanie Inactive
        public static void VisitInactive(DataBase dataBase)
        {
            // Zakomentowane ze względu na symulację rozłączenia bazy danych
            if (dataBase.Database.Exists()) { dataBase.IsActive = true; }
            if (!dataBase.IsActive) return;

            dataBase.Unit.UpdateFromQueue(dataBase);
            Console.WriteLine("### Baza " + dataBase.name + " przechodzi w stan Secondary ###");
            dataBase.ChangeState(new Secondary(dataBase));
        }
    }
}