using APIChallenge.Entities;
using Microsoft.EntityFrameworkCore;
namespace APIChallenge.Database
{
    public class MyContext : DbContext

    {
        private readonly IConfiguration configuration;

        public MyContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<User>? Users { get; set; }
        
        public DbSet<Product>? Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = DESKTOP-FA8GT7U\\SQLEXPRESS; Initial Catalog=APIChalleneg;User Id=sathwik;Password=1234;TrustServerCertificate=true");
            
        }
    }
}
