using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.Web
{
    public class WebResponse<T>
    {
        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("data")]
        public T? Data { get; set; }

        public WebResponse(string? message = null, bool success = true, int statusCode = 200)
        {
            Message = message;
            Success = success;
            StatusCode = statusCode;
        }
        public WebResponse(T data, string? message = null, bool success = true, int statusCode = 200)
        {
            Message = message;
            Success = success;
            StatusCode = statusCode;
            Data = data;
        }
    }
}