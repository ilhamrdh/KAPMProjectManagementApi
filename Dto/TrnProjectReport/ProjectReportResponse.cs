using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Dto.TrnProjectIssue;
using KAPMProjectManagementApi.Dto.TrnProjectReportDetail;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectReport
{
    public class ProjectReportResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("week_no")]
        public string WeekNo { get; set; } = default!;

        [JsonProperty("date_report")]
        public DateTime DateReport { get; set; }

        [JsonProperty("plan_persentage")]
        public double PlanPersentage { get; set; }

        [JsonProperty("actual_persentage")]
        public double ActualPersentage { get; set; }

        [JsonProperty("deviation")]
        public ETypeDeviation Deviation { get; set; }

        [JsonProperty("active")]
        public string Active { get; set; } = "Y";

        [JsonProperty("project")]
        public virtual ProjectSimpleResponse TrnProject { get; set; } = default!;

        [JsonProperty("project_issues")]
        public virtual ICollection<ProjectIssueSimpleResponse> TrnProjectIssues { get; set; } = new List<ProjectIssueSimpleResponse>();

        [JsonProperty("project_report_details")]
        public virtual ICollection<ProjectReportDetailSimpleResponse> TrnProjectReportDtls { get; set; } = new List<ProjectReportDetailSimpleResponse>();
    }

    public class ProjectReportSimpleResponse
    {
        [JsonProperty("week_no")]
        public string WeekNo { get; set; } = default!;

        [JsonProperty("date_report")]
        public DateTime DateReport { get; set; }

        [JsonProperty("plan_persentage")]
        public double PlanPersentage { get; set; }

        [JsonProperty("actual_persentage")]
        public double ActualPersentage { get; set; }
    }
}