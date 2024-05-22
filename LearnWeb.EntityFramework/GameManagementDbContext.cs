using LearnWeb.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LearnWeb.EntityFramework
{
    public class GameManagementDbContext :DbContext
    {
        public GameManagementDbContext(DbContextOptions<GameManagementDbContext> options) : base(options) { 
        
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Player>().HasData(DataSeed.Players);
            modelBuilder.Entity<Character>().HasData(DataSeed.Characters);
        }
    }
}
