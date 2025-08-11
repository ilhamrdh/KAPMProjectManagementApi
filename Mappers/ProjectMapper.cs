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
                CodeProject = model.CodeProject,
                DescProject = model.DescProject,
                NoSPMK = model.NoSPMK,
                NoContract = model.NoContract,
                PaymentMethod = model.PaymentMethod,
                ContractValue = model.ContractValue,
                Bank = model.Bank,
                AccountNumber = model.AccountNumber,
                AccountName = model.AccountName,
                WorkingMethod = model.WorkingMethod,
                PPH = model.PPH,
                StartDateSPMK = model.StartDateSPMK,
                StartDate = model.StartDate,
                FinishDate = model.FinishDate,
                PlanPersentage = model.PlanPersentage,
                ActualPersentage = model.ActualPersentage,
                ProgressReport = model.ProgressReport,
                Status = model.Status,
                MstUnitProject = model.MstUnitProject.ToUnitProjectSimpleResponse(),
                MstProjectManager = model.MstProjectManager.ToProjectManagerResponses()
            };
        }

        public static TrnProject ToProjectFromRequest(this ProjectRequestDto request)
        {
            return new TrnProject
            {
                CodeProject = request.CodeProject,
                DescProject = request.DescProject,
                NoSPMK = request.NoSPMK,
                NoContract = request.NoContract,
                UnitProject = request.UnitProject,
                PMProject = request.PMProject,
                PaymentMethod = request.PaymentMethod,
                ContractValue = request.ContractValue,
                Bank = request.Bank,
                AccountNumber = request.AccountNumber,
                AccountName = request.AccountName,
                WorkingMethod = request.WorkingMethod,
                PPH = request.PPH,
                StartDateSPMK = request.StartDateSPMK,
                StartDate = request.StartDate,
                FinishDate = request.FinishDate,
                PlanPersentage = request.PlanPersentage,
                ActualPersentage = request.ActualPersentage,
                ProgressReport = request.ProgressReport,
                UserAdd = request.UserAdd,
            };
        }


    }
}