using KAPMProjectManagementApi.Dto.MstUnitProject;
using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Mappers
{
    public static class UnitProjectMapper
    {
        // public static UnitProjectResponse ToUnitProjectResponses(this MstUnitProject model)
        // {
        //     return new UnitProjectResponse
        //     {
        //         UnitProject = model.UnitProject,
        //         UnitDesc = model.UnitDesc,
        //     };
        // }
        public static UnitProjectResponse ToUnitProjectResponses(this MstUnitProject model)
        {
            return new UnitProjectResponse
            {
                UnitProject = model.UnitProject,
                UnitDesc = model.UnitDesc,
                Active = model.Active,
                UserAdd = model.UserAdd,
                DateAdd = model.DateAdd,
                UserUpdate = model.UserUpdate,
                DateUpdate = model.DateUpdate,
                Projects = model.TrnProjects.Select(p => new ProjectResponse
                {
                    CodeProject = p.CodeProject,
                    DescProject = p.DescProject,
                    AccountName = p.AccountName,
                    AccountNumber = p.AccountNumber,
                    ActualPersentage = p.ActualPersentage,
                    Bank = p.Bank,
                    ContractValue = p.ContractValue,
                    FinishDate = p.FinishDate,
                    NoContract = p.NoContract,
                    NoSPMK = p.NoSPMK,
                    PaymentMethod = p.PaymentMethod,
                    PlanPersentage = p.PlanPersentage,
                    PMProject = p.PMProject,
                    ProgressReport = p.ProgressReport,
                    StartDate = p.StartDate,
                    StartDateSPMK = p.StartDateSPMK,
                    UnitProject = p.UnitProject,
                    WorkingMethod = p.WorkingMethod,
                    MstProjectManager = p.MstProjectManager.ToProjectManagerResponses(),
                }).ToList()
            };
        }

        public static MstUnitProject ToUnitProjectFromRequest(this UnitProjectRequestDto request)
        {
            return new MstUnitProject
            {
                UnitProject = request.UnitProject,
                UnitDesc = request.UnitDesc,
                UserAdd = request.UserAdd,
            };
        }
    }
}