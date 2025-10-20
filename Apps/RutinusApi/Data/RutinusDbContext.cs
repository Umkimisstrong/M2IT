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

        public DbSet<RoutineEntity> Routines { get; set; }
    }
}
