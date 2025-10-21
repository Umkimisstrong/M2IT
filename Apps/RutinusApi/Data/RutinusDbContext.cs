using Microsoft.EntityFrameworkCore;
using RutinusApi.Entities;
using RutinusApi.Models;
using RutinusApi.Tables;

namespace RutinusApi.Data
{
    public class RutinusDbContext : DbContext
    {
        public RutinusDbContext(DbContextOptions<RutinusDbContext> options)  : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodeEntity>().HasKey(ur => new { ur.SysCd, ur.DivCd, ur.Cd });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<RoutineEntity> Routines { get; set; }
        public DbSet<CodeEntity> Codes { get; set; }
    }
}
