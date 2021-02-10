namespace DP_Project
{
    // Klasa implementująca Load Balancer
    public static class LoadBalancer
    {
        private static int _roundRobinIndex;
        
        // Funkcja bazująca na algorytmie Round Robin, dobiera bazę danych do odczytu
        public static DataBase GetBase()
        {
            while (true)
            {
                IncrementCounter();
                if (DbManager.DataBases[_roundRobinIndex].State.GetType() == typeof(Secondary)) break;
            }
            return DbManager.DataBases[_roundRobinIndex];
        }

        // Funkcja inkrementująca licznik
        private static void IncrementCounter()
        {
            _roundRobinIndex++;
            if (_roundRobinIndex >= DbManager.DataBases.Count) _roundRobinIndex = 0;
        }
    }
}