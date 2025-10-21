using Microsoft.AspNetCore.Mvc;
using RutinusApi.Models;
using RutinusApi.Repositories;

namespace RutinusApi.Controllers
{
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

    }
}
