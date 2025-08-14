using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectTimeline
{
    public class ProjectTimelineRequestDto
    {
        [Required(ErrorMessage = "WBS Element is required")]
        [StringLength(50, ErrorMessage = "WBS Element cannot be longer than 50 characters")]
        [JsonProperty("wbs_element")]
        public string WBSElement { get; set; } = default!;

        [Required(ErrorMessage = "Project Def is required")]
        [StringLength(50, ErrorMessage = "Project Def cannot be longer than 50 characters")]
        [JsonProperty("project_def")]
        public string ProjectDef { get; set; } = default!;

        [Required(ErrorMessage = "WBS Level is required")]
        [StringLength(50, ErrorMessage = "WBS Level cannot be longer than 50 characters")]
        [JsonProperty("wbs_level")]
        public int WBSLevel { get; set; } = default!;

        [StringLength(50, ErrorMessage = "WBS Desc cannot be longer than 50 characters")]
        [JsonProperty("wbs_desc")]
        public string WBSDesc { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Project Name cannot be longer than 50 characters")]
        [JsonProperty("responsible")]
        public string Responsible { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        [EnumDataType(typeof(EProjectTimeline), ErrorMessage = "Status must be one of: Waiting, On Progress, Done")]
        public EProjectTimeline Status { get; set; }

        [StringLength(1, ErrorMessage = "Active must be 1 character")]
        [RegularExpression("^[YN]$", ErrorMessage = "Active must be Y or N")]
        public string Active { get; set; } = "Y";

        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.DateTime)]
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

    }
}