using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.Web
{
    public class QuerySearch
    {
        [JsonProperty("keyword")]
        public string? Keyword { get; set; } = string.Empty;

        // [JsonProperty("sort_by")]
        // public string SortBy { get; set; } = string.Empty;

        [JsonProperty("page_number")]
        [Range(1, int.MaxValue, ErrorMessage = "Page number must be a positive number")]
        public int PageNumber { get; set; } = 1;

        [JsonProperty("page_size")]
        [Range(1, int.MaxValue, ErrorMessage = "Page size must be a positive number")]
        public int PageSize { get; set; } = 10;

    }
}