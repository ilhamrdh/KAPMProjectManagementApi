using KAPMProjectManagementApi.Dto.MstRoleProject;
using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Mappers
{
    public static class ProjectRoleMapper
    {
        public static RoleProjectResponse ToRoleProjectResponses(this MstRoleProject model)
        {
            return new RoleProjectResponse
            {
                RoleId = model.RoleId,
                Active = model.Active,
                RoleName = model.RoleName,
                RoleType = model.RoleType.ToString(),
            };
        }

        public static RoleProjectSimpleResponse ToRoleProjectSimpleResponse(this MstRoleProject model)
        {
            return new RoleProjectSimpleResponse
            {
                RoleName = model.RoleName,
                RoleType = model.RoleType.ToString(),
            };
        }

        public static MstRoleProject ToRoleProjectFromRequest(this RoleProjectRequestDto model)
        {
            return new MstRoleProject
            {
                RoleName = model.RoleName,
                RoleType = model.RoleType,
                Active = model.Active,
            };
        }
    }
}