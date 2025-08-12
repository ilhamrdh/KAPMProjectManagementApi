using KAPMProjectManagementApi.Dto.MstRoleProject;

namespace KAPMProjectManagementApi.Interfaces.MasterRoleProject
{
    public interface IMstRoleProjectService
    {
        Task<IEnumerable<RoleProjectSimpleResponse>> GetAllRoleProjectAsync();
        Task<RoleProjectResponse?> GetRoleProjectByRoleIdAsync(string role1d);
        Task<RoleProjectSimpleResponse> CreateRoleProjectAsync(RoleProjectRequestDto reuqest);
        Task<RoleProjectSimpleResponse> UpdateRoleProjectAsync(RoleProjectRequestDto reuqest);
    }
}