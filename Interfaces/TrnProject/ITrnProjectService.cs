using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Dto.Web;

namespace KAPMProjectManagementApi.Interfaces.TrnProject
{
    public interface ITrnProjectService
    {
        Task<IEnumerable<ProjectResponse>> GetAllProjectAsync(QuerySearch qs);
        Task<ProjectDetailResponse?> GetProjectByProjectDefAsync(string projectDef);
        Task<ProjectResponse> CreateProjectAsync(ProjectRequestDto request);
        Task<ProjectResponse> UpdateProjectAsync(ProjectRequestDto request);
    }
}