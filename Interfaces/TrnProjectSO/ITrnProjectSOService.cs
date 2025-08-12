using KAPMProjectManagementApi.Dto.TrnProjectSO;

namespace KAPMProjectManagementApi.Interfaces.TrnProjectSO
{
    public interface ITrnProjectSOService
    {
        Task<IEnumerable<ProjectSOSimpleResponse>> GetAllProjectSOAsync();
        Task<ProjectSOResponse?> GetProjectSOByIdAsync(int id);
        Task<ProjectSOSimpleResponse> CreateProjectSOAsync(ProjectSORequestCreateDto reuqest);
        Task<ProjectSOSimpleResponse> UpdateProjectSOAsync(ProjectSORequestUpdateDto reuqest);
    }
}