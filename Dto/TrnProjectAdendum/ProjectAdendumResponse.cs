using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Dto.TrnProjectTimeline;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectAdendum
{
    public class ProjectAdendumResponse

    {
        [JsonProperty("adendum_no")]
        public string AdendumNo { get; set; } = default!;

        [JsonProperty("type_adendum")]
        public string TypeAdendum { get; set; } = string.Empty;

        [JsonProperty("wbs_no")]
        public string WBSNo { get; set; } = default!;

        [JsonProperty("cost_before")]
        public double CostBefore { get; set; }

        [JsonProperty("cost_after")]
        public double CostAfter { get; set; }

        [JsonProperty("date_before")]
        [DataType(DataType.DateTime)]
        public DateTime DateBefore { get; set; }

        [JsonProperty("date_after")]
        [DataType(DataType.DateTime)]
        public DateTime DateAfter { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; } = default!;

        [JsonProperty("status")]
        [EnumDataType(typeof(EProjectAdendum), ErrorMessage = "Status must be one of: Request, Approve, Reject")]
        public EProjectAdendum Status { get; set; }

        [JsonProperty("active")]
        public string Active { get; set; } = "Y";

        [JsonProperty("project")]
        public virtual ProjectSimpleResponse? TrnProject { get; set; }

        [JsonProperty("project_timeline")]
        public virtual ProjectTimelineSimpleResponse? TrnProjectTimeline { get; set; } = default!;
    }

    public class ProjectAdendumSimpleResponse
    {
        [JsonProperty("adendum_no")]
        public string AdendumNo { get; set; } = default!;

        [JsonProperty("type_adendum")]
        public string TypeAdendum { get; set; } = string.Empty;

        [JsonProperty("reason")]
        public string Reason { get; set; } = default!;
    }
}