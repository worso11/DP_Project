using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace DP_Project
{
    // Klasa mapująca obiektowo-relacyjnie bazę danych
    public class DataBase : DbContext
    {
        public State State;
        public int Version;
        public bool IsActive = true;
        public string name;
        public UnitOfWork Unit = new UnitOfWork();
        
        // Konstruktor z odpowiednim connectionString
        public DataBase(string str) : base(str)
        {
            State = new Secondary(this);
            Version = 1;
            name = str;
        }

        // Funkcja odczytu z bazy danych zależna od stanu bazy
        public void Read()
        {
            State.Read();
        }
        
        // Funkcja zapisu do bazy danych zależna od stanu bazy
        public void Write()
        {
            State.Write();
        }
        
        // Funkcja usuwania z bazy danych zależna od stanu bazy
        public void Delete()
        {
            State.Delete();
        }

        // Funkcja wywołania Visitora dla bazy danych zależna od stanu bazy
        public void AcceptVisitor()
        {
            State.AcceptVisitor();
        }

        // Funkcja zmieniająca stan bazy danych
        public void ChangeState(State state)
        {
            State = state;
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
    }
    
    
    // Klasa reprezentująca wiersz tabeli Products
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Discontinued { get; set; }
        public virtual Shop Shop { get; set; }
    }

    // Klasa reprezentująca wiersz tabeli Shops
    public class Shop
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string City { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}