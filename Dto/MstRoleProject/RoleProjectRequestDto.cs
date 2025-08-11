using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.MstRoleProject
{
    public class RoleProjectRequestDto
    {
        [Required(ErrorMessage = "Role ID is required")]
        [StringLength(50, ErrorMessage = "Role ID cannot be longer than 50 characters")]
        [JsonProperty("role_id")]
        public string RoleId { get; set; } = default!;

        [Required(ErrorMessage = "Role Type is required")]
        [EnumDataType(typeof(EProjectRole), ErrorMessage = "Status must be one of: Admin, BOD, PMO, Unit, ProjectManager, Consultant, SiteManager, Logistics, Security, SHE")]
        [JsonProperty("role_type")]
        public EProjectRole RoleType { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        [StringLength(50, ErrorMessage = "Role Name cannot be longer than 50 characters")]
        public string RoleName { get; set; } = default!;

        [StringLength(1, ErrorMessage = "Active must be 1 character")]
        [RegularExpression("^[YN]$", ErrorMessage = "Active must be Y or N")]
        public string Active { get; set; } = "Y";
    }
}