using Rutinus.Entities;
using Rutinus.Models;
using System.Net.Http.Json;

namespace Rutinus.Services
{
    /// <summary>
    /// RoutineService : Routine 관련 서비스
    /// </summary>
    public class RoutineService : ApiClient
    {
        public RoutineService() 
        {
        
        }

        /// <summary>
        /// SaveRoutine : 루틴 저장
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse<RoutineModel>> SaveRoutine(RoutineModel request)
        {
            var response = await _http.PostAsJsonAsync("/api/routine/saveroutine", request);
            var result = new ApiResponse<RoutineModel>();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<RoutineModel>();
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
        /// 루틴 목록 조회
        /// </summary>
        public async Task<ApiResponse<List<RoutineModel>>> GetRoutineListAsync(string createId)
        {
            var response = await _http.GetAsync($"/api/routine/getroutines?createId={createId}");

            var result = new ApiResponse<List<RoutineModel>>();

            if (response.IsSuccessStatusCode)
            {
                var list = await response.Content.ReadFromJsonAsync<List<RoutineModel>>();
                result.Success = true;
                result.Data = list ?? new List<RoutineModel>();
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
