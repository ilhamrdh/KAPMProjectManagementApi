using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectTimeline
{
    public class ProjectTimelineResponse
    {
        public int Id { get; set; }
        [JsonProperty("wbs_no")]
        public string WBSNo { get; set; } = default!;
        [JsonProperty("code_project")]
        public string CodeProject { get; set; } = default!;
        [JsonProperty("wbs_level")]
        public string WBSLevel { get; set; } = default!;
        [JsonProperty("wbs_name")]
        public string WBSName { get; set; } = string.Empty;
        [JsonProperty("responsible")]
        public string Responsible { get; set; } = string.Empty;
        [JsonProperty("status")]
        public EProjectTimeline Status { get; set; }
        [JsonProperty("active")]
        public string Active { get; set; } = "Y";
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }
        [JsonProperty("finish_date")]
        public DateTime FinishDate { get; set; }
        [JsonProperty("user_add")]
        public string UserAdd { get; set; } = string.Empty;
        [JsonProperty("user_date")]
        public DateTime DateAdd { get; set; }
        [JsonProperty("user_update")]
        public string UserUpdate { get; set; } = string.Empty;
        [JsonProperty("date_update")]
        public DateTime DateUpdate { get; set; }

        [JsonProperty("project")]
        public ProjectResponse? TrnProject { get; set; }

        // public virtual ICollection<TrnProjectReportDtl> TrnProjectReportDtls { get; set; } = new List<TrnProjectReportDtl>();
        // public virtual ICollection<TrnProjectAdendum> TrnProjectAdendums { get; set; } = new List<TrnProjectAdendum>();
    }
}