namespace KAPMProjectManagementApi.Interfaces.TrnProjectReportDtl
{
    public interface ITrnProjectReportDtlRepository
    {
        Task<bool> ExistsAsync(string noSr);
        Task<IEnumerable<Models.TrnProjectReportDtl>> GetAllAsync();
        Task<Models.TrnProjectReportDtl?> GetByNoSrAsync(string noSr);
        Task<Models.TrnProjectReportDtl> CreateAsync(Models.TrnProjectReportDtl model);
        Task<Models.TrnProjectReportDtl> UpdateAsync(Models.TrnProjectReportDtl model);
    }
}