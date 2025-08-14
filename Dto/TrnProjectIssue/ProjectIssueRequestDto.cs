using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectIssue
{
    public class ProjectIssueRequestDto
    {
        [JsonProperty("no_issue")]
        [Required]
        [StringLength(50, ErrorMessage = "No Issue must be at most 50 characters long.")]
        public string NoIssue { get; set; } = default!;

        [JsonProperty("project_def")]
        [Required(ErrorMessage = "Project Def is required")]
        [StringLength(50, ErrorMessage = "Project Def must be at most 50 characters long.")]
        public string ProjectDef { get; set; } = default!;

        [JsonProperty("week_no")]
        [Required(ErrorMessage = "Week No is required")]
        [StringLength(50, ErrorMessage = "Week No must be at most 50 characters long.")]
        public string WeekNo { get; set; } = default!;

        [JsonProperty("no_sr")]
        [Required(ErrorMessage = "No Sr is required")]
        [StringLength(50, ErrorMessage = "No Sr must be at most 50 characters long.")]
        public string NoSr { get; set; } = default!;

        [JsonProperty("wbs_element")]
        [Required(ErrorMessage = "wbs element is required")]
        [StringLength(50, ErrorMessage = "wbs element must be at most 50 characters long.")]
        public string WBSElement { get; set; } = default!;

        [JsonProperty("problem")]
        [Required(ErrorMessage = "Problem is required")]
        [StringLength(255, ErrorMessage = "Problem must be at most 255 characters long.")]
        public string Problem { get; set; } = string.Empty;

        [JsonProperty("action_plan")]
        [Required(ErrorMessage = "Action Plan is required")]
        [StringLength(255, ErrorMessage = "Action Plan must be at most 255 characters long.")]
        public string ActionPlan { get; set; } = string.Empty;

        [JsonProperty("action_problem")]
        [Required(ErrorMessage = "Action Problem is required")]
        [StringLength(255, ErrorMessage = "Action Problem must be at most 255 characters long.")]
        public string ActionProblem { get; set; } = string.Empty;

        [JsonProperty("status")]
        [EnumDataType(typeof(EProjectIssue), ErrorMessage = "Status must be one of: Solved, Waiting")]
        public EProjectIssue Status { get; set; }

        [JsonProperty("active")]
        [RegularExpression("^[YN]$", ErrorMessage = "Active must be Y or N")]
        public string Active { get; set; } = "Y";
    }
}