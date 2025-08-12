using KAPMProjectManagementApi.Interfaces.TrnProjectTimeline;
using KAPMProjectManagementApi.Schema;
using Microsoft.EntityFrameworkCore;

namespace KAPMProjectManagementApi.Repositories
{
    public class TrnProjectTimelineRepository : ITrnProjectTimelineRepository
    {
        private readonly ProjectManagementDBContext _context;
        public TrnProjectTimelineRepository(ProjectManagementDBContext context)
        {
            _context = context;
        }
        public async Task<Models.TrnProjectTimeline> CreateAsync(Models.TrnProjectTimeline model)
        {
            model.DateAdd = DateTime.UtcNow;
            await _context.TrnProjectTimeline.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ExistsAsync(string wbsno)
        {
            return await _context.TrnProjectTimeline.AsNoTracking().AnyAsync(x => x.WBSNo == wbsno);
        }

        public async Task<List<Models.TrnProjectTimeline>> GetAllAsync()
        {
            return await _context.TrnProjectTimeline.ToListAsync();
        }

        public async Task<Models.TrnProjectTimeline?> GetByNoWBSAsync(string wbsno)
        {
            var pt = await _context.TrnProjectTimeline.AsNoTracking().Include(x => x.TrnProject).FirstOrDefaultAsync(x => x.WBSNo == wbsno);
            if (pt == null) return null;
            return pt;
        }

        public async Task<Models.TrnProjectTimeline> UpdateAsync(Models.TrnProjectTimeline model)
        {
            var exist = await _context.TrnProjectTimeline.FirstOrDefaultAsync(x => x.WBSNo == model.WBSNo);
            if (exist == null) return null!;

            exist.WBSLevel = model.WBSLevel;
            exist.Responsible = model.Responsible;
            exist.Active = model.Active;
            exist.Status = model.Status;
            exist.StartDate = model.StartDate;
            exist.FinishDate = model.FinishDate;
            exist.UserUpdate = model.UserUpdate;
            exist.DateUpdate = DateTime.UtcNow;

            _context.TrnProjectTimeline.Update(exist);
            await _context.SaveChangesAsync();
            return exist;
        }
    }
}