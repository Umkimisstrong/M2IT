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
    /// <summary>
    /// ApiClient : ApiClient 객체
    /// </summary>
    public class ApiClient
    {
        protected readonly HttpClient _http;

        public ApiClient()
        {
            _http = new HttpClient { BaseAddress = new Uri("https://localhost:7049") };
        }
        
    }
}
