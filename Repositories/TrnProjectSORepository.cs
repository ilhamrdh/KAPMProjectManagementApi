using KAPMProjectManagementApi.Interfaces.TrnProjectSO;
using KAPMProjectManagementApi.Models;
using KAPMProjectManagementApi.Schema;
using Microsoft.EntityFrameworkCore;

namespace KAPMProjectManagementApi.Repositories
{
    public class TrnProjectSORepository : ITrnProjectSORepository
    {
        private readonly ProjectManagementDBContext _context;
        public TrnProjectSORepository(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public async Task<TrnProjectSO> CreateAsync(TrnProjectSO model)
        {
            model.DateAdd = DateTime.UtcNow;
            await _context.TrnProjectSO.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.TrnProjectSO.AsNoTracking().AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TrnProjectSO>> GetAllAsync()
        {
            return await _context.TrnProjectSO.ToListAsync();
        }

        public async Task<TrnProjectSO?> GetByIdAsync(int id)
        {
            var po = await _context.TrnProjectSO
            .Include(x => x.TrnProject)
            .Include(x => x.MstRoleProject)
            .Include(x => x.MstEmployee)
            .FirstOrDefaultAsync(x => x.Id == id);
            if (po == null) return null;
            return po;
        }

        public async Task<TrnProjectSO> UpdateAsync(TrnProjectSO model)
        {
            var exist = await _context.TrnProjectSO.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (exist == null) return null!;

            exist.Nipp = model.Nipp;
            exist.Active = model.Active;
            exist.Name = model.Name;
            exist.RoleId = model.RoleId;
            exist.StartDate = model.StartDate;
            exist.FinishDate = model.FinishDate;
            exist.ProjectDef = model.ProjectDef;
            exist.UserUpdate = model.UserUpdate;
            exist.DateUpdate = DateTime.UtcNow;
            _context.TrnProjectSO.Update(exist);
            await _context.SaveChangesAsync();
            return exist;
        }
    }
}