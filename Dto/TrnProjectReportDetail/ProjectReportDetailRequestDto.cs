using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectReportDetail
{
    public class ProjectReportDetailRequestDto
    {
        [JsonProperty("no_sr")]
        [Required(ErrorMessage = "no_sr is required")]
        [StringLength(50, ErrorMessage = "no_sr must be 50 characters")]
        public string NoSr { get; set; } = default!;

        [JsonProperty("week_no")]
        [Required(ErrorMessage = "week_no is required")]
        [StringLength(50, ErrorMessage = "week_no must be 50 characters")]
        public string WeekNo { get; set; } = default!;

        [JsonProperty("project_def")]
        [Required(ErrorMessage = "Project Def is required")]
        [StringLength(50, ErrorMessage = "Project Def must be 50 characters")]
        public string ProjectDef { get; set; } = default!;

        [JsonProperty("wbs_element")]
        [Required(ErrorMessage = "wbs_element is required")]
        [StringLength(50, ErrorMessage = "wbs_element must be 50 characters")]
        public string WBSElement { get; set; } = default!;

        [Required(ErrorMessage = "plan_date is required")]
        [JsonProperty("plan_date")]
        [DataType(DataType.DateTime)]
        public DateTime PlanDate { get; set; }

        [JsonProperty("actual_date")]
        [DataType(DataType.DateTime)]
        public DateTime ActualDate { get; set; }

        [JsonProperty("status")]
        [EnumDataType(typeof(EProjectReportDtl), ErrorMessage = "Status must be one of: OnProgress, Done")]
        public EProjectReportDtl Status { get; set; }

        [JsonProperty("active")]
        [RegularExpression("^[YN]$", ErrorMessage = "Active must be Y or N")]
        public string Active { get; set; } = string.Empty;
    }
}