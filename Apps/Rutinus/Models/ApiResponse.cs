namespace Rutinus.Models
{
    /// <summary>
    /// ApiResponse : Api 호출에 관한 정보를 담는 모델
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }  = string.Empty;
        public T? Data { get; set; }
    }
}
