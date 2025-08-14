
using KAPMProjectManagementApi.Dto.Web;

namespace KAPMProjectManagementApi.Interfaces.TrnProject
{
    public interface ITrnProjectRepository
    {
        Task<bool> ExistsAsync(string projectDef);
        Task<IEnumerable<Models.TrnProject>> GetAllAsync(QuerySearch qs);
        Task<Models.TrnProject?> GetByProjectDefAsync(string projectDef);
        Task<Models.TrnProject> CreateAsync(Models.TrnProject model);
        Task<Models.TrnProject> UpdateAsync(Models.TrnProject model);
    }
}