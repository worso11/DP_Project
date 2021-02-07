namespace DP_Project
{
    public abstract class State
    {
        protected DataBase Parent;

        protected State(DataBase par)
        {
            Parent = par;
        }
        
        public abstract void Read();
        public abstract void Write();
        public abstract void Delete();
    }
}