using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Dto.TrnProjectReport;
using KAPMProjectManagementApi.Dto.TrnProjectReportDetail;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectIssue
{
    public class ProjectIssueResponse
    {
        [JsonProperty("no_issue")]
        public string NoIssue { get; set; } = default!;

        [JsonProperty("project_def")]
        public string ProjectDef { get; set; } = default!;

        [JsonProperty("week_no")]
        public string WeekNo { get; set; } = default!;

        [JsonProperty("no_sr")]
        public string NoSr { get; set; } = default!;

        [JsonProperty("wbs_element")]
        public string WBSElement { get; set; } = default!;

        [JsonProperty("problem")]
        public string Problem { get; set; } = string.Empty;

        [JsonProperty("action_plan")]
        public string ActionPlan { get; set; } = string.Empty;

        [JsonProperty("action_problem")]
        public string ActionProblem { get; set; } = string.Empty;

        [JsonProperty("status")]
        public EProjectIssue Status { get; set; }

        [JsonProperty("active")]
        public string Active { get; set; } = "Y";

        [JsonProperty("user_add")]
        public string UserAdd { get; set; } = string.Empty;

        [JsonProperty("date_add")]
        [DataType(DataType.DateTime)]
        public DateTime DateAdd { get; set; }

        [JsonProperty("user_update")]
        public string UserUpdate { get; set; } = string.Empty;

        [JsonProperty("date_update")]
        [DataType(DataType.DateTime)]
        public DateTime DateUpdate { get; set; }

        [JsonProperty("project")]
        public virtual ProjectSimpleResponse TrnProject { get; set; } = default!;

        [JsonProperty("project_report")]
        public virtual ProjectReportSimpleResponse TrnProjectReport { get; set; } = default!;

        [JsonProperty("project_report_dtl")]
        public virtual ProjectReportDetailSimpleResponse TrnProjectReportDtl { get; set; } = default!;
    }

    public class ProjectIssueSimpleResponse
    {
        [JsonProperty("no_issue")]
        public string NoIssue { get; set; } = default!;

        [JsonProperty("problem")]
        public string Problem { get; set; } = string.Empty;
    }
}