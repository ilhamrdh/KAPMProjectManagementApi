namespace KAPMProjectManagementApi.Interfaces.TrnScheduleInvoice
{
    public interface ITrnScheduleInvoiceRepository
    {
        Task<bool> ExistsAsync(string no);
        Task<IEnumerable<Models.TrnScheduleInvoice>> GetAllAsync();
        Task<Models.TrnScheduleInvoice?> GetByNoAsync(string no);
        Task<Models.TrnScheduleInvoice> CreateAsync(Models.TrnScheduleInvoice model);
        Task<Models.TrnScheduleInvoice> UpdateAsync(Models.TrnScheduleInvoice model);
    }
}