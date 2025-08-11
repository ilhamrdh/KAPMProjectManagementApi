using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.MstUnitProject
{
    public class UnitProjectRequestDto
    {
        [Required(ErrorMessage = "Unit Project is required")]
        [StringLength(50, ErrorMessage = "Unit Project cannot exceed 50 characters")]
        [JsonProperty("unit_project")]
        public string UnitProject { get; set; } = default!;

        [StringLength(100, ErrorMessage = "Unit Description cannot exceed 100 characters")]
        [JsonProperty("unit_desc")]
        public string UnitDesc { get; set; } = string.Empty;

        [StringLength(1, ErrorMessage = "Active must be 1 character")]
        [RegularExpression("^[YN]$", ErrorMessage = "Active must be Y or N")]
        [JsonProperty("active")]
        public string Active { get; set; } = "Y";

        [StringLength(100, ErrorMessage = "User Add cannot exceed 100 characters")]
        [JsonProperty("user_add")]
        public string UserAdd { get; set; } = string.Empty;
    }

}