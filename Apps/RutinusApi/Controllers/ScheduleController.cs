using Microsoft.AspNetCore.Mvc;
using RutinusApi.Entities;
using RutinusApi.Models;
using RutinusApi.Repositories;

namespace RutinusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleRepository _repo;

        public ScheduleController(ScheduleRepository repo)
        { 
            _repo = repo;
        }

        /// <summary>
        /// GetSchedules : 일정 목록 조회
        /// </summary>
        /// <param name="scheduleYmd">날짜 YYYYMMDD</param>
        /// <param name="scheduleUser">사용자 ID</param>
        /// <returns></returns>
        [HttpGet("gettschedules")]
        public async Task<ActionResult<IEnumerable<ScheduleDto>>> GetSchedules(string scheduleYmd, string scheduleUser)
        {
            var entities = _repo.GetSchedules(scheduleYmd, scheduleUser);
            return Ok(entities);
        }

        /// <summary>
        /// SaveScheduleAsync : 일정 등록
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("saveschedule")]
        public async Task<IActionResult> SaveScheduleAsync([FromBody] List<ScheduleDto> request)
        {
            int result = 0;
            for (int i = 0; i < request.Count; i++)
            {
                ScheduleEntity entity = new ScheduleEntity()
                {
                    RoutineId = request[i].RoutineId,
                    ScheduleYmd = request[i].ScheduleYmd,
                    ScheduleHms = request[i].ScheduleHms,
                    ScheduleUser = request[i].ScheduleUser,
                    CreatedAt = DateTime.Now,
                    CreatedBy = request[i].CreatedBy,
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = request[i].UpdatedBy
                };
                result += await _repo.InsertScheduleAsync(entity);

            }
            string ResultMessage = "";
            bool isSuccess = false;
            if (result > 0)
            {
                ResultMessage = "훈련이 저장되었습니다.";
                isSuccess = true;
            }
            else
            {
                ResultMessage = "훈련이 저장되지 않았습니다.";
                isSuccess = false;
            }

            return Ok(
                new ApiResponse<ScheduleDto>
                {
                    Success = isSuccess,
                    Message = ResultMessage,
                    Data = new ScheduleDto
                    {
                        ScheduleId = 0,
                    }
                }
            );

        }

        /// <summary>
        /// DeleteScheduleAsync : 일정 삭제
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("deleteschedule")]
        public async Task<IActionResult> DeleteScheduleAsync([FromBody] ScheduleDto request)
        {
            int result = await _repo.DeleteScheduleAsync(request.ScheduleYmd, request.ScheduleUser);
            string ResultMessage = "";
            bool isSuccess = false;
            if (result > 0)
            {
                ResultMessage = "훈련이 삭제되었습니다.";
                isSuccess = true;
            }
            else
            {
                ResultMessage = "훈련이 삭제되지 않았습니다.";
                isSuccess = false;
            }

            return Ok(
                new ApiResponse<ScheduleDto>
                {
                    Success = isSuccess,
                    Message = ResultMessage,
                    Data = new ScheduleDto
                    {
                        ScheduleId = 0
                    }
                }
            );

        }
    }
}
