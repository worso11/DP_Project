namespace DP_Project
{
    public static class LoadBalancer
    {
        private static int counter = 0;
        
        public static DataBase GetBase()
        {
            return DbManager.DataBases[counter];
        }
    }
}