using Rutinus.Models;
using System.Net.Http.Json;

namespace Rutinus.Services
{
    /// <summary>
    /// UserService : 유저 서비스
    /// </summary>
    public class UserService : ApiClient
    {
        public UserService() { }

        /// <summary>
        /// InsertUser : 사용자 정보 입력
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse<UserModel>> InsertUser(UserModel request)
        {
            var response = await _http.PostAsJsonAsync("/api/user/insertuser", request);
            var result = new ApiResponse<UserModel>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<UserModel>();
                result.Success = true;
                result.Message = "Success";
                result.Data = data;
            }
            else
            {
                result.Success = false;
                result.Message = $"Error: {response.StatusCode}";
            }

            return result;
        }

        /// <summary>
        /// GetUserUseIdPwd : 사용자 ID, PASSWORD 로 정보 조회
        /// </summary>
        /// <param name="userId">사용자 ID</param>
        /// <param name="userPwd">사용자 PASSWORD</param>
        /// <returns></returns>
        public async Task<ApiResponse<UserModel>> GetUserUseIdPwd(string userId, string userPwd)
        {
            var response = await _http.GetAsync($"/api/user/getuseruseidpwd?userId={userId}&userPwd={userPwd}");

            var result = new ApiResponse<UserModel>();

            if (response.IsSuccessStatusCode && response.Content != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var list = await response.Content.ReadFromJsonAsync<UserModel>();
                result.Success = true;
                result.Data = list ?? new UserModel();
                result.Message = "Success";

            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                result.Success = false;
                result.Message = $"Error: {response.StatusCode}, {error}";
            }

            return result;
        }

        /// <summary>
        /// GetDuplicateUser : ID 중복여부 조회
        /// </summary>
        /// <param name="userId">사용자 ID</param>
        /// <returns></returns>
        public async Task<ApiResponse<UserModel>> GetDuplicateUser(string userId)
        {
            var response = await _http.GetAsync($"/api/user/getduplicateuser?userId={userId}");

            var result = new ApiResponse<UserModel>();

            if (response.IsSuccessStatusCode && response.Content != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var list = await response.Content.ReadFromJsonAsync<UserModel>();
                result.Success = true;
                result.Data = list ?? new UserModel();
                result.Message = "Success";

            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                result.Success = false;
                result.Message = $"Error: {response.StatusCode}, {error}";
            }

            return result;
        }
    }
}
