using KAPMProjectManagementApi.Dto.TrnProjectSO;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.MstEmployee
{
    public class EmployeeResponse
    {
        public string Nipp { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Grade { get; set; } = string.Empty;
        public string Plans { get; set; } = string.Empty;
        public string Orgeh { get; set; } = string.Empty;
        public string Persa { get; set; } = string.Empty;
        public string Active { get; set; } = string.Empty;

        [JsonProperty("project_structure_organization")]
        public virtual ProjectSOSimpleResponse ProjectSO { get; set; } = default!;
    }

    public class EmployeeSimpleResponse
    {
        public string Nipp { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Grade { get; set; } = string.Empty;
        public string Plans { get; set; } = string.Empty;
        public string Orgeh { get; set; } = string.Empty;
        public string Persa { get; set; } = string.Empty;

    }
}