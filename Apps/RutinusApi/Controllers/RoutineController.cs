using Microsoft.AspNetCore.Mvc;
using RutinusApi.Models;
using RutinusApi.Entities;
namespace RutinusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutineController : ControllerBase
    {

        [HttpPost("saveroutine")]
        public IActionResult SaveRoutine([FromBody] RoutineModel request)
        {
            if (string.IsNullOrEmpty(request.routineName))
            {
                return BadRequest("루틴 이름은 필수입니다.");
            }

            
            RoutineEntity entity = new RoutineEntity();
            entity.routineId = Guid.NewGuid().ToString();
            entity.routineName = request.routineName;
            entity.defaultWeight = request.defaultWeight;
            entity.bodyParts = request.bodyParts;
            entity.bodyPart = request.bodyPart;
            entity.description = request.description;
            entity.receiveNotifications = request.receiveNotifications;
            entity.selectedBodyPart = request.selectedBodyPart;
            entity.startDate = request.startDate;

            return Ok(
                entity
            );

        }
    }

}
