using KAPMProjectManagementApi.Dto.TrnProjectReport;

namespace KAPMProjectManagementApi.Interfaces.TrnProjectReport
{
    public interface ITrnProjectReportService
    {
        Task<IEnumerable<ProjectReportSimpleResponse>> GetAllProjectReportAsync();
        Task<ProjectReportResponse?> GetProjectReportByWeekNoAsync(string weekNo);
        Task<ProjectReportSimpleResponse> CreateProjectReportAsync(ProjectReportRequestDto reuqest);
        Task<ProjectReportSimpleResponse> UpdateProjectReportAsync(ProjectReportRequestDto reuqest);
    }
}