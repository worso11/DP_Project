using System;

namespace DP_Project
{
    public class Primary : State
    {
        public Primary(DataBase par) : base(par){}

        public override void Read()
        {
            Console.Write("It should not have happened");
        }

        public override void Write()
        {
            UpdateDb.Add(UpdateDb.Add(Parent));
        }

        public override void Delete()
        {
            UpdateDb.Delete(UpdateDb.Delete(Parent));
        }

        public override void AcceptVisitor()
        {
            Visitor.VisitPrimary(Parent);
        }
    }
}