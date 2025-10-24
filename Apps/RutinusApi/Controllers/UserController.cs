using Microsoft.AspNetCore.Mvc;
using RutinusApi.Entities;
using RutinusApi.Models;
using RutinusApi.Repositories;

namespace RutinusApi.Controllers
{
    /// <summary>
    /// UserController : 유저 컨트롤러
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repo;

        public UserController(UserRepository repo)
        { 
            _repo = repo;
        }


        /// <summary>
        /// GetUserUseIdPwd : 사용자 ID, PASSWORD 로 정보 조회
        /// </summary>
        /// <param name="userId">사용자 ID</param>
        /// <param name="userPwd">사용자 PASSWORD</param>
        /// <returns></returns>
        [HttpGet("getuseruseidpwd")]
        public async Task<ActionResult<UserDto>> GetUserUseIdPwd(string userId, string userPwd)
        { 
            var entity = _repo.GetUserUseIdPwd(userId, userPwd);
            return Ok(entity);
        }

        /// <summary>
        /// GetDuplicateUser : 사용자 ID로 중복된 사용자 조회
        /// </summary>
        /// <param name="userId">사용자 ID</param>
        /// <returns></returns>
        [HttpGet("getduplicateuser")]
        public async Task<ActionResult<UserDto>> GetDuplicateUser(string userId)
        { 
            var entity = _repo.GetDuplicateUser(userId);
            return Ok(entity);
        }

        /// <summary>
        /// InsertUserAsync : 사용자 정보 입력
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("insertuser")]
        public async Task<IActionResult> InsertUserAsync([FromBody] UserDto request)
        {
            UserEntity entity = new UserEntity()
            {
                UserId = request.UserId,
                UserNm = request.UserNm,
                UserEmail = request.UserEmail,
                UserPwd = request.UserPwd,
                CreatedAt = DateTime.Now,
                CreatedBy = request.UserId,
                UpdatedAt = DateTime.Now,
                UpdatedBy = request.UserId
            };

            int result = await _repo.InsertUserAsync(entity);
            string ResultMessage = "";
            bool isSuccess = false;
            if (result > 0)
            {
                ResultMessage = "고객정보가 저장되었습니다.";
                isSuccess = true;
            }
            else
            {
                ResultMessage = "루틴이 저장되지 않았습니다.";
                isSuccess = false;
            }

            return Ok(
                new ApiResponse<UserDto>
                { 
                    Success = isSuccess,
                    Message = ResultMessage,
                    Data = new UserDto 
                    {
                        UserId = request.UserId,
                        UserNm = request.UserNm
                    }
                     
                }
            );
        }
    }
}
