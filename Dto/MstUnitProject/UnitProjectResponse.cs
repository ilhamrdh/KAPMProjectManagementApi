using KAPMProjectManagementApi.Dto.TrnProject;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.MstUnitProject
{
    public class UnitProjectResponse
    {

        [JsonProperty("unit_project")]
        public string UnitProject { get; set; } = default!;

        [JsonProperty("unit_desc")]
        public string UnitDesc { get; set; } = string.Empty;

        [JsonProperty("active")]
        public string Active { get; set; } = string.Empty;

        [JsonProperty("projects")]
        public List<ProjectSimpleResponse> Projects { get; set; } = new List<ProjectSimpleResponse>();
    }

    public class UnitProjectSimpleResponse
    {
        [JsonProperty("unit_project")]
        public string UnitProject { get; set; } = default!;

        [JsonProperty("unit_desc")]
        public string UnitDesc { get; set; } = string.Empty;
    }
}