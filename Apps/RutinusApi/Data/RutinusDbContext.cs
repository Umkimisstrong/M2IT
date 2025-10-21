using Microsoft.EntityFrameworkCore;
using RutinusApi.Entities;

namespace RutinusApi.Data
{
    /// <summary>
    /// RutinusDbContext : 루티너스 앱의 DB 목록
    /// </summary>
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

        // 루틴
        public DbSet<RoutineEntity> Routines { get; set; }
        // 코드
        public DbSet<CodeEntity> Codes { get; set; }
    }
}
