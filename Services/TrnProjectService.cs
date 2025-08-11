using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Exceptions;
using KAPMProjectManagementApi.Interfaces.MasterProjectManager;
using KAPMProjectManagementApi.Interfaces.MasterUnitProject;
using KAPMProjectManagementApi.Interfaces.TrnProject;
using KAPMProjectManagementApi.Mappers;

namespace KAPMProjectManagementApi.Services
{
    public class TrnProjectService : ITrnProjectService
    {
        private readonly ILogger _logger;
        private readonly ITrnProjectRepository _repository;
        private readonly IMstUnitProjectRepository _unitProjectRepository;
        private readonly IMstProjectManagerRepository _projectManagerRepository;

        public TrnProjectService(ILogger<TrnProjectService> logger, ITrnProjectRepository repository, IMstUnitProjectRepository unitProjectRepository, IMstProjectManagerRepository projectManagerRepository)
        {
            _logger = logger;
            _repository = repository;
            _unitProjectRepository = unitProjectRepository;
            _projectManagerRepository = projectManagerRepository;
        }
        public async Task<ProjectResponse> CreateProjectAsync(ProjectRequestDto request)
        {
            _logger.LogInformation($"➕ Create project with request {request}");
            var exist = await _repository.GetByCodeProjectAsync(request.CodeProject);
            if (exist != null)
            {
                throw new BadRequestException($"Data with Code Project {request.CodeProject} already exist.");
            }

            var unit = await _unitProjectRepository.GetByUnitProjectAsync(request.UnitProject);
            if (unit == null) throw new KeyNotFoundException($"Data with Unit Project {request.UnitProject} not found.");

            var pm = await _projectManagerRepository.GetByNippAsync(request.PMProject);
            if (pm == null) throw new KeyNotFoundException($"Data with NIPP {request.PMProject} not found.");

            var p = ProjectMapper.ToProjectFromRequest(request);
            var createP = await _repository.CreateAsync(p);
            return createP.ToProjectResponses();
        }

        public async Task<IEnumerable<ProjectResponse>> GetAllProjectAsync()
        {
            var p = await _repository.GetAllAsync();
            return p.Select(p => p.ToProjectResponses()).ToList();
        }

        public async Task<ProjectResponse?> GetProjectByCodeProjectAsync(string codeProject)
        {
            var p = await _repository.GetByCodeProjectAsync(codeProject);
            if (p == null) throw new KeyNotFoundException($"Data with Code Project {codeProject} not found.");
            return p.ToProjectResponses();
        }

        public async Task<ProjectResponse> UpdateProjectAsync(ProjectRequestDto request)
        {
            var exist = await _repository.GetByCodeProjectAsync(request.CodeProject);
            if (exist == null) throw new KeyNotFoundException($"Data with Code Project {request.CodeProject} not found.");

            var unit = await _unitProjectRepository.GetByUnitProjectAsync(request.UnitProject);
            if (unit == null) throw new KeyNotFoundException($"Data with Unit Project {request.UnitProject} not found.");

            var pm = await _projectManagerRepository.GetByNippAsync(request.PMProject);
            if (pm == null) throw new KeyNotFoundException($"Data with NIPP {request.PMProject} not found.");

            var p = ProjectMapper.ToProjectFromRequest(request);
            var updateP = await _repository.UpdateAsync(p, exist.CodeProject);

            return updateP.ToProjectResponses();
        }
    }
}