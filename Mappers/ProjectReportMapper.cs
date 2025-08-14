using KAPMProjectManagementApi.Dto.TrnProjectReport;
using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Mappers
{
    public static class ProjectReportMapper
    {
        public static ProjectReportResponse ToProjectReportResponse(this TrnProjectReport model)
        {
            return new ProjectReportResponse
            {
                Id = model.Id,
                WeekNo = model.WeekNo,
                Deviation = model.Deviation,
                Active = model.Active,
                ActualPersentage = model.ActualPersentage,
                DateReport = model.DateReport,
                PlanPersentage = model.PlanPersentage,
                TrnProject = model.TrnProject.ToProjectSimpleResponses(),
                TrnProjectIssues = model.TrnProjectIssues.Select(x => x.ToProjectIssueSimpleResponse()).ToList(),
            };
        }

        public static ProjectReportSimpleResponse ToProjectReportSimpleResponse(this TrnProjectReport model)
        {
            return new ProjectReportSimpleResponse
            {
                WeekNo = model.WeekNo,
                ActualPersentage = model.ActualPersentage,
                PlanPersentage = model.PlanPersentage
            };
        }

        public static TrnProjectReport ToProjectReportFromRequest(this ProjectReportRequestDto request)
        {
            return new TrnProjectReport
            {
                WeekNo = request.WeekNo,
                Deviation = request.Deviation,
                Active = request.Active,
                ActualPersentage = request.ActualPersentage,
                ProjectDef = request.ProjectDef,
                DateReport = request.DateReport,
                PlanPersentage = request.PlanPersentage
            };
        }
    }
}