using Rutinus.Models;
using System.Net.Http.Json;

namespace Rutinus.Services
{
    /// <summary>
    /// ScheduleService : 일정 서비스
    /// </summary>
    public class ScheduleService : ApiClient
    {
        public ScheduleService() { }

        /// <summary>
        /// GetTrainingListAsync : 훈련 목록 조회
        /// </summary>
        /// <param name="routineId">루틴 id</param>
        /// <returns></returns>
        public async Task<ApiResponse<List<TrainingModel>>> GetTrainingListAsync(int routineId)
        {
            var response = await _http.GetAsync($"/api/training/gettrainings?routineid={routineId}");

            var result = new ApiResponse<List<TrainingModel>>();

            if (response.IsSuccessStatusCode)
            {
                var list = await response.Content.ReadFromJsonAsync<List<TrainingModel>>();
                result.Success = true;
                result.Data = list ?? new List<TrainingModel>();
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
        /// SaveTraining : 훈련 저장
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse<TrainingModel>> SaveTraining(List<TrainingModel> request)
        {
            var response = await _http.PostAsJsonAsync("/api/training/savetraining", request);
            var result = new ApiResponse<TrainingModel>();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<TrainingModel>();
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
        /// DeleteTraining : 훈련 삭제
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse<TrainingModel>> DeleteTraining(TrainingModel request)
        {
            var response = await _http.PostAsJsonAsync("/api/training/deletetraining", request);
            var result = new ApiResponse<TrainingModel>();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<TrainingModel>();
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
    }
}
