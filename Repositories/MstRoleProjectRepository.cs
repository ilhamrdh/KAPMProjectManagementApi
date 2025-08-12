using KAPMProjectManagementApi.Interfaces.MasterRoleProject;
using KAPMProjectManagementApi.Models;
using KAPMProjectManagementApi.Schema;
using Microsoft.EntityFrameworkCore;

namespace KAPMProjectManagementApi.Repositories
{
    public class MstRoleProjectRepository : IMstRoleProjectRepository
    {
        private readonly ProjectManagementDBContext _context;
        public MstRoleProjectRepository(ProjectManagementDBContext context)
        {
            _context = context;
        }
        public async Task<MstRoleProject> CreateAsync(MstRoleProject model)
        {
            model.DateAdd = DateTime.UtcNow;
            await _context.MstRoleProject.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ExistsAsync(string roleid)
        {
            return await _context.MstRoleProject.AsNoTracking().AnyAsync(x => x.RoleId == roleid);
        }

        public async Task<IEnumerable<MstRoleProject>> GetAllAsync()
        {
            return await _context.MstRoleProject.ToListAsync();
        }

        public async Task<MstRoleProject?> GetByRoleIdAsync(string roleid)
        {
            var rp = await _context.MstRoleProject.FirstOrDefaultAsync(x => x.RoleId == roleid);
            if (rp == null) return null;
            return rp;
        }

        public async Task<MstRoleProject> UpdateAsync(MstRoleProject model)
        {
            var exist = await _context.MstRoleProject.FirstOrDefaultAsync(x => x.RoleId == model.RoleId);
            if (exist == null) return null!;

            exist.Active = model.Active;
            exist.RoleName = model.RoleName;
            exist.RoleType = model.RoleType;
            exist.UserUpdate = model.UserUpdate;
            exist.DateUpdate = DateTime.UtcNow;

            _context.MstRoleProject.Update(exist);
            await _context.SaveChangesAsync();
            return exist;

        }
    }
}