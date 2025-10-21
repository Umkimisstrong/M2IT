using Microsoft.AspNetCore.Mvc;
using RutinusApi.Models;
using RutinusApi.Repositories;

namespace RutinusApi.Controllers
{
    /// <summary>
    /// CodeController : 코드 컨트롤러
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CodeController : ControllerBase
    {
        private readonly CodeRepository _repo;
        public CodeController(CodeRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// GetCodeValueItemsAsync : 코드밸류 아이템 가져오기
        /// </summary>
        /// <param name="sysCd">시스템코드</param>
        /// <param name="divCd">분류코드</param>
        /// <returns></returns>
        [HttpGet("getcodevalueitem")]
        public async Task<ActionResult<IEnumerable<CodeDto>>> GetCodeValueItemsAsync(string sysCd, string divCd)
        {
            var entities = _repo.GetCodeValueItems(sysCd, divCd);

            // Entity → Model 변환
            var models = entities.Select(e => new CodeDto
            {
                Cd = e.Cd,
                CdNm = e.CdNm,
            }).ToList();

            return Ok(models);
        }

    }
}
