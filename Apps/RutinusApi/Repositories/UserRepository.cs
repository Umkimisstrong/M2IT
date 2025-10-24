using RutinusApi.Data;
using RutinusApi.Entities;
using RutinusApi.Models;

namespace RutinusApi.Repositories
{
    /// <summary>
    /// UserRepository : 유저 작업 저장소
    /// </summary>
    public class UserRepository
    {
        /* DbContext */
        private readonly RutinusDbContext _context;
        private readonly string _connectionString;

        /// <summary>
        /// UserRepository : 생성자
        /// </summary>
        /// <param name="context"></param>
        /// <param name="config"></param>
        public UserRepository(RutinusDbContext context, IConfiguration config)
        { 
            _context = context;
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// InsertUserAsync : 사용자 정보 저장
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public async Task<int> InsertUserAsync(UserEntity userEntity)
        { 
            _context.Users.Add(userEntity);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// GetDuplicateUser : ID 로 중복된 사용자 조회
        /// </summary>
        /// <param name="userId">사용자 ID</param>
        /// <returns></returns>
        public UserDto GetDuplicateUser(string userId)
        {
            var query = (from user in _context.Users
                         where user.UserId == userId
                         select new UserDto
                         {
                             UserId = user.UserId,
                             UserNm = user.UserNm,
                             UserPwd = user.UserPwd,
                             UserEmail = user.UserEmail,
                             TrialDt = user.TrialDt,
                             ActivatedDt = user.ActivatedDt,
                             CreatedAt = user.CreatedAt,
                             CreatedBy = user.CreatedBy,
                             UpdatedAt = user.UpdatedAt,
                             UpdatedBy = user.UpdatedBy,
                         }).FirstOrDefault();

            return query;
        }

        /// <summary>
        /// GetUserUseIdPwd : ID, PASSWORD 로 사용자 조회
        /// </summary>
        /// <param name="userId">사용자 ID</param>
        /// <param name="userPwd">사용자 PASSWORD</param>
        /// <returns></returns>
        public UserDto GetUserUseIdPwd(string userId, string userPwd)
        {
            var query = (from user in _context.Users
                        where user.UserId == userId
                           && user.UserPwd == userPwd
                        select new UserDto
                        {
                            UserId = user.UserId,
                            UserNm = user.UserNm,
                            UserPwd = user.UserPwd,
                            UserEmail = user.UserEmail,
                            TrialDt = user.TrialDt,
                            ActivatedDt = user.ActivatedDt,
                            CreatedAt = user.CreatedAt,
                            CreatedBy = user.CreatedBy,
                            UpdatedAt = user.UpdatedAt,
                            UpdatedBy = user.UpdatedBy
                            
                        }).FirstOrDefault();

            return query;
        }


    }
}
