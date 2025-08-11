using KAPMProjectManagementApi.Dto.TrnProjectTimeline;
using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Mappers
{
    public static class ProjectTimelineMapper
    {
        public static ProjectTimelineResponse ToProjectTimelineResponse(this TrnProjectTimeline model)
        {
            return new ProjectTimelineResponse
            {
                WBSNo = model.WBSNo,
                WBSName = model.WBSName,
                WBSLevel = model.WBSLevel,
                Responsible = model.Responsible,
                Status = model.Status,
                StartDate = model.StartDate,
                FinishDate = model.FinishDate,
                CodeProject = model.CodeProject,
                TrnProject = model.TrnProject?.ToProjectResponses(),

            };
        }

        public static TrnProjectTimeline ToProjectTimelineFromRequest(this ProjectTimelineRequestDto request)
        {
            return new TrnProjectTimeline
            {
                WBSNo = request.WBSNo,
                WBSName = request.WBSName,
                WBSLevel = request.WBSLevel,
                StartDate = request.StartDate,
                FinishDate = request.FinishDate,
                CodeProject = request.CodeProject,
                Responsible = request.Responsible,
                Status = request.Status,
                Active = request.Active,

            };
        }
    }
}