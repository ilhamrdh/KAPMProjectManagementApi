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

        public async Task<IEnumerable<TrnProject>> GetAllAsync()
        {
            return await _context.TrnProject.ToListAsync();
        }

        public async Task<TrnProject?> GetByCodeProjectAsync(string codeProject)
        {
            var p = await _context.TrnProject.FirstOrDefaultAsync(x => x.CodeProject.Equals(codeProject));
            if (p == null) return null;
            return p;
        }

        public async Task<TrnProject> UpdateAsync(TrnProject model, string codeProject)
        {
            var exist = await _context.TrnProject.FirstOrDefaultAsync(x => x.CodeProject.Equals(codeProject));
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
            exist.FinishDate = model.FinishDate;
            exist.PlanPersentage = model.PlanPersentage;
            exist.PaymentMethod = model.PaymentMethod;
            exist.PMProject = model.PMProject; // FK
            exist.UnitProject = model.UnitProject; // FK
            exist.UserUpdate = model.UserUpdate;
            exist.DateUpdate = DateTime.Now;

            _context.TrnProject.Update(exist);
            await _context.SaveChangesAsync();
            return exist;
        }
    }
}