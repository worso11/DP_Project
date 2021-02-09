using System;

namespace DP_Project
{
    public class Inactive : State
    {
        public Inactive(DataBase par) : base(par){}

        public override void Read()
        {
            Console.Write("It should not have happened");
        }

        public override void Write()
        {
            Console.Write("It should not have happened");
        }

        public override void Delete()
        {
            Console.Write("It should not have happened");
        }

        public override void AcceptVisitor()
        {
            Visitor.VisitInactive(Parent);
        }
    }
}