using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Interfaces.MasterUnitProject
{
    public interface IMstUnitProjectRepository
    {
        Task<bool> ExistsAsync(string unitCode);
        Task<IEnumerable<MstUnitProject>> GetAllAsync();
        Task<MstUnitProject?> GetByUnitProjectAsync(string unitCode);
        Task<MstUnitProject> CreateAsync(MstUnitProject model);
        Task<MstUnitProject> UpdateAsync(MstUnitProject model);
    }
}