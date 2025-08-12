using KAPMProjectManagementApi.Dto.TrnProjectReportDetail;

namespace KAPMProjectManagementApi.Interfaces.TrnProjectReportDtl
{
    public interface ITrnProjectReportDtlService
    {
        Task<IEnumerable<ProjectReportDetailSimpleResponse>> GetAllProjectReportDtlAsync();
        Task<ProjectReportDetailResponse?> GetProjectReportDtlByNoSrAsync(string noSr);
        Task<ProjectReportDetailSimpleResponse> CreateProjectReportDtlAsync(ProjectReportDetailRequestDto reuqest);
        Task<ProjectReportDetailSimpleResponse> UpdateProjectReportDtlAsync(ProjectReportDetailRequestDto reuqest);
    }
}