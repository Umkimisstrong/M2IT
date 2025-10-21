using Rutinus.Models;
using System.Net.Http.Json;

namespace Rutinus.Services
{
    /// <summary>
    /// CodeService : 코드 서비스
    /// </summary>
    public class CodeService : ApiClient
    {
        /// <summary>
        /// GetCodeValueItemAsync : 코드밸류(드랍다운콤보박스용)
        /// </summary>
        /// <param name="sysCd">시스템코드</param>
        /// <param name="divCd">분류코드</param>
        /// <returns></returns>
        public async Task<ApiResponse<List<CodeModel>>> GetCodeValueItemAsync(string sysCd, string divCd)
        {
            var response = await _http.GetAsync($"/api/code/getcodevalueitem?sysCd={sysCd}&divCd={divCd}");

            var result = new ApiResponse<List<CodeModel>>();

            if (response.IsSuccessStatusCode)
            {
                var list = await response.Content.ReadFromJsonAsync<List<CodeModel>>();
                result.Success = true;
                result.Data = list ?? new List<CodeModel>();
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
