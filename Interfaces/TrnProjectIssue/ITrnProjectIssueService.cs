using KAPMProjectManagementApi.Dto.TrnProjectIssue;

namespace KAPMProjectManagementApi.Interfaces.TrnProjectIssue
{
    public interface ITrnProjectIssueService
    {
        Task<IEnumerable<ProjectIssueSimpleResponse>> GetAllProjectIssueAsync();
        Task<ProjectIssueResponse?> GetProjectIssueByNoIssueAsync(string noIssue);
        Task<ProjectIssueSimpleResponse> CreateProjectIssueAsync(ProjectIssueRequestDto reuqest);
        Task<ProjectIssueSimpleResponse> UpdateProjectIssueAsync(ProjectIssueRequestDto reuqest);
    }
}