using KAPMProjectManagementApi.Dto.TrnProjectTimeline;

namespace KAPMProjectManagementApi.Interfaces.TrnProjectTimeline
{
    public interface ITrnProjectTimelineService
    {
        Task<IEnumerable<ProjectTimelineSimpleResponse>> GetAllProjectTimelineAsync();
        Task<ProjectTimelineResponse> GetProjectTimelineByWBSElementAsync(string wbsElement);
        Task<ProjectTimelineSimpleResponse> CreateProjectTimelineAsync(ProjectTimelineRequestDto request);
        Task<ProjectTimelineSimpleResponse> UpdateProjectTimelineAsync(ProjectTimelineRequestDto request);
    }
}