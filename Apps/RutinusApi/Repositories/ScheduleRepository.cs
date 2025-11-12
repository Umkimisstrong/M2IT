using Microsoft.EntityFrameworkCore;
using RutinusApi.Data;
using RutinusApi.Entities;
using RutinusApi.Models;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleYmd"></param>
        /// <param name="scheduleUser"></param>
        /// <returns></returns>
        public List<ScheduleDto> GetSchedules(string scheduleYmd, string scheduleUser )
        {
            var query = from schedule in _context.Schedules
                        join routine in _context.Routines on schedule.RoutineId equals routine.RoutineId
                        join training in _context.Trainings on routine.RoutineId equals training.RoutineId
                        join routineCodes in _context.Codes on routine.RoutinePart equals routineCodes.Cd
                        join traingCodes in _context.Codes on training.TrainingCd equals traingCodes.Cd
                        where schedule.ScheduleYmd == scheduleYmd
                           && schedule.ScheduleUser == scheduleUser
                           && traingCodes.SysCd == "RTN_CD"
                           && routineCodes.SysCd == "CMM"
                           && routineCodes.DivCd == "BODY_PART"
                        select new ScheduleDto
                        {
                            ScheduleId = schedule.ScheduleId,
                            ScheduleYmd = schedule.ScheduleYmd,
                            NoticeDt = schedule.NoticeDt,
                            StartDt = schedule.StartDt,
                            EndDt = schedule.EndDt,
                            ScheduleUser = schedule.ScheduleUser,
                            RoutineId = schedule.RoutineId,
                            RoutineName = routine.RoutineName,
                            RoutineDescription = routine.RoutineDescription,
                            RoutinePart = routine.RoutinePart,
                            RoutinePartName = routineCodes.CdNm,
                            TrainingId = training.TrainingId,
                            TrainingNm = training.TrainingNm,
                            TrainingDesc = training.TrainingDesc,
                            TrainingCd = training.TrainingCd,
                            TrainingCdName = traingCodes.CdNm,
                            TrainingSet = training.TrainingSet,
                            TrainingReps = training.TrainingReps,
                            TrainingWeight = training.TrainingWeight,
                        };

            return query.ToList<ScheduleDto>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleEntity"></param>
        /// <returns></returns>
        public async Task<int> InsertScheduleAsync(ScheduleEntity scheduleEntity)
        {
            _context.Schedules.Add(scheduleEntity);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleYmd"></param>
        /// <param name="scheduleUser"></param>
        /// <returns></returns>
        public async Task<int> DeleteScheduleAsync(string scheduleYmd, string scheduleUser)
        {
            return await _context.Schedules
                        .Where(r =>     r.ScheduleUser == scheduleUser
                                    &&  r.ScheduleYmd  == scheduleYmd
                             )
                        .ExecuteDeleteAsync();
        }
    }
}
