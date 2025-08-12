using KAPMProjectManagementApi.Interfaces.TrnProjectAdendum;
using KAPMProjectManagementApi.Models;
using KAPMProjectManagementApi.Schema;
using Microsoft.EntityFrameworkCore;

namespace KAPMProjectManagementApi.Repositories
{
    public class TrnProjectAdendumRepository : ITrnProjectAdendumRepository
    {
        private readonly ProjectManagementDBContext _context;
        public TrnProjectAdendumRepository(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public async Task<TrnProjectAdendum> CreateAsync(TrnProjectAdendum model)
        {
            model.DateAdd = DateTime.UtcNow;
            await _context.TrnProjectAdendum.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ExistsAsync(string adendumNo)
        {
            return await _context.TrnProjectAdendum.AsNoTracking().AnyAsync(x => x.AdendumNo == adendumNo);
        }

        public async Task<IEnumerable<TrnProjectAdendum>> GetAllAsync()
        {
            return await _context.TrnProjectAdendum.ToListAsync();
        }

        public async Task<TrnProjectAdendum?> GetByAdendumNoAsync(string adendumNo)
        {
            var pa = await _context.TrnProjectAdendum.AsNoTracking()
            .Include(x => x.TrnProject)
            .Include(x => x.TrnProjectTimeline)
            .FirstOrDefaultAsync(x => x.AdendumNo == adendumNo);
            if (pa == null) return null;

            return pa;
        }

        public async Task<TrnProjectAdendum> UpdateAsync(TrnProjectAdendum model)
        {
            var exist = await _context.TrnProjectAdendum.AsNoTracking().FirstOrDefaultAsync(x => x.AdendumNo == model.AdendumNo);
            if (exist == null) return null!;

            exist.Status = model.Status;
            exist.Active = model.Active;
            exist.CostAfter = model.CostAfter;
            exist.CostBefore = model.CostBefore;
            exist.DateAfter = model.DateAfter;
            exist.DateBefore = model.DateBefore;
            exist.Reason = model.Reason;
            exist.UserUpdate = model.UserUpdate;
            exist.DateUpdate = DateTime.UtcNow;

            _context.TrnProjectAdendum.Update(exist);
            await _context.SaveChangesAsync();
            return exist;
        }
    }
}