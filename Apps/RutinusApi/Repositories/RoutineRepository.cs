using MySqlConnector;
using RutinusApi.Data;
using RutinusApi.Entities;
using RutinusApi.Models;
using RutinusApi.Tables;
using System.Data;

namespace RutinusApi.Repositories
{
    /// <summary>
    /// RoutineRepository : 루틴 관련 Repo
    /// </summary>
    public class RoutineRepository
    {
        /* DbContext */
        private readonly RutinusDbContext _context;
        private readonly string _connectionString;

        /// <summary>
        /// RoutineRepository : 생성자
        /// </summary>
        /// <param name="context">DbContext</param>
        /// <param name="config">Configuration</param>
        public RoutineRepository(RutinusDbContext context, IConfiguration config)
        {
            _context = context;
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// GetRoutines : 루틴 목록 조회
        /// </summary>
        /// <param name="createId">생성ID</param>
        /// <returns></returns>
        public List<RoutineDto> GetRoutines(string createId)
        {
            var query = from outerItem in _context.Routines
                        join innerItem in _context.Codes
                        on outerItem.RoutinePart equals innerItem.Cd
                        where innerItem.SysCd == "CMM" && innerItem.DivCd == "BODY_PART"
                        select new RoutineDto
                        {
                            RoutineId = outerItem.RoutineId,
                            RoutineName = outerItem.RoutineName,
                            RoutineDescription = outerItem.RoutineDescription,
                            RoutinePart = outerItem.RoutinePart,
                            RoutinePartName = innerItem.CdNm
                        };

            return query.ToList<RoutineDto>();
            // LINQ 사용 — EF Core 가 SQL로 자동 변환
            /*return _context.Routines
                           .Where(r => r.CreatedBy == createId)
                           .OrderByDescending(r => r.CreatedAt)
                           .ToList();
            */
        }

        /// <summary>
        /// InsertRoutineAsync : 루틴 입력
        /// </summary>
        /// <param name="entity">루틴 엔티티</param>
        /// <returns></returns>
        public async Task<int> InsertRoutineAsync(RoutineEntity entity)
        {
            _context.Routines.Add(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
