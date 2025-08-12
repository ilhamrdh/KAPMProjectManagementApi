using KAPMProjectManagementApi.Dto.TrnScheduleInvoice;
using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Mappers
{
    public static class ScheduleInvoiceMapper
    {
        public static ScheduleInvoiceResponse ToScheduleInvoiceResponse(this TrnScheduleInvoice model)
        {
            return new ScheduleInvoiceResponse
            {
                CodeProject = model.CodeProject,
                DateActual = model.DateActual,
                DatePlan = model.DatePlan,
                No = model.No,
                ProgressReport = model.ProgressReport,
                Status = model.Status,
                TotalPlan = model.TotalPlan,
                Type = model.Type,
                Active = model.Active,
                TrnProject = model.TrnProject.ToProjectSimpleResponses()
            };
        }

        public static ScheduleInvoiceSimpleResponse ToScheduleInvoiceSimpleResponse(this TrnScheduleInvoice model)
        {
            return new ScheduleInvoiceSimpleResponse
            {
                DateActual = model.DateActual,
                DatePlan = model.DatePlan,
                No = model.No,
                ProgressReport = model.ProgressReport,
                Status = model.Status,
                TotalPlan = model.TotalPlan,
                Type = model.Type,
            };
        }

        public static TrnScheduleInvoice ToScheduleInvoiceFromRequest(this ScheduleInvoiceRequestDto model)
        {
            return new TrnScheduleInvoice
            {
                No = model.No,
                CodeProject = model.CodeProject,
                DateActual = model.DateActual,
                DatePlan = model.DatePlan,
                ProgressReport = model.ProgressReport,
                Status = model.Status,
                TotalPlan = model.TotalPlan,
                Type = model.Type,
                Active = model.Active
            };
        }

    }
}