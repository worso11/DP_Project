using System;

namespace DP_Project
{
    public class Secondary : State
    {
        public Secondary(DataBase par) : base(par){}
        public override void Read()
        {
            Console.WriteLine("Products:");
            foreach (var product in Parent.Products)
            {
                Console.WriteLine(product.Name + " z kategorii " + product.Category);
            }
        }

        public override void Write()
        {
            Console.Write("It should not have happened");
        }

        public override void Delete()
        {
            Console.Write("It should not have happened");
        }
    }
}