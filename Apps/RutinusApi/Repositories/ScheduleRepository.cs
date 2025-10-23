using RutinusApi.Data;

namespace RutinusApi.Repositories
{
    public class ScheduleRepository
    {
        private readonly RutinusDbContext _context;
        private readonly string _connectionString;

        public ScheduleRepository(RutinusDbContext context, IConfiguration config)
        { 
            _context = context;
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
    }
}
