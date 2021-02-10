using System;
using System.Collections.Generic;
using System.Linq;

namespace DP_Project
{
    // Klasa implementująca wzorzec Unit of Work
    public class UnitOfWork
    {
        // Kolejka zawierająca informacje o nieprzeprowadzonych uaktualnieniach
        private Queue<Tuple<Product,int>> myQ = new Queue<Tuple<Product,int>>();

        // Funkcja dodawania do kolejki
        public void AddToQueue(Tuple<Product,int> product)
        {
            myQ.Enqueue(product);
        }

        // Funkcja aktualizująca bazę danych na podstawie informacji z kolejki
        public void UpdateFromQueue(DataBase db)
        {
            Console.WriteLine("### UnitOfWork: Uaktualnianie bazy " + db.name + " do wersji " + DbManager.Primary.Version + " (Wersja: " + db.Version + ") ###");
            while (myQ.Count != 0)
            {
                Tuple<Product,int> product = myQ.Dequeue();
                if (product.Item2 == 0)
                {
                    db.Database.Initialize(true);
                    db.Products.Add(product.Item1);
                    db.SaveChanges();
                    db.Version += 1;
                }
                else
                {
                    db.Database.Initialize(true);
                    var prod = db.Products.Find(product.Item2);
                    db.Products.Attach(prod);
                    db.Products.Remove(prod);
                    db.SaveChanges();
                    db.Version += 1;
                }
            }
            Console.WriteLine("### UnitOfWork: Zaktualizowano bazę " + db.name + " do wersji " + db.Version + " ###");
        }
    }
}