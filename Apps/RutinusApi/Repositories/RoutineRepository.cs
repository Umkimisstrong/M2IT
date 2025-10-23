using Microsoft.EntityFrameworkCore;
using RutinusApi.Data;
using RutinusApi.Entities;
using RutinusApi.Models;
using System.Data;

namespace RutinusApi.Repositories
{
    /// <summary>
    /// RoutineRepository : 루틴 작업 저장소
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
                           && outerItem.CreatedBy == createId
                        select new RoutineDto
                        {
                            RoutineId = outerItem.RoutineId,
                            RoutineName = outerItem.RoutineName,
                            RoutineDescription = outerItem.RoutineDescription,
                            RoutinePart = outerItem.RoutinePart,
                            RoutinePartName = innerItem.CdNm
                        };

            return query.ToList<RoutineDto>();
        }

        /// <summary>
        /// GetRoutine : 루틴 단건 조회
        /// </summary>
        /// <param name="routineId">루틴 아이디</param>
        /// <returns></returns>
        public RoutineDto GetRoutine(int routineId)
        {
            var query = (from outerItem in _context.Routines
                        join innerItem in _context.Codes
                        on outerItem.RoutinePart equals innerItem.Cd
                        where innerItem.SysCd == "CMM" && innerItem.DivCd == "BODY_PART"
                           && outerItem.RoutineId == routineId
                        select new RoutineDto
                        {
                            RoutineId = outerItem.RoutineId,
                            RoutineName = outerItem.RoutineName,
                            RoutineDescription = outerItem.RoutineDescription,
                            RoutinePart = outerItem.RoutinePart,
                            AlertYn = outerItem.AlertYn,
                        }).FirstOrDefault();

            return query;
           
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
        /// <summary>
        /// UpdateRoutineAsync : 루틴 수정
        /// </summary>
        /// <param name="entity">루틴 엔티티</param>
        /// <returns></returns>
        public async Task<int> UpdateRoutineAsync(RoutineEntity entity)
        {
            return await _context.Routines
                        .Where(r => r.RoutineId == entity.RoutineId)
                        .ExecuteUpdateAsync(setters => setters
                                            .SetProperty(r => r.RoutineName, r=>entity.RoutineName)
                                            .SetProperty(r => r.RoutineDescription, r => entity.RoutineDescription)
                                            .SetProperty(r => r.RoutinePart, r => entity.RoutinePart)
                                            .SetProperty(r => r.AlertYn, r => entity.AlertYn)
                                            .SetProperty(r => r.UpdatedBy, r => entity.UpdatedBy)
                                            .SetProperty(r => r.UpdatedAt, r => entity.UpdatedAt)
                                            );
        }
        /// <summary>
        /// DeleteRoutineAsync : 루틴 삭제
        /// </summary>
        /// <param name="routineId">루틴 아이디</param>
        /// <returns></returns>
        public async Task<int> DeleteRoutineAsync(int routineId)
        {
            return await _context.Routines
                        .Where(r => r.RoutineId == routineId)
                        .ExecuteDeleteAsync();
        }
    }
}
