using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectTimeline
{
    public class ProjectTimelineRequestDto
    {
        [Required(ErrorMessage = "WBS No is required")]
        [StringLength(50, ErrorMessage = "WBS No cannot be longer than 50 characters")]
        [JsonProperty("wbs_no")]
        public string WBSNo { get; set; } = default!;

        [Required(ErrorMessage = "Code Project is required")]
        [StringLength(50, ErrorMessage = "Code Project cannot be longer than 50 characters")]
        [JsonProperty("code_project")]
        public string CodeProject { get; set; } = default!;

        [Required(ErrorMessage = "WBS Level is required")]
        [StringLength(50, ErrorMessage = "WBS Level cannot be longer than 50 characters")]
        [JsonProperty("wbs_level")]
        public int WBSLevel { get; set; } = default!;

        [StringLength(50, ErrorMessage = "WBS Name cannot be longer than 50 characters")]
        [JsonProperty("wbs_name")]
        public string WBSName { get; set; } = string.Empty;

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
        [JsonProperty("finish_date")]
        public DateTime FinishDate { get; set; }

    }
}