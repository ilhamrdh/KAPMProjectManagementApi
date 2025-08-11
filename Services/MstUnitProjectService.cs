using KAPMProjectManagementApi.Dto.MstUnitProject;
using KAPMProjectManagementApi.Exceptions;
using KAPMProjectManagementApi.Interfaces.MasterUnitProject;
using KAPMProjectManagementApi.Mappers;

namespace KAPMProjectManagementApi.Services
{
    public class MstUnitProjectService : IMstUnitProjectService
    {
        private readonly IMstUnitProjectRepository _repository;
        private readonly ILogger _logger;
        public MstUnitProjectService(IMstUnitProjectRepository repository, ILogger<MstUnitProjectService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<UnitProjectResponse> CreateUnitProjectAsync(UnitProjectRequestDto request)
        {
            var exist = await _repository.GetByUnitProjectAsync(request.UnitProject);
            if (exist != null)
            {
                throw new BadRequestException($"Data with Unit Project {request.UnitProject} already exist.");
            }
            var up = UnitProjectMapper.ToUnitProjectFromRequest(request);
            var createUP = await _repository.CreateAsync(up);
            return createUP.ToUnitProjectResponses();
        }

        public async Task<IEnumerable<UnitProjectResponse>> GetAllUnitPtojectAsync()
        {
            var up = await _repository.GetAllAsync();
            var result = up.Select(x => x.ToUnitProjectResponses()).ToList();

            return result;
        }

        public async Task<UnitProjectResponse?> GetUnitProjectByUnitCodeAsync(string unitProject)
        {
            var up = await _repository.GetByUnitProjectAsync(unitProject);
            if (up == null)
            {
                throw new KeyNotFoundException($"Data with Unit Project {unitProject} not found.");
            }
            return up.ToUnitProjectResponses();
        }

        public async Task<UnitProjectResponse> UpdateUnitProjectAsync(UnitProjectRequestDto request)
        {
            var exist = await _repository.GetByUnitProjectAsync(request.UnitProject);
            if (exist == null)
            {
                throw new KeyNotFoundException($"Data with Unit Project {request.UnitProject} not found.");
            }
            var up = UnitProjectMapper.ToUnitProjectFromRequest(request);
            var updateUP = await _repository.UpdateAsync(up);
            if (updateUP == null)
            {
                throw new KeyNotFoundException($"Data with Unit Project {request.UnitProject} not found.");
            }
            return updateUP.ToUnitProjectResponses();
        }
    }
}