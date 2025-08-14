using KAPMProjectManagementApi.Dto.TrnProjectReportDetail;
using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Mappers
{
    public static class ProjectReportDetailMapper
    {
        public static ProjectReportDetailResponse ToProjectReportDetailResponse(this TrnProjectReportDtl model)
        {
            return new ProjectReportDetailResponse
            {
                NoSr = model.NoSr,
                Active = model.Active,
                ActualDate = model.ActualDate,
                PlanDate = model.PlanDate,
                Status = model.Status,
                TrnProject = model.TrnProject.ToProjectSimpleResponses(),
                TrnProjectTimeline = model.TrnProjectTimeline.ToProjectTimelineSimpleResponse(),
                TrnProjectReport = model.TrnProjectReport.ToProjectReportSimpleResponse(),
                TrnProjectIssues = model.TrnProjectIssues.Select(x => x.ToProjectIssueSimpleResponse()).ToList(),

            };
        }

        public static ProjectReportDetailSimpleResponse ToProjectReportDetailSimpleResponse(this TrnProjectReportDtl model)
        {
            return new ProjectReportDetailSimpleResponse
            {
                NoSr = model.NoSr
            };
        }

        public static TrnProjectReportDtl ToProjectReportDetailFromRequest(this ProjectReportDetailRequestDto model)
        {
            return new TrnProjectReportDtl
            {
                NoSr = model.NoSr,
                Active = model.Active,
                ActualDate = model.ActualDate,
                PlanDate = model.PlanDate,
                Status = model.Status,
                ProjectDef = model.ProjectDef,
                WBSElement = model.WBSElement,
                WeekNo = model.WeekNo,
            };
        }
    }
}