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
            if (dataBase.IsActive) return;
            
            Console.WriteLine("### Baza " + dataBase.name + " przechodzi w stan Inactive###");
            dataBase.State = new Inactive(dataBase);
            DbManager.SetPrimary();
        }
        
        public static void VisitSecondary(DataBase dataBase)
        {
            if (dataBase.IsActive) return;
            
            Console.WriteLine("### Baza " + dataBase.name + " przechodzi w stan Inactive###");
            dataBase.State = new Inactive(dataBase);
        }
        
        public static void VisitInactive(DataBase dataBase)
        {
            if (!dataBase.IsActive) return;
            
            Console.WriteLine("### Baza " + dataBase.name + " przechodzi w stan Secondary###");
            dataBase.State = new Secondary(dataBase);
        }
    }
}