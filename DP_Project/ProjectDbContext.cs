using System.Data.Entity;

namespace DP_Project
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
        :base("mssql")
        {
            
        }
        
        public DbSet<Product> Products { get; set; }
    }
    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Discontinued { get; set; }
    }
}