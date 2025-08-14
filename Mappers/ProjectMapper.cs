using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Mappers
{
    public static class ProjectMapper
    {
        public static ProjectResponse ToProjectResponses(this TrnProject model)
        {
            return new ProjectResponse
            {
                ProjectDef = model.ProjectDef,
                ProjectDesc = model.ProjectDesc,
                NoSPMK = model.NoSPMK,
                NoContract = model.NoContract,
                CompanyCode = model.CompanyCode,
                FiscalYear = model.FiscalYear,
                ProjectLocation = model.ProjectLocation,
                PaymentMethod = model.PaymentMethod,
                ContractValue = model.ContractValue,
                Bank = model.Bank,
                ProjectOwner = model.ProjectOwner,
                AccountNumber = model.AccountNumber,
                AccountName = model.AccountName,
                Active = model.Active,
                WorkingMethod = model.WorkingMethod,
                PPH = model.PPH,
                StartDateSPMK = model.StartDateSPMK,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                PlanPersentage = model.PlanPersentage,
                ActualPersentage = model.ActualPersentage,
                ProgressReport = model.ProgressReport,
                Status = model.Status.ToString(),
                MstUnitProject = model.MstUnitProject.ToUnitProjectSimpleResponse(),
                MstProjectManager = model.MstProjectManager.ToProjectManagerResponses()
            };
        }

        public static ProjectSimpleResponse ToProjectSimpleResponses(this TrnProject model)
        {
            return new ProjectSimpleResponse
            {
                ProjectDef = model.ProjectDef,
                ProjectDesc = model.ProjectDesc,
                ProjectLocation = model.ProjectLocation,
                ProjectOwner = model.ProjectOwner
            };
        }

        public static TrnProject ToProjectFromRequest(this ProjectRequestDto request)
        {
            return new TrnProject
            {
                ProjectDef = request.ProjectDef,
                NoSPMK = request.NoSPMK,
                ProjectOwner = request.ProjectOwner,
                NoContract = request.NoContract,
                ProjectProfile = request.UnitProject,
                ProjectResponsible = request.PMProject,
                PaymentMethod = request.PaymentMethod,
                ContractValue = request.ContractValue,
                Bank = request.Bank,
                AccountNumber = request.AccountNumber,
                AccountName = request.AccountName,
                WorkingMethod = request.WorkingMethod,
                PPH = request.PPH,
                Active = request.Active,
                StartDateSPMK = request.StartDateSPMK,
                PlanPersentage = request.PlanPersentage,
                ActualPersentage = request.ActualPersentage,
                ProgressReport = request.ProgressReport,
            };
        }


    }
}