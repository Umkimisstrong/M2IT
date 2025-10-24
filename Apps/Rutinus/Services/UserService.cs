using Rutinus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Rutinus.Services
{
    public class UserService : ApiClient
    {
        public UserService() { }

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
