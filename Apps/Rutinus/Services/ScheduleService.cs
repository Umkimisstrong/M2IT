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
        /// GetScheduleListAsync : 
        /// </summary>
        /// <param name="scheduleYmd"></param>
        /// <param name="scheduleUser"></param>
        /// <returns></returns>
        public async Task<ApiResponse<List<ScheduleModel>>> GetScheduleListAsync(string scheduleYmd, string scheduleUser)
        {
            var response = await _http.GetAsync($"/api/schedule/gettschedules?scheduleYmd={scheduleYmd}&scheduleUser={scheduleUser}");

            var result = new ApiResponse<List<ScheduleModel>>();

            if (response.IsSuccessStatusCode)
            {
                var list = await response.Content.ReadFromJsonAsync<List<ScheduleModel>>();
                result.Success = true;
                result.Data = list ?? new List<ScheduleModel>();
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
        /// SaveSchedule : 일정 저장
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse<ScheduleModel>> SaveSchedule(List<ScheduleModel> request)
        {
            var response = await _http.PostAsJsonAsync("/api/schedule/saveschedule", request);
            var result = new ApiResponse<ScheduleModel>();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<ScheduleModel>();
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
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse<ScheduleModel>> DeleteSchedule(ScheduleModel request)
        {
            var response = await _http.PostAsJsonAsync("/api/schedule/deleteschedule", request);
            var result = new ApiResponse<ScheduleModel>();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<ScheduleModel>();
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
