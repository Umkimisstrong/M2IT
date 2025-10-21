namespace RutinusApi.Models
{
    /// <summary>
    /// ApiResponse : 통신을 위한 ApiResponse 모델
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
