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
        /// UpdateRoutine : 루틴 수정
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse<RoutineModel>> UpdateRoutine(RoutineModel request)
        {
            var response = await _http.PostAsJsonAsync("/api/routine/updateroutine", request);
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
        /// DeleteRoutine : 루틴 삭제
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse<RoutineModel>> DeleteRoutine(RoutineModel request)
        {
            var response = await _http.PostAsJsonAsync("/api/routine/deleteroutine", request);
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
        /// GetRoutineListAsync : 루틴 목록 조회
        /// </summary>
        /// <param name="createId">작성자</param>
        /// <returns></returns>
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

        /// <summary>
        /// GetRoutineAsync : 루틴 단건 조회
        /// </summary>
        /// <param name="routineId">루틴 id</param>
        /// <returns></returns>
        public async Task<ApiResponse<RoutineModel>> GetRoutineAsync(int routineId)
        {
            var response = await _http.GetAsync($"/api/routine/getroutine?routineId={routineId}");

            var result = new ApiResponse<RoutineModel>();

            if (response.IsSuccessStatusCode)
            {
                var list = await response.Content.ReadFromJsonAsync<RoutineModel>();
                result.Success = true;
                result.Data = list ?? new RoutineModel();
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
