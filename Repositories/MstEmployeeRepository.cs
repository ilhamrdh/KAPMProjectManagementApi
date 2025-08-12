using KAPMProjectManagementApi.Interfaces.MasterEmployee;
using KAPMProjectManagementApi.Models;
using KAPMProjectManagementApi.Schema;
using Microsoft.EntityFrameworkCore;

namespace KAPMProjectManagementApi.Repositories
{
    public class MstEmployeeRepository : IMstEmployeeRepository
    {
        private readonly ProjectManagementDBContext _context;
        public MstEmployeeRepository(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public async Task<MstEmployee> CreateAsync(MstEmployee model)
        {
            model.DateAdd = DateTime.Now;
            await _context.MstEmployee.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ExistsAsync(string nipp)
        {
            return await _context.MstEmployee.AsNoTracking().AnyAsync(x => x.Nipp == nipp);
        }

        public async Task<IEnumerable<MstEmployee>> GetAllAsync()
        {
            return await _context.MstEmployee.ToListAsync();
        }

        public async Task<MstEmployee?> GetByNippAsync(string nipp)
        {
            var e = await _context.MstEmployee.AsNoTracking().Include(x => x.TrnProjectSO).FirstOrDefaultAsync(x => x.Nipp == nipp);
            if (e == null) return null;
            return e;
        }

        public async Task<MstEmployee> UpdateAsync(MstEmployee model)
        {
            var exist = await _context.MstEmployee.AsNoTracking().FirstOrDefaultAsync(x => x.Nipp == model.Nipp);
            if (exist == null) return null!;

            exist.Plans = model.Plans;
            exist.Active = model.Active;
            exist.Grade = model.Grade;
            exist.Name = model.Name;
            exist.Persa = model.Persa;
            exist.Orgeh = model.Orgeh;
            exist.UserUpdate = model.UserUpdate;
            exist.DateUpdate = DateTime.UtcNow;

            _context.MstEmployee.Update(exist);
            await _context.SaveChangesAsync();
            return exist;
        }
    }
}