using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace DP_Project
{
    public class DataBase : DbContext
    {
        public State State;
        public int Version;
        public bool IsActive = true;
        public string name;
        public UnitOfWork Unit = new UnitOfWork();
        
        public DataBase(string str) : base(str)
        {
            State = new Secondary(this);
            Version = 1;
            name = str;
        }

        public void Read()
        {
            State.Read();
        }
        
        public void Write()
        {
            State.Write();
        }
        
        public void Delete()
        {
            State.Delete();
        }

        public void AcceptVisitor()
        {
            State.AcceptVisitor();
        }

        public void ChangeState(State state)
        {
            State = state;
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
    }
    
    
    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Discontinued { get; set; }
        public virtual Shop Shop { get; set; }
    }

    public class Shop
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string City { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}