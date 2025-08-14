using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectTimeline
{
    public class ProjectTimelineResponse
    {
        public int Id { get; set; }
        [JsonProperty("wbs_element")]
        public string WBSElement { get; set; } = default!;
        [JsonProperty("wbs_level")]
        public int WBSLevel { get; set; } = default!;
        [JsonProperty("wbs_desc")]
        public string WBSDesc { get; set; } = string.Empty;
        [JsonProperty("responsible")]
        public string Responsible { get; set; } = string.Empty;
        [JsonProperty("status")]
        public string Status { get; set; } = "";

        [JsonProperty("active")]
        public string Active { get; set; } = "Y";
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }
        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }
        [JsonProperty("project")]
        public ProjectResponse? TrnProject { get; set; }

        // public virtual ICollection<TrnProjectReportDtl> TrnProjectReportDtls { get; set; } = new List<TrnProjectReportDtl>();
        // public virtual ICollection<TrnProjectAdendum> TrnProjectAdendums { get; set; } = new List<TrnProjectAdendum>();
    }

    public class ProjectTimelineSimpleResponse
    {
        public int Id { get; set; }
        [JsonProperty("wbs_element")]
        public string WBSElement { get; set; } = default!;
        [JsonProperty("wbs_level")]
        public int WBSLevel { get; set; } = default!;
        [JsonProperty("wbs_desc")]
        public string WBSDesc { get; set; } = string.Empty;
        [JsonProperty("responsible")]
        public string Responsible { get; set; } = string.Empty;
    }
}