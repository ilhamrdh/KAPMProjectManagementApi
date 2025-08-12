using KAPMProjectManagementApi.Dto.TrnProjectTimeline;

namespace KAPMProjectManagementApi.Interfaces.TrnProjectTimeline
{
    public interface ITrnProjectTimelineService
    {
        Task<IEnumerable<ProjectTimelineSimpleResponse>> GetAllProjectTimelineAsync();
        Task<ProjectTimelineResponse> GetProjectTimelineByNoWBSAsync(string wbsno);
        Task<ProjectTimelineSimpleResponse> CreateProjectTimelineAsync(ProjectTimelineRequestDto request);
        Task<ProjectTimelineSimpleResponse> UpdateProjectTimelineAsync(ProjectTimelineRequestDto request);
    }
}