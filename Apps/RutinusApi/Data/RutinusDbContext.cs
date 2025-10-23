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
            modelBuilder.Entity<RuleEntity>().HasKey(ur => new { ur.BodyPartCd, ur.RtnCd });

            base.OnModelCreating(modelBuilder);
        }

        // 사용자
        public DbSet<UserEntity> Users { get; set; }
        // 루틴
        public DbSet<RoutineEntity> Routines { get; set; }
        // 코드
        public DbSet<CodeEntity> Codes { get; set; }
        // 룰
        public DbSet<RuleEntity> Rules { get; set; }
        // 훈련종목
        public DbSet<TrainingEntity> Trainings { get; set; }
        // 일정
        public DbSet<ScheduleEntity> Schedules { get; set; }
    }
}
