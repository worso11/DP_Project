using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace DP_Project
{
    public class DataBase : DbContext
    {
        private State _state;
        private int Version;
        public bool IsActive = true;
        
        public DataBase(string str) : base(str)
        {
            _state = new Secondary(this);
            Version = 1;
        }

        public void Read()
        {
            _state.Read();
        }
        
        public void Write()
        {
            _state.Write();
        }
        
        public void Delete()
        {
            _state.Delete();
        }

        public void ChangeState(State state)
        {
            _state = state;
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