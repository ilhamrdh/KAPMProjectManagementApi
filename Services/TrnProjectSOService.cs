using KAPMProjectManagementApi.Dto.TrnProjectSO;
using KAPMProjectManagementApi.Interfaces.MasterEmployee;
using KAPMProjectManagementApi.Interfaces.MasterRoleProject;
using KAPMProjectManagementApi.Interfaces.TrnProject;
using KAPMProjectManagementApi.Interfaces.TrnProjectSO;
using KAPMProjectManagementApi.Mappers;

namespace KAPMProjectManagementApi.Services
{
    public class TrnProjectSOService : ITrnProjectSOService
    {
        private readonly ITrnProjectSORepository _repository;
        private readonly ITrnProjectRepository _projectRepository;
        private readonly IMstRoleProjectRepository _roleProjectRepository;
        private readonly IMstEmployeeRepository _employeeRepository;

        public TrnProjectSOService(ITrnProjectSORepository repository, ITrnProjectRepository projectRepository, IMstRoleProjectRepository roleProjectRepository, IMstEmployeeRepository employeeRepository)
        {
            _repository = repository;
            _projectRepository = projectRepository;
            _roleProjectRepository = roleProjectRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<ProjectSOSimpleResponse> CreateProjectSOAsync(ProjectSORequestCreateDto reuqest)
        {
            var project = await _projectRepository.ExistsAsync(reuqest.CodeProject);
            if (!project) throw new KeyNotFoundException($"Data with Project Code {reuqest.CodeProject} not found.");

            var role = await _roleProjectRepository.ExistsAsync(reuqest.RoleId);
            if (!role) throw new KeyNotFoundException($"Data with Role Id {reuqest.RoleId} not found.");

            var employee = await _employeeRepository.ExistsAsync(reuqest.Nipp);
            if (!employee) throw new KeyNotFoundException($"Data with NIPP {reuqest.Nipp} not found.");

            var p = ProjectSOMapper.ToProjectSOFromCreateRequest(reuqest);
            var createP = await _repository.CreateAsync(p);
            return createP.ToProjectSOSimpleResponse();
        }

        public async Task<IEnumerable<ProjectSOSimpleResponse>> GetAllProjectSOAsync()
        {
            var result = await _repository.GetAllAsync();
            return result.Select(p => p.ToProjectSOSimpleResponse()).ToList();
        }

        public async Task<ProjectSOResponse?> GetProjectSOByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null) throw new KeyNotFoundException($"Data with Id {id} not found.");
            return result.ToProjectSOResponse();
        }

        public async Task<ProjectSOSimpleResponse> UpdateProjectSOAsync(ProjectSORequestUpdateDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.Id);
            if (!exist) throw new KeyNotFoundException($"Data with Id {reuqest.Id} not found.");

            var project = await _projectRepository.ExistsAsync(reuqest.CodeProject);
            if (!project) throw new KeyNotFoundException($"Data with Project Code {reuqest.CodeProject} not found.");

            var role = await _roleProjectRepository.ExistsAsync(reuqest.RoleId);
            if (!role) throw new KeyNotFoundException($"Data with Role Id {reuqest.RoleId} not found.");

            var employee = await _employeeRepository.ExistsAsync(reuqest.Nipp);
            if (!employee) throw new KeyNotFoundException($"Data with NIPP {reuqest.Nipp} not found.");

            var p = ProjectSOMapper.ToProjectSOFromUpdateRequest(reuqest);
            var updateP = await _repository.UpdateAsync(p);
            return updateP.ToProjectSOSimpleResponse();
        }
    }
}