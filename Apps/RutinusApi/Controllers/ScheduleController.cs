using Microsoft.AspNetCore.Mvc;
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
    }
}
