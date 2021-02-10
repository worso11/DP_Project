using System;

namespace DP_Project
{
    // Klasa stanu bazy danych Secondary
    public class Secondary : State
    {
        public Secondary(DataBase par) : base(par){}
        
        // Funkcja odczytu z bazy danych dla danego stanu
        public override void Read()
        {
            if (Parent.Version == DbManager.Primary.Version)
            {
                Console.WriteLine("### Odczyt z bazy " + Parent.name + " ###");
                Console.WriteLine("Products:");
                foreach (var product in Parent.Products)
                {
                    Console.WriteLine(product.Name + " z kategorii " + product.Category);
                }
            }
            else
            {
                LoadBalancer.GetBase().Read();
            }
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
            Visitor.VisitSecondary(Parent);
        }
    }
}