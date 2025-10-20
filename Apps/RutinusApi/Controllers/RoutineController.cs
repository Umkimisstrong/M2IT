using Microsoft.AspNetCore.Mvc;
using RutinusApi.Entities;
using RutinusApi.Global;
using RutinusApi.Models;
using RutinusApi.Repositories;
using RutinusApi.Tables;
using System.Linq;

namespace RutinusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutineController : ControllerBase
    {
        private readonly RoutineRepository _repo;
        public RoutineController(RoutineRepository repo)
        {
            _repo = repo;
        }

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
                AlertYn = e.AlertYn
            }).ToList();

            return Ok(models);
        }

        [HttpPost("saveroutine")]
        public async Task<IActionResult> SaveRoutineAsync([FromBody] RoutineDto request)
        {
            RoutineEntity entity = new RoutineEntity() 
            {
                RoutineName = request.RoutineName,
                RoutinePart = "PART_003",
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
    }

}
