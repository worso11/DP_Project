using System;
using System.Linq;

namespace DP_Project
{
    public static class UpdateDb
    {
        public static Product Add(DataBase ctx)
        {
            Console.WriteLine("Podaj nazwę produktu: ");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj nazwę kategorii: ");
            string category = Console.ReadLine();
            Console.WriteLine("Czy produkt został porzucony? (T/N): ");
            string isDisc = Console.ReadLine();
            bool disc = false;
            while (isDisc != "T" && isDisc != "N")
            {
                Console.WriteLine("Niepoprawna odpowiedź, wpisz \"T\" lub \"N\":");
                isDisc = Console.ReadLine();
            }
            if (isDisc == "T")
            {
                disc = true;
            }
            ctx.Database.Initialize(true);
            var product = new Product()
            {
                Name = name,
                Category = category,
                Discontinued = disc
                //Shop = ctx.Shops.Single(c => c.ShopName == "Nasz sklep")
            };
            ctx.Products.Add(product);
            ctx.SaveChanges();
            Console.WriteLine("Ilość pozycji: " + ctx.Products.Count());
            Console.WriteLine("### Zapisano do bazy " + ctx.name + " ###");
            ctx.Version += 1;

            return product;
        }

        public static void Add(Product product)
        {
            foreach (var dataBase in DbManager.DataBases.Where(dataBase => dataBase != DbManager.Primary))
            {
                if (dataBase.State.GetType() == typeof(Inactive))
                {
                    dataBase.Unit.AddToQueue((new Tuple<Product,int>(product,0)));
                }
                else
                {
                    //product.Shop = dataBase.Shops.Single(c => c.ShopName == "Nasz sklep");
                    dataBase.Database.Initialize(true);
                    dataBase.Products.Add(product);
                    dataBase.SaveChanges();
                    Console.WriteLine("### Zapisano do bazy " + dataBase.name + " ###");
                    dataBase.Version += 1;
                }
            }
        }

        public static int Delete(DataBase ctx)
        {
            Console.WriteLine("Podaj id produktu do usunięcia: ");
            string inputId = Console.ReadLine();
            int id;
            var product = new Product();
            while(!Int32.TryParse(inputId, out id) || ctx.Products.Find(id) == null)
            {
                Console.WriteLine("Niepoprawna odpowiedź, wpisz prawidłową liczbę:");
                inputId = Console.ReadLine();
            }

            ctx.Database.Initialize(true);
            product = ctx.Products.Find(id);
            ctx.Products.Remove(product);
            ctx.SaveChanges();
            Console.WriteLine("### Usunięto z bazy " + ctx.name + " ###");
            ctx.Version += 1;

            return id;
        }
        
        public static void Delete(int id)
        {
            foreach (var dataBase in DbManager.DataBases.Where(dataBase => dataBase != DbManager.Primary))
            {
                Product product = new Product();
                if (dataBase.State.GetType() == typeof(Inactive))
                {
                    dataBase.Unit.AddToQueue((new Tuple<Product,int>(product,id)));
                }
                else
                {
                    dataBase.Database.Initialize(true);
                    product = dataBase.Products.Find(id);
                    dataBase.Products.Attach(product);
                    dataBase.Products.Remove(product);
                    dataBase.SaveChanges();
                    Console.WriteLine("### Usunięto z bazy " + dataBase.name + " ###");
                    dataBase.Version += 1;
                }
            }
        }
    }
}