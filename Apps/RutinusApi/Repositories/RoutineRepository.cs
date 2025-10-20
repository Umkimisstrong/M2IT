using MySqlConnector;
using RutinusApi.Data;
using RutinusApi.Entities;
using RutinusApi.Tables;
using System.Data;

namespace RutinusApi.Repositories
{
    public class RoutineRepository
    {
        private readonly RutinusDbContext _context;
        private readonly string _connectionString;

        public RoutineRepository(RutinusDbContext context, IConfiguration config)
        {
            _context = context;
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public List<RoutineEntity> GetRoutines(string createId)
        {
            // LINQ 사용 — EF Core 가 SQL로 자동 변환
            return _context.Routines
                           .Where(r => r.CreatedBy == createId)
                           .OrderByDescending(r => r.CreatedAt)
                           .ToList();
        }

        public async Task<int> InsertRoutineAsync(RoutineEntity entity)
        {
            _context.Routines.Add(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
