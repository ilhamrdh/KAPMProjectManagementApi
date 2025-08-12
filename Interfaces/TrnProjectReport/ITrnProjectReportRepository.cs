namespace KAPMProjectManagementApi.Interfaces.TrnProjectReport
{
    public interface ITrnProjectReportRepository
    {
        Task<bool> ExistsAsync(string weekno);
        Task<IEnumerable<Models.TrnProjectReport>> GetAllAsync();
        Task<Models.TrnProjectReport?> GetByWeekNoAsync(string weekNo);
        Task<Models.TrnProjectReport> CreateAsync(Models.TrnProjectReport model);
        Task<Models.TrnProjectReport> UpdateAsync(Models.TrnProjectReport model);
    }
}