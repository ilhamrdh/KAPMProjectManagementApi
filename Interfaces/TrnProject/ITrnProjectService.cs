using KAPMProjectManagementApi.Dto.TrnProject;

namespace KAPMProjectManagementApi.Interfaces.TrnProject
{
    public interface ITrnProjectService
    {
        Task<IEnumerable<ProjectResponse>> GetAllProjectAsync();
        Task<ProjectResponse?> GetProjectByProjectDefAsync(string projectDef);
        Task<ProjectResponse> CreateProjectAsync(ProjectRequestDto request);
        Task<ProjectResponse> UpdateProjectAsync(ProjectRequestDto request);
    }
}