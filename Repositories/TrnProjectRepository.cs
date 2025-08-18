using KAPMProjectManagementApi.Dto.Web;
using KAPMProjectManagementApi.Interfaces.TrnProject;
using KAPMProjectManagementApi.Models;
using KAPMProjectManagementApi.Schema;
using Microsoft.EntityFrameworkCore;

namespace KAPMProjectManagementApi.Repositories
{
    public class TrnProjectRepository : ITrnProjectRepository
    {
        private readonly ProjectManagementDBContext _context;
        public TrnProjectRepository(ProjectManagementDBContext context)
        {
            _context = context;
        }
        public async Task<TrnProject> CreateAsync(TrnProject model)
        {
            await _context.TrnProject.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ExistsAsync(string projectDef)
        {
            return await _context.TrnProject.AsNoTracking().AnyAsync(x => x.ProjectDef == projectDef);
        }

        public async Task<IEnumerable<TrnProject>> GetAllAsync(QuerySearch qs)
        {
            var projects = _context.TrnProject.AsNoTracking().Include(x => x.MstUnitProject).Include(x => x.MstProjectManager).AsQueryable();
            if (!string.IsNullOrEmpty(qs.Keyword))
            {
                projects = projects.Where(x => x.ProjectDef.Contains(qs.Keyword));
            }
            var skip = (qs.PageNumber - 1) * qs.PageSize;

            return await projects.Skip(skip).Take(qs.PageSize).ToListAsync();
        }

        public async Task<TrnProject?> GetByProjectDefAsync(string projectDef)
        {
            var p = await _context.TrnProject.AsNoTracking()
            .Include(x => x.MstUnitProject)
            .Include(x => x.MstProjectManager)
            .Include(x => x.TrnProjectTimelines)
            .FirstOrDefaultAsync(x => x.ProjectDef == projectDef);
            if (p == null) return null;
            return p;
        }

        public async Task<TrnProject> UpdateAsync(TrnProject model)
        {
            var exist = await _context.TrnProject.FirstOrDefaultAsync(x => x.ProjectDef == model.ProjectDef);
            if (exist == null) return null!;

            exist.AccountName = model.AccountName;
            exist.AccountNumber = model.AccountNumber;
            exist.WorkingMethod = model.WorkingMethod;
            exist.Active = model.Active;
            exist.Bank = model.Bank;
            exist.ActualPersentage = model.ActualPersentage;
            exist.PPH = model.PPH;
            exist.NoSPMK = model.NoSPMK;
            exist.NoContract = model.NoContract;
            exist.ContractValue = model.ContractValue;
            exist.ProgressReport = model.ProgressReport;
            exist.StartDateSPMK = model.StartDateSPMK;
            exist.StartDate = model.StartDate;
            exist.EndDate = model.EndDate;
            exist.PlanPersentage = model.PlanPersentage;
            exist.PaymentMethod = model.PaymentMethod;
            exist.ProjectResponsible = model.ProjectResponsible;
            exist.ProjectProfile = model.ProjectProfile;
            exist.UserUpdate = model.UserUpdate;
            exist.DateUpdate = DateTime.Now;

            _context.TrnProject.Update(exist);
            await _context.SaveChangesAsync();
            return exist;
        }
    }
}