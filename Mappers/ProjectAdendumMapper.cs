using KAPMProjectManagementApi.Dto.TrnProjectAdendum;
using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Mappers
{
    public static class ProjectAdendumMapper
    {
        public static ProjectAdendumResponse ToProjectAdendumResponse(this TrnProjectAdendum model)
        {
            return new ProjectAdendumResponse
            {
                AdendumNo = model.AdendumNo,
                TypeAdendum = model.TypeAdendum,
                CostAfter = model.CostAfter,
                CostBefore = model.CostBefore,
                DateAfter = model.DateAfter,
                DateBefore = model.DateBefore,
                Reason = model.Reason,
                Status = model.Status,
                Active = model.Active,
                WBSElement = model.WBSElement,
                TrnProject = model.TrnProject?.ToProjectSimpleResponses(),
                TrnProjectTimeline = model.TrnProjectTimeline.ToProjectTimelineSimpleResponse(),
            };
        }

        public static ProjectAdendumSimpleResponse ToProjectAdendumSimpleResponse(this TrnProjectAdendum model)
        {
            return new ProjectAdendumSimpleResponse
            {
                AdendumNo = model.AdendumNo,
                TypeAdendum = model.TypeAdendum,
                Reason = model.Reason,
            };
        }

        public static TrnProjectAdendum ToProjectAdendumFromRequest(this ProjectAdendumRequestDto request)
        {
            return new TrnProjectAdendum
            {
                AdendumNo = request.AdendumNo,
                Active = request.Active,
                ProjectDef = request.ProjectDef,
                CostAfter = request.CostAfter,
                CostBefore = request.CostBefore,
                DateAfter = request.DateAfter,
                DateBefore = request.DateBefore,
                Reason = request.Reason,
                Status = request.Status,
                TypeAdendum = request.TypeAdendum,
                WBSElement = request.WBSElement
            };
        }
    }
}