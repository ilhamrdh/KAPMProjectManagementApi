using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Dto.TrnProjectIssue;
using KAPMProjectManagementApi.Dto.TrnProjectReport;
using KAPMProjectManagementApi.Dto.TrnProjectTimeline;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectReportDetail
{
    public class ProjectReportDetailResponse
    {
        [JsonProperty("no_sr")]
        public string NoSr { get; set; } = default!;

        [JsonProperty("week_no")]
        public string WeekNo { get; set; } = default!;

        [JsonProperty("wbs_no")]
        public string WBSNo { get; set; } = default!;

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
        public string Active { get; set; } = string.Empty;

        [JsonProperty("project")]
        public virtual ProjectSimpleResponse TrnProject { get; set; } = default!;

        [JsonProperty("project_report")]
        public virtual ProjectReportSimpleResponse TrnProjectReport { get; set; } = default!;

        [JsonProperty("project_timeline")]
        public virtual ProjectTimelineSimpleResponse TrnProjectTimeline { get; set; } = default!;

        [JsonProperty("project_issues")]
        public virtual ICollection<ProjectIssueSimpleResponse> TrnProjectIssues { get; set; } = new List<ProjectIssueSimpleResponse>();
    }

    public class ProjectReportDetailSimpleResponse
    {
        [JsonProperty("no_sr")]
        public string NoSr { get; set; } = default!;
    }
}