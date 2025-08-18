using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Dto.Web;
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
            var exist = await _repository.ExistsAsync(request.ProjectDef);
            if (exist) throw new BadRequestException($"Data with Code Project {request.ProjectDef} already exist.");

            var unit = await _unitProjectRepository.ExistsAsync(request.UnitProject);
            if (!unit) throw new KeyNotFoundException($"Data with Unit Project {request.UnitProject} not found.");

            var pm = await _projectManagerRepository.ExistsAsync(request.PMProject);
            if (!pm) throw new KeyNotFoundException($"Data with NIPP {request.PMProject} not found.");

            var p = ProjectMapper.ToProjectFromRequest(request);
            var createP = await _repository.CreateAsync(p);
            return createP.ToProjectResponses();
        }

        public async Task<IEnumerable<ProjectResponse>> GetAllProjectAsync(QuerySearch qs)
        {
            var p = await _repository.GetAllAsync(qs);
            return p.Select(p => p.ToProjectResponses()).ToList();
        }

        public async Task<ProjectDetailResponse?> GetProjectByProjectDefAsync(string projectDef)
        {
            var p = await _repository.GetByProjectDefAsync(projectDef);
            if (p == null) throw new KeyNotFoundException($"Data with Code Project {projectDef} not found.");
            return p.ToProjectDetailResponse();
        }

        public async Task<ProjectResponse> UpdateProjectAsync(ProjectRequestDto request)
        {
            var exist = await _repository.GetByProjectDefAsync(request.ProjectDef);
            if (exist == null) throw new KeyNotFoundException($"Data with Code Project {request.ProjectDef} not found.");

            var unit = await _unitProjectRepository.ExistsAsync(request.UnitProject);
            if (!unit) throw new KeyNotFoundException($"Data with Unit Project {request.UnitProject} not found.");

            var pm = await _projectManagerRepository.ExistsAsync(request.PMProject);
            if (!pm) throw new KeyNotFoundException($"Data with NIPP {request.PMProject} not found.");

            var mapper = ProjectMapper.ToProjectFromRequest(request);
            var update = await _repository.UpdateAsync(mapper);

            return update.ToProjectResponses();
        }
    }
}