using Microsoft.AspNetCore.Mvc;
using RutinusApi.Entities;
using RutinusApi.Global;
using RutinusApi.Models;
using RutinusApi.Repositories;

namespace RutinusApi.Controllers
{
    /// <summary>
    /// RoutineController : 루틴 컨트롤러
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RoutineController : ControllerBase
    {
        private readonly RoutineRepository _repo;
        public RoutineController(RoutineRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// GetRoutines : 루틴목록조회
        /// </summary>
        /// <param name="createId">생성ID</param>
        /// <returns></returns>
        [HttpGet("getroutines")]
        public async Task<ActionResult<IEnumerable<RoutineDto>>> GetRoutines(string createId)
        {
            var entities =  _repo.GetRoutines(createId);

            // Entity → Model 변환
            var models = entities.Select(e => new RoutineDto
            {
                RoutineId = e.RoutineId,
                RoutineName = e.RoutineName,
                RoutineDescription = e.RoutineDescription,
                RoutinePart = e.RoutinePart,
                RoutinePartName = e.RoutinePartName,
                AlertYn = e.AlertYn
            }).ToList();

            return Ok(models);
        }

        /// <summary>
        /// GetRoutine : 루틴 단건 조회
        /// </summary>
        /// <param name="routineId">루틴아이디</param>
        /// <returns></returns>
        [HttpGet("getroutine")]
        public async Task<ActionResult<RoutineDto>> GetRoutine(int routineId)
        {
            var entity = _repo.GetRoutine(routineId);
            return Ok(entity);
        }

        /// <summary>
        /// SaveRoutineAsync : 루틴입력
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("saveroutine")]
        public async Task<IActionResult> SaveRoutineAsync([FromBody] RoutineDto request)
        {
            RoutineEntity entity = new RoutineEntity() 
            {
                RoutineName = request.RoutineName,
                RoutinePart = request.RoutinePart,
                RoutineDescription = request.RoutineDescription,
                AlertYn = request.AlertYn,
                CreatedAt = DateTime.Now,
                CreatedBy = "KIMSANGKI",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "KIMSANGKI"

            };
            int result = await _repo.InsertRoutineAsync(entity);
            string ResultMessage = "";
            bool isSuccess = false;
            if (result > 0)
            {
                ResultMessage = "루틴이 저장되었습니다.";
                isSuccess = true;
            }
            else
            {
                ResultMessage = "루틴이 저장되지 않았습니다.";
                isSuccess = false;
            }

            return Ok(
                new ApiResponse<RoutineDto>
                {
                    Success = isSuccess,
                    Message = ResultMessage,
                    Data = new RoutineDto
                    {
                        RoutineId = 0,
                        RoutineName = request.RoutineName,
                        RoutinePart = request.RoutinePart
                    }
                }
            );

        }

        /// <summary>
        /// UpdateRoutineAsync : 루틴수정
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("updateroutine")]
        public async Task<IActionResult> UpdateRoutineAsync([FromBody] RoutineDto request)
        {
            RoutineEntity entity = new RoutineEntity()
            {
                RoutineId = request.RoutineId,
                RoutineName = request.RoutineName,
                RoutinePart = request.RoutinePart,
                RoutineDescription = request.RoutineDescription,
                AlertYn = request.AlertYn,
                UpdatedAt = DateTime.Now,
                UpdatedBy = "KIMSANGKI"

            };
            int result = await _repo.UpdateRoutineAsync(entity);
            string ResultMessage = "";
            bool isSuccess = false;
            if (result > 0)
            {
                ResultMessage = "루틴이 수정되었습니다.";
                isSuccess = true;
            }
            else
            {
                ResultMessage = "루틴이 수정되지 않았습니다.";
                isSuccess = false;
            }

            return Ok(
                new ApiResponse<RoutineDto>
                {
                    Success = isSuccess,
                    Message = ResultMessage,
                    Data = new RoutineDto
                    {
                        RoutineId = 0,
                        RoutineName = request.RoutineName,
                        RoutinePart = request.RoutinePart
                    }
                }
            );

        }

        /// <summary>
        /// DeleteRoutineAsync : 루틴 삭제
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("deleteroutine")]
        public async Task<IActionResult> DeleteRoutineAsync([FromBody] RoutineDto request)
        {
            int result = await _repo.DeleteRoutineAsync(request.RoutineId);
            string ResultMessage = "";
            bool isSuccess = false;
            if (result > 0)
            {
                ResultMessage = "루틴이 삭제되었습니다.";
                isSuccess = true;
            }
            else
            {
                ResultMessage = "루틴이 삭제되지 않았습니다.";
                isSuccess = false;
            }

            return Ok(
                new ApiResponse<RoutineDto>
                {
                    Success = isSuccess,
                    Message = ResultMessage,
                    Data = new RoutineDto
                    {
                        RoutineId = 0,
                        RoutineName = request.RoutineName,
                        RoutinePart = request.RoutinePart
                    }
                }
            );

        }
    }

}
