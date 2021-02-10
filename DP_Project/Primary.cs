using System;

namespace DP_Project
{
    // Klasa stanu bazy danych Primary
    public class Primary : State
    {
        public Primary(DataBase par) : base(par){}

        // Funkcja odczytu z bazy danych dla danego stanu
        public override void Read()
        {
            Console.Write("It should not have happened");
        }

        // Funkcja zapisu do bazy danych dla danego stanu
        public override void Write()
        {
            UpdateDb.Add(UpdateDb.Add(Parent));
        }

        // Funkcja usuwania z bazy danych dla danego stanu
        public override void Delete()
        {
            UpdateDb.Delete(UpdateDb.Delete(Parent));
        }

        // Funkcja wywołująca metodę Visitora dla danego stanu
        public override void AcceptVisitor()
        {
            Visitor.VisitPrimary(Parent);
        }
    }
}