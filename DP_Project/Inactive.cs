using System;

namespace DP_Project
{
    // Klasa stanu bazy danych Inactive
    public class Inactive : State
    {
        public Inactive(DataBase par) : base(par){}

        // Funkcja odczytu z bazy danych dla danego stanu
        public override void Read()
        {
            Console.Write("It should not have happened");
        }

        // Funkcja zapisu do bazy danych dla danego stanu
        public override void Write()
        {
            Console.Write("It should not have happened");
        }

        // Funkcja usuwania z bazy danych dla danego stanu
        public override void Delete()
        {
            Console.Write("It should not have happened");
        }

        // Funkcja wywołująca metodę Visitora dla danego stanu
        public override void AcceptVisitor()
        {
            Visitor.VisitInactive(Parent);
        }
    }
}