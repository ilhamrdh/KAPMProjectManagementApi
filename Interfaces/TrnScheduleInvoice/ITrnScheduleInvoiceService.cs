using KAPMProjectManagementApi.Dto.TrnScheduleInvoice;

namespace KAPMProjectManagementApi.Interfaces.TrnScheduleInvoice
{
    public interface ITrnScheduleInvoiceService
    {
        Task<IEnumerable<ScheduleInvoiceSimpleResponse>> GetAllScheduleInvoiceAsync();
        Task<ScheduleInvoiceResponse?> GetScheduleInvoiceByNoAsync(string no);
        Task<ScheduleInvoiceSimpleResponse> CreateScheduleInvoiceAsync(ScheduleInvoiceRequestDto reuqest);
        Task<ScheduleInvoiceSimpleResponse> UpdateScheduleInvoiceAsync(ScheduleInvoiceRequestDto reuqest);
    }
}