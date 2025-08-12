using KAPMProjectManagementApi.Dto.TrnProjectAdendum;

namespace KAPMProjectManagementApi.Interfaces.TrnProjectAdendum
{
    public interface ITrnProjectAdendumService
    {
        Task<IEnumerable<ProjectAdendumSimpleResponse>> GetAllProjectAdendumAsync();
        Task<ProjectAdendumResponse?> GetProjectAdendumByAdendumNoAsync(string adendumNo);
        Task<ProjectAdendumSimpleResponse> CreateProjectAdendumAsync(ProjectAdendumRequestDto reuqest);
        Task<ProjectAdendumSimpleResponse> UpdateProjectAdendumAsync(ProjectAdendumRequestDto reuqest);
    }
}