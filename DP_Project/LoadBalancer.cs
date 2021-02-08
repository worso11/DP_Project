namespace DP_Project
{
    public static class LoadBalancer
    {
        private static int _counter = 0;
        
        public static DataBase GetBase()
        {
            while (true)
            {
                IncrementCounter();
                if (DbManager.DataBases[_counter].State.GetType() == typeof(Secondary)) break;
            }
            return DbManager.DataBases[_counter];
        }

        private static void IncrementCounter()
        {
            _counter++;
            if (_counter >= DbManager.DataBases.Count) _counter = 0;
        }
    }
}