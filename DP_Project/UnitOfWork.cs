using System;
using System.Collections.Generic;
using System.Linq;

namespace DP_Project
{
    public class UnitOfWork
    {
        private Queue<Tuple<Product,int>> myQ = new Queue<Tuple<Product,int>>();

        public void AddToQueue(Tuple<Product,int> product)
        {
            myQ.Enqueue(product);
        }

        public void UpdateFromQueue(DataBase db)
        {
            Console.WriteLine("### UnitOfWork: Uaktualnianie bazy " + db.name + " (Wersja: " + db.Version + ") ###");
            while (myQ.Count != 0)
            {
                Tuple<Product,int> product = myQ.Dequeue();
                if (product.Item2 == 0)
                {
                    //product.Item1.Shop = db.Shops.Single(c => c.ShopName == "Nasz sklep");
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