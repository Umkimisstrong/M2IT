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
        public async Task<RoutineEntity> SaveRoutine(RoutineModel request)
        {
            var response = await _http.PostAsJsonAsync("/api/routine/saveroutine", request);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"저장 실패: {error}");
            }
            return await response.Content.ReadFromJsonAsync<RoutineEntity>(); ;
        }
    }
}
