using KAPMProjectManagementApi.Interfaces.MasterProjectManager;
using KAPMProjectManagementApi.Models;
using KAPMProjectManagementApi.Schema;
using Microsoft.EntityFrameworkCore;

namespace KAPMProjectManagementApi.Repositories
{
    public class MstProjectManagerRepository : IMstProjectManagerRepository
    {
        private readonly ProjectManagementDBContext _context;
        public MstProjectManagerRepository(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public async Task<MstProjectManager> CreateAsync(MstProjectManager model)
        {
            await _context.MstProjectManager.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ExistsAsync(string nipp)
        {
            return await _context.MstProjectManager.AsNoTracking().AnyAsync(x => x.Nipp == nipp);
        }

        public async Task<IEnumerable<MstProjectManager>> GetAllAsync()
        {
            return await _context.MstProjectManager.ToListAsync();
        }

        public async Task<MstProjectManager?> GetByNippAsync(string nipp)
        {
            var pm = await _context.MstProjectManager.FirstOrDefaultAsync(x => x.Nipp == nipp);
            if (pm == null)
            {
                return null;
            }
            return pm;
        }

        public async Task<MstProjectManager> UpdateAsync(MstProjectManager model)
        {
            var exist = await GetByNippAsync(model.Nipp);

            if (exist == null)
            {
                return null!;
            }

            exist.Name = model.Name;
            exist.Active = model.Active;
            exist.UserUpdate = model.UserUpdate;
            exist.DateUpdate = DateTime.Now;

            _context.MstProjectManager.Update(exist);
            await _context.SaveChangesAsync();
            return exist;
        }
    }
}