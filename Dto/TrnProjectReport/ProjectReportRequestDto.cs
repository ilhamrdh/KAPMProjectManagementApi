using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectReport
{
    public class ProjectReportRequestDto
    {
        [Required(ErrorMessage = "WeekNo is required")]
        [JsonProperty("week_no")]
        public string WeekNo { get; set; } = default!;

        [Required(ErrorMessage = "CodeProject is required")]
        [StringLength(50, ErrorMessage = "CodeProject must be 50 characters")]
        [JsonProperty("code_project")]
        public string CodeProject { get; set; } = default!; // FK to trn_project

        [Required(ErrorMessage = "DateReport is required")]
        [DataType(DataType.DateTime)]
        [JsonProperty("date_report")]
        public DateTime DateReport { get; set; }

        [JsonProperty("plan_persentage")]
        [Range(0, 100, ErrorMessage = "PlanPersentage must be between 0 and 100")]
        public double PlanPersentage { get; set; }

        [Range(0, 100, ErrorMessage = "ActualPersentage must be between 0 and 100")]
        [JsonProperty("actual_persentage")]
        public double ActualPersentage { get; set; }

        [JsonProperty("deviation")]
        [EnumDataType(typeof(EProjectStatus), ErrorMessage = "Status must be one of: Positive, Negative")]
        public ETypeDeviation Deviation { get; set; }

        [StringLength(1, ErrorMessage = "Active must be 1 character")]
        [RegularExpression("^[YN]$", ErrorMessage = "Active must be Y or N")]
        [JsonProperty("active")]
        public string Active { get; set; } = "Y";
    }
}