using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectAdendum
{
    public class ProjectAdendumRequestDto
    {
        [Required(ErrorMessage = "Adendum No is required")]
        [StringLength(50, ErrorMessage = "Adendum No must be at most 50 characters long")]
        [JsonProperty("adendum_no")]
        public string AdendumNo { get; set; } = default!;

        [Required(ErrorMessage = "Code Project is required")]
        [StringLength(50, ErrorMessage = "Code Project must be at most 50 characters long")]
        [JsonProperty("code_project")]
        public string CodeProject { get; set; } = default!;

        [Required(ErrorMessage = "Type Adendum is required")]
        [StringLength(50, ErrorMessage = "Type Adendum must be at most 50 characters long")]
        [JsonProperty("type_adendum")]
        public string TypeAdendum { get; set; } = string.Empty;

        [Required(ErrorMessage = "WBS No is required")]
        [StringLength(50, ErrorMessage = "WBS No must be at most 50 characters long")]
        [JsonProperty("wbs_no")]
        public string WBSNo { get; set; } = default!;

        [Required(ErrorMessage = "Cost Before is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Cost Before must be a positive number")]
        [JsonProperty("cost_before")]
        public double CostBefore { get; set; }

        [Required(ErrorMessage = "Cost After is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Cost After must be a positive number")]
        [JsonProperty("cost_after")]
        public double CostAfter { get; set; }

        [JsonProperty("date_before")]
        [DataType(DataType.DateTime)]
        public DateTime DateBefore { get; set; }

        [JsonProperty("date_after")]
        [DataType(DataType.DateTime)]
        public DateTime DateAfter { get; set; }

        [JsonProperty("reason")]
        [Required(ErrorMessage = "Reason is required")]
        [StringLength(255, ErrorMessage = "Reason must be at most 255 characters long")]
        public string Reason { get; set; } = default!;

        [JsonProperty("status")]
        [EnumDataType(typeof(EProjectAdendum), ErrorMessage = "Status must be one of: Request, Approve, Reject")]
        public EProjectAdendum Status { get; set; }

        [JsonProperty("active")]
        [RegularExpression("^[YN]$", ErrorMessage = "Active must be Y or N")]
        public string Active { get; set; } = "Y";
    }
}