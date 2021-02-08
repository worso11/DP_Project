namespace DP_Project
{
    public static class LoadBalancer
    {
        private static int _roundRobinIndex;
        
        public static DataBase GetBase()
        {
            while (true)
            {
                IncrementCounter();
                if (DbManager.DataBases[_roundRobinIndex].State.GetType() == typeof(Secondary)) break;
            }
            return DbManager.DataBases[_roundRobinIndex];
        }

        private static void IncrementCounter()
        {
            _roundRobinIndex++;
            if (_roundRobinIndex >= DbManager.DataBases.Count) _roundRobinIndex = 0;
        }
    }
}