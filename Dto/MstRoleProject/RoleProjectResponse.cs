using System.Text.Json.Serialization;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.MstRoleProject
{
    public class RoleProjectResponse
    {
        [JsonProperty("role_id")]
        public string RoleId { get; set; } = default!;

        [JsonProperty("role_type")]
        public string RoleType { get; set; } = string.Empty;

        [JsonProperty("role_name")]
        public string RoleName { get; set; } = default!;

        [JsonProperty("active")]
        public string Active { get; set; } = default!;
    }

    public class RoleProjectSimpleResponse
    {
        [JsonProperty("role_type")]
        public string RoleType { get; set; } = string.Empty;

        [JsonProperty("role_name")]
        public string RoleName { get; set; } = default!;
    }
}