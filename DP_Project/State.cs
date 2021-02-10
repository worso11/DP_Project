namespace DP_Project
{
    // Abstrakcyjna klasa implementująca wzorzec State
    public abstract class State
    {
        protected readonly DataBase Parent;

        protected State(DataBase par)
        {
            Parent = par;
        }
        
        // Abstrakcyjna funkcja odpowiedzialna za odczyt z bazy danych
        public abstract void Read();
        
        // Abstrakcyjna funkcja odpowiedzialna za wczytywanie do bazy danych
        public abstract void Write();
        
        // Abstrakcyjna funkcja odpowiedzialna za usuwanie z bazy danych
        public abstract void Delete();

        // Abstrakcyjna funkcja odpowiedzialna za wywołanie Visitora dla bazy danych
        public abstract void AcceptVisitor();

    }
}