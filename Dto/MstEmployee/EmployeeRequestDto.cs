using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.MstEmployee
{
    public class EmployeeRequestDto
    {
        [Required(ErrorMessage = "NIPP is required")]
        [StringLength(15, ErrorMessage = "NIPP must be at most 15 characters long")]
        [JsonProperty("nipp")]
        public string Nipp { get; set; } = default!;

        [StringLength(5, ErrorMessage = "Name must be at most 5 characters long")]
        [JsonProperty("grade")]
        public string Grade { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Name must be at most 100 characters long")]
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Name must be at most 50 characters long")]
        [JsonProperty("plans")]
        public string Plans { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Name must be at most 100 characters long")]
        [JsonProperty("orgeh")]
        public string Orgeh { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Name must be at most 100 characters long")]
        [JsonProperty("persa")]
        public string Persa { get; set; } = string.Empty;

        [StringLength(1, ErrorMessage = "Active must be 1 character")]
        [RegularExpression("^[YN]$", ErrorMessage = "Active must be Y or N")]
        [JsonProperty("active")]
        public string Active { get; set; } = "Y";
    }
}