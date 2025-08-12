namespace KAPMProjectManagementApi.Interfaces.TrnProjectSO
{
    public interface ITrnProjectSORepository
    {
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Models.TrnProjectSO>> GetAllAsync();
        Task<Models.TrnProjectSO?> GetByIdAsync(int id);
        Task<Models.TrnProjectSO> CreateAsync(Models.TrnProjectSO model);
        Task<Models.TrnProjectSO> UpdateAsync(Models.TrnProjectSO model);
    }
}