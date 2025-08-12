namespace KAPMProjectManagementApi.Interfaces.TrnProjectAdendum
{
    public interface ITrnProjectAdendumRepository
    {
        Task<bool> ExistsAsync(string adendumNo);
        Task<IEnumerable<Models.TrnProjectAdendum>> GetAllAsync();
        Task<Models.TrnProjectAdendum?> GetByAdendumNoAsync(string adendumNo);
        Task<Models.TrnProjectAdendum> CreateAsync(Models.TrnProjectAdendum model);
        Task<Models.TrnProjectAdendum> UpdateAsync(Models.TrnProjectAdendum model);
    }
}