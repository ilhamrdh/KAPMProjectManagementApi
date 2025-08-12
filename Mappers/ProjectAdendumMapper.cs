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
                WBSNo = model.WBSNo,
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

        public static TrnProjectAdendum ToProjectAdendumFromRequest(this ProjectAdendumRequestDto model)
        {
            return new TrnProjectAdendum
            {
                AdendumNo = model.AdendumNo,
                Active = model.Active,
                CodeProject = model.CodeProject,
                CostAfter = model.CostAfter,
                CostBefore = model.CostBefore,
                DateAfter = model.DateAfter,
                DateBefore = model.DateBefore,
                Reason = model.Reason,
                Status = model.Status,
                TypeAdendum = model.TypeAdendum,
                WBSNo = model.WBSNo
            };
        }
    }
}