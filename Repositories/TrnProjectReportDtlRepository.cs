using KAPMProjectManagementApi.Interfaces.TrnProjectReportDtl;
using KAPMProjectManagementApi.Models;
using KAPMProjectManagementApi.Schema;
using Microsoft.EntityFrameworkCore;

namespace KAPMProjectManagementApi.Repositories
{
    public class TrnProjectReportDtlRepository : ITrnProjectReportDtlRepository
    {
        private readonly ProjectManagementDBContext _context;
        public TrnProjectReportDtlRepository(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public async Task<TrnProjectReportDtl> CreateAsync(TrnProjectReportDtl model)
        {
            model.DateAdd = DateTime.UtcNow;
            await _context.TrnProjectReportDtl.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ExistsAsync(string noSr)
        {
            return await _context.TrnProjectReportDtl.AsNoTracking().AnyAsync(x => x.NoSr == noSr);
        }

        public async Task<IEnumerable<TrnProjectReportDtl>> GetAllAsync()
        {
            return await _context.TrnProjectReportDtl.ToListAsync();
        }

        public async Task<TrnProjectReportDtl?> GetByNoSrAsync(string noSr)
        {
            var prd = await _context.TrnProjectReportDtl
            .AsNoTracking()
            .Include(x => x.TrnProject)
            .Include(x => x.TrnProjectTimeline)
            .Include(x => x.TrnProjectReport)
            .Include(x => x.TrnProjectIssues)
            .FirstOrDefaultAsync(x => x.NoSr == noSr);
            if (prd == null) return null;
            return prd;
        }

        public async Task<TrnProjectReportDtl> UpdateAsync(TrnProjectReportDtl model)
        {
            var exist = await _context.TrnProjectReportDtl.AsNoTracking().FirstOrDefaultAsync(x => x.NoSr == model.NoSr);
            if (exist == null) return null!;

            exist.NoSr = model.NoSr;
            exist.Active = model.Active;
            exist.ActualDate = model.ActualDate;
            exist.PlanDate = model.PlanDate;
            exist.Status = model.Status;
            exist.CodeProject = model.CodeProject;
            exist.WBSNo = model.WBSNo;
            exist.WeekNo = model.WeekNo;
            exist.UserUpdate = model.UserUpdate;
            exist.DateUpdate = DateTime.UtcNow;

            _context.TrnProjectReportDtl.Update(exist);
            await _context.SaveChangesAsync();
            return exist;
        }
    }
}