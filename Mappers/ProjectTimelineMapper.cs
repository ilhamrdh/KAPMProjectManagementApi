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
                WBSElement = model.WBSElement,
                WBSDesc = model.WBSDesc,
                WBSLevel = model.WBSLevel,
                Responsible = model.Responsible,
                Active = model.Active,
                Status = model.Status.ToString(),
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                TrnProject = model.TrnProject?.ToProjectResponses(),

            };
        }

        public static ProjectTimelineSimpleResponse ToProjectTimelineSimpleResponse(this TrnProjectTimeline model)
        {
            return new ProjectTimelineSimpleResponse
            {
                WBSElement = model.WBSElement,
                WBSDesc = model.WBSDesc,
                WBSLevel = model.WBSLevel,
                Id = model.Id,
                Responsible = model.Responsible,
            };
        }

        public static TrnProjectTimeline ToProjectTimelineFromRequest(this ProjectTimelineRequestDto request)
        {
            return new TrnProjectTimeline
            {
                WBSElement = request.WBSElement,
                WBSDesc = request.WBSDesc,
                WBSLevel = request.WBSLevel,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                ProjectDef = request.ProjectDef,
                Responsible = request.Responsible,
                Status = request.Status,
                Active = request.Active,

            };
        }
    }
}