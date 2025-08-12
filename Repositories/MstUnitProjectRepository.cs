using KAPMProjectManagementApi.Interfaces.MasterUnitProject;
using KAPMProjectManagementApi.Models;
using KAPMProjectManagementApi.Schema;
using Microsoft.EntityFrameworkCore;

namespace KAPMProjectManagementApi.Repositories
{
    public class MstUnitProjectRepository : IMstUnitProjectRepository
    {
        private readonly ProjectManagementDBContext _context;
        private readonly ILogger _logger;
        public MstUnitProjectRepository(ProjectManagementDBContext context, ILogger<MstUnitProjectRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<MstUnitProject> CreateAsync(MstUnitProject model)
        {
            await _context.MstUnitProject.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ExistsAsync(string unitCode)
        {
            return await _context.MstUnitProject.AsNoTracking().AnyAsync(x => x.UnitProject == unitCode);
        }

        public async Task<IEnumerable<MstUnitProject>> GetAllAsync()
        {
            var result = await _context.MstUnitProject.ToListAsync();
            return result;
        }

        public async Task<MstUnitProject?> GetByUnitProjectAsync(string unitProject)
        {
            var up = await _context.MstUnitProject.Include(x => x.TrnProjects.Where(p => p.Active == "Y")).FirstOrDefaultAsync(x => x.UnitProject == unitProject);
            if (up == null) return null;
            return up;
        }

        public async Task<MstUnitProject> UpdateAsync(MstUnitProject model)
        {
            var exist = await _context.MstUnitProject.FirstOrDefaultAsync(x => x.UnitProject.Equals(model.UnitProject));
            if (exist == null) return null!;

            exist.UnitDesc = model.UnitDesc;
            exist.Active = model.Active;
            exist.UserUpdate = model.UserUpdate;
            exist.DateUpdate = DateTime.Now;

            _context.MstUnitProject.Update(exist);
            await _context.SaveChangesAsync();
            return exist;
        }
    }
}