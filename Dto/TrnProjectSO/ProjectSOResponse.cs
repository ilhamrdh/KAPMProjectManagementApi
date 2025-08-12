using KAPMProjectManagementApi.Dto.MstEmployee;
using KAPMProjectManagementApi.Dto.MstRoleProject;
using KAPMProjectManagementApi.Dto.TrnProject;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectSO
{
    public class ProjectSOResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }
        [JsonProperty("finish_date")]
        public DateTime FinishDate { get; set; }
        [JsonProperty("active")]
        public string Active { get; set; } = default!;

        [JsonProperty("role_project")]
        public virtual RoleProjectSimpleResponse RoleProject { get; set; } = default!;
        [JsonProperty("employee")]
        public virtual EmployeeSimpleResponse MstEmployee { get; set; } = default!;
        [JsonProperty("project")]
        public virtual ProjectSimpleResponse TrnProject { get; set; } = default!;
    }

    public class ProjectSOSimpleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}