using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Interfaces.MasterProjectManager
{
    public interface IMstProjectManagerRepository
    {
        Task<IEnumerable<MstProjectManager>> GetAllAsync();
        Task<MstProjectManager?> GetByNippAsync(string nipp);
        Task<MstProjectManager> CreateAsync(MstProjectManager model);
        Task<MstProjectManager> UpdateAsync(MstProjectManager model);
    }
}