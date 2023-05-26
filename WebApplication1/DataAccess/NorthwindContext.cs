using Microsoft.EntityFrameworkCore;
using WebApiDemo.Entities;
using WebApplication1.Entities;

namespace WebApplication1.DataAccess
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8N2FR5G\ISMAILUZUNDAG;Database = NORTHWND;  Trusted_Connection=true;TrustServerCertificate=True");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
