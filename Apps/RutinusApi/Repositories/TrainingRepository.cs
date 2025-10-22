using Microsoft.EntityFrameworkCore;
using RutinusApi.Data;
using RutinusApi.Entities;
using RutinusApi.Models;

namespace RutinusApi.Repositories
{
    /// <summary>
    /// TrainingRepository : 훈련 작업 저장소
    /// </summary>
    public class TrainingRepository
    {
        /* DbContext */
        private readonly RutinusDbContext _context;
        private readonly string _connectionString;

        /// <summary>
        /// CodeRepository : 생성자
        /// </summary>
        /// <param name="context">DbContext</param>
        /// <param name="config">Configuration</param>
        public TrainingRepository(RutinusDbContext context, IConfiguration config)
        {
            _context = context;
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// GetTrainings : 훈련 목록 조회
        /// </summary>
        /// <param name="routineId">루틴아이디</param>
        /// <returns></returns>
        public List<TrainingDto> GetTrainings(int routineId)
        {
            var query = from trainings in _context.Trainings
                        join routines in _context.Routines on trainings.RoutineId equals routines.RoutineId
                        join traingCodes in _context.Codes on trainings.TrainingCd equals traingCodes.Cd
                        join routineCodes in _context.Codes on routines.RoutinePart equals routineCodes.Cd
                       where trainings.RoutineId == routineId
                          && traingCodes.SysCd == "RTN_CD"
                          && routineCodes.SysCd == "CMM"
                          && routineCodes.DivCd == "BODY_PART"
                        select new TrainingDto
                        {
                            RoutineId  = trainings.RoutineId,
                            RoutineName = routines.RoutineName,
                            RoutineDescription = routines.RoutineDescription,
                            RoutinePart = routines.RoutinePart,
                            AlertYn = routines.AlertYn,
                            RoutinePartName = routineCodes.CdNm,
                            TrainingId = trainings.TrainingId,
                            TrainingNm = trainings.TrainingNm,
                            TrainingDesc = trainings.TrainingDesc,
                            TrainingCd = trainings.TrainingCd,
                            TrainingCdName = traingCodes.CdNm,
                            TrainingSet = trainings.TrainingSet,
                            TrainingReps = trainings.TrainingReps,
                            TrainingWeight = trainings.TrainingWeight,
                        };

            return query.ToList<TrainingDto>();
        }

        /// <summary>
        /// InsertRoutineAsync : 루틴 입력
        /// </summary>
        /// <param name="entity">루틴 엔티티</param>
        /// <returns></returns>
        public async Task<int> InsertTrainingAsync(TrainingEntity trainingEntity)
        {
            _context.Trainings.Add(trainingEntity);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// DeleteTrainingAsync : 트레이닝 삭제
        /// </summary>
        /// <param name="routineId">루틴 아이디</param>
        /// <returns></returns>
        public async Task<int> DeleteTrainingAsync(int routineId)
        {
            return await _context.Trainings
                        .Where(r => r.RoutineId == routineId)
                        .ExecuteDeleteAsync();
        }

    }
}
