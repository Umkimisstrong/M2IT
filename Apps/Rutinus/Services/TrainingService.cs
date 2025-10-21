using Rutinus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Rutinus.Services
{
    public class TrainingService : ApiClient
    {
        public TrainingService() { }

        /// <summary>
        /// GetRoutineListAsync : 루틴 목록 조회
        /// </summary>
        /// <param name="createId">작성자</param>
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
    }
}
