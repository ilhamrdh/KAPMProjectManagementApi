
namespace KAPMProjectManagementApi.Interfaces.TrnProject
{
    public interface ITrnProjectRepository
    {
        Task<bool> ExistsAsync(string codeProject);
        Task<IEnumerable<Models.TrnProject>> GetAllAsync();
        Task<Models.TrnProject?> GetByCodeProjectAsync(string codeProject);
        Task<Models.TrnProject> CreateAsync(Models.TrnProject model);
        Task<Models.TrnProject> UpdateAsync(Models.TrnProject model);
    }
}