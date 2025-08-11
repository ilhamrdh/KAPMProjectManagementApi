using KAPMProjectManagementApi.Dto.MstProjectManager;

namespace KAPMProjectManagementApi.Interfaces.MasterProjectManager
{
    public interface IMstProjectManagerService
    {

        Task<IEnumerable<ProjectManagerResponse>> GetAllProjectManagerAsync();
        Task<ProjectManagerResponse?> GetProjectManagerByNippAsync(string nipp);
        Task<ProjectManagerResponse> CreateProjectManagerAsync(ProjectManagerReuqestDto reuqest);
        Task<ProjectManagerResponse> UpdateProjectManagerAsync(ProjectManagerReuqestDto reuqest);
    }
}