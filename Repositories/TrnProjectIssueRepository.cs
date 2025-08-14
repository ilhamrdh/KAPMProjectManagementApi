using KAPMProjectManagementApi.Interfaces.TrnProjectIssue;
using KAPMProjectManagementApi.Models;
using KAPMProjectManagementApi.Schema;
using Microsoft.EntityFrameworkCore;

namespace KAPMProjectManagementApi.Repositories
{
    public class TrnProjectIssueRepository : ITrnProjectIssueRepository
    {
        private readonly ProjectManagementDBContext _context;
        public TrnProjectIssueRepository(ProjectManagementDBContext context)
        {
            _context = context;
        }
        public async Task<TrnProjectIssue> CreateAsync(TrnProjectIssue model)
        {
            model.DateAdd = DateTime.UtcNow;
            await _context.TrnProjectIssue.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ExistsAsync(string noIssue)
        {
            return await _context.TrnProjectIssue.AsNoTracking().AnyAsync(x => x.NoIssue == noIssue);
        }

        public async Task<IEnumerable<TrnProjectIssue>> GetAllAsync()
        {
            return await _context.TrnProjectIssue.ToListAsync();
        }

        public async Task<TrnProjectIssue?> GetByNoIssueAsync(string noIssue)
        {
            var pi = await _context.TrnProjectIssue.AsNoTracking()
            .Include(x => x.TrnProject)
            .Include(x => x.TrnProjectReport)
            .Include(x => x.TrnProjectReportDtl)
            .FirstOrDefaultAsync(x => x.NoIssue == noIssue);

            if (pi == null) return null;

            return pi;
        }

        public async Task<TrnProjectIssue> UpdateAsync(TrnProjectIssue model)
        {
            var exist = await _context.TrnProjectIssue.AsNoTracking().FirstOrDefaultAsync(x => x.NoIssue == model.NoIssue);
            if (exist == null) return null!;

            exist.ActionPlan = model.ActionPlan;
            exist.ActionProblem = model.ActionProblem;
            exist.ProjectDef = model.ProjectDef;
            exist.Problem = model.Problem;
            exist.NoSr = model.NoSr;
            exist.WBSElement = model.WBSElement;
            exist.WeekNo = model.WeekNo;
            exist.DateUpdate = DateTime.UtcNow;
            exist.UserUpdate = model.UserUpdate;

            _context.TrnProjectIssue.Update(exist);
            await _context.SaveChangesAsync();
            return exist;
        }
    }
}