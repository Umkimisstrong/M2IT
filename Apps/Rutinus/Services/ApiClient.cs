using Rutinus.Entities;
using Rutinus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Rutinus.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient()
        {
            _http = new HttpClient { BaseAddress = new Uri("https://localhost:7049") };
        }

        public async Task<RoutineEntity> SaveRoutine(RoutineModel request)
        {
            
            var response = await _http.PostAsJsonAsync("/api/routine/saveroutine", request);

            if (!response.IsSuccessStatusCode) 
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"저장 실패: {error}");
            }
            var result = await response.Content.ReadFromJsonAsync<RoutineEntity>();

            Console.WriteLine($"루틴 저장 완료: {result}");

            return result;
        }
    }
}
