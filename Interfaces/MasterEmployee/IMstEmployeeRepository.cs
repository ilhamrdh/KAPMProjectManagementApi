using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Interfaces.MasterEmployee
{
    public interface IMstEmployeeRepository
    {
        Task<bool> ExistsAsync(string nipp);
        Task<IEnumerable<MstEmployee>> GetAllAsync();
        Task<MstEmployee?> GetByNippAsync(string nipp);
        Task<MstEmployee> CreateAsync(MstEmployee model);
        Task<MstEmployee> UpdateAsync(MstEmployee model);
    }
}