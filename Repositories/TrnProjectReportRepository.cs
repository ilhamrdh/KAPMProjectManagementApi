using KAPMProjectManagementApi.Interfaces.TrnProjectReport;
using KAPMProjectManagementApi.Models;
using KAPMProjectManagementApi.Schema;
using Microsoft.EntityFrameworkCore;

namespace KAPMProjectManagementApi.Repositories
{
    public class TrnProjectReportRepository : ITrnProjectReportRepository
    {
        private readonly ProjectManagementDBContext _context;
        public TrnProjectReportRepository(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public async Task<TrnProjectReport> CreateAsync(TrnProjectReport model)
        {
            model.DateAdd = DateTime.UtcNow;
            await _context.TrnProjectReport.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ExistsAsync(string weekno)
        {
            return await _context.TrnProjectReport.AsNoTracking().AnyAsync(x => x.WeekNo == weekno);
        }

        public async Task<IEnumerable<TrnProjectReport>> GetAllAsync()
        {
            return await _context.TrnProjectReport.ToListAsync();
        }

        public async Task<TrnProjectReport?> GetByWeekNoAsync(string weekNo)
        {
            var pr = await _context.TrnProjectReport.AsNoTracking().Include(x => x.TrnProject).Include(x => x.TrnProjectIssues).FirstOrDefaultAsync(x => x.WeekNo == weekNo);
            if (pr == null) return null;
            return pr;
        }

        public async Task<TrnProjectReport> UpdateAsync(TrnProjectReport model)
        {
            var pr = await _context.TrnProjectReport.AsNoTracking().FirstOrDefaultAsync(x => x.WeekNo == model.WeekNo);
            if (pr == null) return null!;

            pr.Deviation = model.Deviation;
            pr.CodeProject = model.CodeProject;
            pr.Active = model.Active;
            pr.ActualPersentage = model.ActualPersentage;
            pr.DateReport = model.DateReport;
            pr.PlanPersentage = model.PlanPersentage;
            pr.UserUpdate = model.UserUpdate;
            pr.DateUpdate = DateTime.UtcNow;

            _context.TrnProjectReport.Update(pr);
            await _context.SaveChangesAsync();
            return pr;
        }
    }
}