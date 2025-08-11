using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.MstProjectManager
{
    public class ProjectManagerReuqestDto
    {
        [Required(ErrorMessage = "Nipp is required")]
        [StringLength(15, ErrorMessage = "Nipp cannot be longer than 15 characters")]
        [JsonProperty("nipp")]
        public string Nipp { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        [Required(ErrorMessage = "Name is required")]
        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        [StringLength(1, ErrorMessage = "Active must be 1 character")]
        [RegularExpression("^[YN]$", ErrorMessage = "Active must be Y or N")]
        [JsonProperty("active")]
        public string Active { get; set; } = "Y";
    }
}