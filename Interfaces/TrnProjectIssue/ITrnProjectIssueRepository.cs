namespace KAPMProjectManagementApi.Interfaces.TrnProjectIssue
{
    public interface ITrnProjectIssueRepository
    {
        Task<bool> ExistsAsync(string noIssue);
        Task<IEnumerable<Models.TrnProjectIssue>> GetAllAsync();
        Task<Models.TrnProjectIssue?> GetByNoIssueAsync(string noIssue);
        Task<Models.TrnProjectIssue> CreateAsync(Models.TrnProjectIssue model);
        Task<Models.TrnProjectIssue> UpdateAsync(Models.TrnProjectIssue model);
    }
}