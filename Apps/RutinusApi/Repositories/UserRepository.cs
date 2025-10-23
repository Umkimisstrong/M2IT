using RutinusApi.Data;
using RutinusApi.Entities;
using RutinusApi.Models;

namespace RutinusApi.Repositories
{
    public class UserRepository
    {
        private readonly RutinusDbContext _context;
        private readonly string _connectionString;

        public UserRepository(RutinusDbContext context, IConfiguration config)
        { 
            _context = context;
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<int> InsertUserAsync(UserEntity userEntity)
        { 
            _context.Users.Add(userEntity);
            return await _context.SaveChangesAsync();
        }

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
