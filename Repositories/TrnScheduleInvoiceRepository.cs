using KAPMProjectManagementApi.Interfaces.TrnScheduleInvoice;
using KAPMProjectManagementApi.Models;
using KAPMProjectManagementApi.Schema;
using Microsoft.EntityFrameworkCore;

namespace KAPMProjectManagementApi.Repositories
{
    public class TrnScheduleInvoiceRepository : ITrnScheduleInvoiceRepository
    {
        private readonly ProjectManagementDBContext _context;
        public TrnScheduleInvoiceRepository(ProjectManagementDBContext context)
        {
            _context = context;
        }
        public async Task<TrnScheduleInvoice> CreateAsync(TrnScheduleInvoice model)
        {
            model.DateAdd = DateTime.UtcNow;
            await _context.TrnScheduleInvoice.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ExistsAsync(string no)
        {
            return await _context.TrnScheduleInvoice.AsNoTracking().AnyAsync(x => x.No == no);
        }

        public async Task<IEnumerable<TrnScheduleInvoice>> GetAllAsync()
        {
            return await _context.TrnScheduleInvoice.ToListAsync();
        }

        public async Task<TrnScheduleInvoice?> GetByNoAsync(string no)
        {
            var si = await _context.TrnScheduleInvoice.AsNoTracking().Include(x => x.TrnProject).FirstOrDefaultAsync(x => x.No == no);
            if (si == null) return null;
            return si;
        }

        public async Task<TrnScheduleInvoice> UpdateAsync(TrnScheduleInvoice model)
        {
            var exist = await _context.TrnScheduleInvoice.AsNoTracking().FirstOrDefaultAsync(x => x.No == model.No);
            if (exist == null) return null!;

            exist.TotalPlan = model.TotalPlan;
            exist.DatePlan = model.DatePlan;
            exist.CodeProject = model.CodeProject;
            exist.Active = model.Active;
            exist.Status = model.Status;
            exist.Type = model.Type;
            exist.ProgressReport = model.ProgressReport;
            exist.DateActual = model.DateActual;
            exist.UserUpdate = model.UserUpdate;
            exist.DateUpdate = DateTime.UtcNow;

            _context.TrnScheduleInvoice.Update(exist);
            await _context.SaveChangesAsync();
            return exist;
        }
    }
}