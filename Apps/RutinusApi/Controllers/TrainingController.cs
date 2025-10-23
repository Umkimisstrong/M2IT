using Microsoft.AspNetCore.Mvc;
using RutinusApi.Entities;
using RutinusApi.Models;
using RutinusApi.Repositories;

namespace RutinusApi.Controllers
{
    /// <summary>
    /// TrainingController : 훈련 컨트롤러
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly TrainingRepository _repo;
        public TrainingController(TrainingRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// GetTrainings : 훈련 목록 조회
        /// </summary>
        /// <param name="routineId">루틴 아이디</param>
        /// <returns></returns>
        [HttpGet("gettrainings")]
        public async Task<ActionResult<IEnumerable<TrainingDto>>> GetTrainings(int routineId)
        {
            var entities = _repo.GetTrainings(routineId);
            return Ok(entities);
        }

        /// <summary>
        /// SaveTrainingAsync : 훈련입력
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("savetraining")]
        public async Task<IActionResult> SaveTrainingAsync([FromBody] List<TrainingDto> request)
        {
            int result = 0;
            for (int i = 0; i < request.Count; i++)
            {
                TrainingEntity entity = new TrainingEntity()
                {
                    TrainingCd = request[i].TrainingCd,
                    TrainingNm = request[i].TrainingNm,
                    TrainingDesc = request[i].TrainingDesc,
                    TrainingReps = request[i].TrainingReps,
                    TrainingSet = request[i].TrainingSet,
                    TrainingWeight = request[i].TrainingWeight,
                    RoutineId = request[i].RoutineId,
                    CreatedAt = DateTime.Now,
                    CreatedBy = request[i].CreatedBy,
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = request[i].UpdatedBy
                };
                result += await _repo.InsertTrainingAsync(entity);

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
                new ApiResponse<TrainingDto>
                {
                    Success = isSuccess,
                    Message = ResultMessage,
                    Data = new TrainingDto
                    {
                        TrainingId  = 0,
                    }
                }
            );

        }

        /// <summary>
        /// DeleteTrainingAsync : 훈련 삭제
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("deletetraining")]
        public async Task<IActionResult> DeleteTrainingAsync([FromBody] TrainingDto request)
        {
            int result = await _repo.DeleteTrainingAsync(request.RoutineId);
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
                new ApiResponse<TrainingDto>
                {
                    Success = isSuccess,
                    Message = ResultMessage,
                    Data = new TrainingDto
                    {
                        TrainingId = 0
                    }
                }
            );

        }

    }
}
