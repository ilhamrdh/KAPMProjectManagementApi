using KAPMProjectManagementApi.Dto.TrnProjectIssue;
using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Mappers
{
    public static class ProjectIssueMapper
    {
        public static ProjectIssueResponse ToProjectIssueResponse(this TrnProjectIssue model)
        {
            return new ProjectIssueResponse
            {
                NoIssue = model.NoIssue,
                NoSr = model.NoSr,
                Active = model.Active,
                ActionPlan = model.ActionPlan,
                ActionProblem = model.ActionProblem,
                CodeProject = model.CodeProject,
                Problem = model.Problem,
                WBSNo = model.WBSNo,
                WeekNo = model.WeekNo,
                Status = model.Status,
                TrnProject = model.TrnProject.ToProjectSimpleResponses(),
                TrnProjectReport = model.TrnProjectReport.ToProjectReportSimpleResponse(),
                TrnProjectReportDtl = model.TrnProjectReportDtl.ToProjectReportDetailSimpleResponse(),
            };
        }

        public static ProjectIssueSimpleResponse ToProjectIssueSimpleResponse(this TrnProjectIssue model)
        {
            return new ProjectIssueSimpleResponse
            {
                NoIssue = model.NoIssue,
                Problem = model.Problem,
            };
        }

        public static TrnProjectIssue ToProjectIssueFromRequest(this ProjectIssueRequestDto request)
        {
            return new TrnProjectIssue
            {
                NoIssue = request.NoIssue,
                ActionPlan = request.ActionPlan,
                ActionProblem = request.ActionProblem,
                CodeProject = request.CodeProject,
                Problem = request.Problem,
                WBSNo = request.WBSNo,
                WeekNo = request.WeekNo,
                Status = request.Status,
                Active = request.Active,
                NoSr = request.NoSr
            };
        }
    }
}