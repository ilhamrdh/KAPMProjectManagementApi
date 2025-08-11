using KAPMProjectManagementApi.Dto.MstProjectManager;
using KAPMProjectManagementApi.Exceptions;
using KAPMProjectManagementApi.Interfaces.MasterProjectManager;
using KAPMProjectManagementApi.Mappers;

namespace KAPMProjectManagementApi.Services
{
    public class MstProjectManagerService : IMstProjectManagerService
    {
        private readonly IMstProjectManagerRepository _repository;

        public MstProjectManagerService(IMstProjectManagerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectManagerResponse> CreateProjectManagerAsync(ProjectManagerReuqestDto reuqest)
        {
            var exist = await _repository.GetByNippAsync(reuqest.Nipp);
            if (exist != null)
            {
                throw new BadRequestException($"Data with NIPP {reuqest.Nipp} already exist.");
            }

            var pm = ProjectManagerMapper.ToProjectManagerFromRequest(reuqest);
            var createPm = await _repository.CreateAsync(pm);
            return createPm.ToProjectManagerResponses();
        }

        public async Task<IEnumerable<ProjectManagerResponse>> GetAllProjectManagerAsync()
        {
            var pm = await _repository.GetAllAsync();
            return pm.Select(p => p.ToProjectManagerResponses()).ToList();
        }

        public async Task<ProjectManagerResponse?> GetProjectManagerByNippAsync(string nipp)
        {
            var pm = await _repository.GetByNippAsync(nipp);
            if (pm == null)
            {
                throw new KeyNotFoundException($"Data with NIPP {nipp} not found.");
            }
            return pm.ToProjectManagerResponses();
        }

        public async Task<ProjectManagerResponse> UpdateProjectManagerAsync(ProjectManagerReuqestDto reuqest)
        {
            var exist = await _repository.GetByNippAsync(reuqest.Nipp);
            if (exist == null) throw new KeyNotFoundException($"Data with NIPP {reuqest.Nipp} not found.");

            var pm = ProjectManagerMapper.ToProjectManagerFromRequest(reuqest);
            var updatePm = await _repository.UpdateAsync(pm);
            if (updatePm == null)
            {
                throw new KeyNotFoundException($"Data with NIPP {reuqest.Nipp} not found.");
            }
            return updatePm.ToProjectManagerResponses();
        }
    }
}