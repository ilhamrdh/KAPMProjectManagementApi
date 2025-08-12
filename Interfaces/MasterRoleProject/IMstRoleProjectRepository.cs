using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Interfaces.MasterRoleProject
{
    public interface IMstRoleProjectRepository
    {
        Task<bool> ExistsAsync(string roleid);
        Task<IEnumerable<MstRoleProject>> GetAllAsync();
        Task<MstRoleProject?> GetByRoleIdAsync(string roleid);
        Task<MstRoleProject> CreateAsync(MstRoleProject model);
        Task<MstRoleProject> UpdateAsync(MstRoleProject model);
    }
}