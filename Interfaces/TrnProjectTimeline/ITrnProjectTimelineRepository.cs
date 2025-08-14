namespace KAPMProjectManagementApi.Interfaces.TrnProjectTimeline
{
    public interface ITrnProjectTimelineRepository
    {
        Task<List<Models.TrnProjectTimeline>> GetAllAsync();
        Task<Models.TrnProjectTimeline?> GetByWBSElementAsync(string wbsElement);
        Task<Models.TrnProjectTimeline> CreateAsync(Models.TrnProjectTimeline model);
        Task<Models.TrnProjectTimeline> UpdateAsync(Models.TrnProjectTimeline model);
        Task<bool> ExistsAsync(string wbsno);

    }
}