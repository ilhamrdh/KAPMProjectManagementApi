using System.ComponentModel;
using KAPMProjectManagementApi.Dto.TrnProject;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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

        [JsonProperty("user_add")]
        public string UserAdd { get; set; } = string.Empty;

        [JsonProperty("date_add")]
        public DateTime DateAdd { get; set; }

        [JsonProperty("user_update")]
        public string? UserUpdate { get; set; }

        [JsonProperty("date_update")]
        public DateTime? DateUpdate { get; set; }

        [JsonProperty("projects")]
        public List<ProjectResponse> Projects { get; set; } = new List<ProjectResponse>();
    }

    public class UnitProjectSimpleResponse
    {
        [JsonProperty("unit_project")]
        public string UnitProject { get; set; } = default!;

        [JsonProperty("unit_desc")]
        public string UnitDesc { get; set; } = string.Empty;
    }
}