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
            throw new System.NotImplementedException();
        }

        public override void Delete()
        {
            throw new System.NotImplementedException();
        }

        public override void AcceptVisitor()
        {
            Visitor.VisitInactive(Parent);
        }
    }
}