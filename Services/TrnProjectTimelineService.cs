using KAPMProjectManagementApi.Dto.TrnProjectTimeline;
using KAPMProjectManagementApi.Exceptions;
using KAPMProjectManagementApi.Interfaces.TrnProject;
using KAPMProjectManagementApi.Interfaces.TrnProjectTimeline;
using KAPMProjectManagementApi.Mappers;

namespace KAPMProjectManagementApi.Services
{
    public class TrnProjectTimelineService : ITrnProjectTimelineService
    {
        private readonly ITrnProjectTimelineRepository _repository;
        private readonly ITrnProjectRepository _projectRepository;
        public TrnProjectTimelineService(ITrnProjectTimelineRepository repository, ITrnProjectRepository projectRepository)
        {
            _repository = repository;
            _projectRepository = projectRepository;
        }
        public async Task<ProjectTimelineSimpleResponse> CreateProjectTimelineAsync(ProjectTimelineRequestDto request)
        {
            var exist = await _repository.ExistsAsync(request.WBSElement);
            if (exist) throw new BadRequestException($"Data with WBS No {request.WBSElement} already exist.");

            var project = await _projectRepository.ExistsAsync(request.ProjectDef);
            if (!project) throw new KeyNotFoundException($"Data with Project Code {request.ProjectDef} not found.");

            var p = ProjectTimelineMapper.ToProjectTimelineFromRequest(request);
            var createP = await _repository.CreateAsync(p);
            return createP.ToProjectTimelineSimpleResponse();
        }

        public async Task<IEnumerable<ProjectTimelineSimpleResponse>> GetAllProjectTimelineAsync()
        {
            var result = await _repository.GetAllAsync();
            return result.Select(p => p.ToProjectTimelineSimpleResponse()).ToList();
        }

        public async Task<ProjectTimelineResponse> GetProjectTimelineByWBSElementAsync(string wbsElement)
        {
            var result = await _repository.GetByWBSElementAsync(wbsElement);
            if (result == null) throw new KeyNotFoundException($"Data with WBS No {wbsElement} not found.");
            return result.ToProjectTimelineResponse();
        }

        public async Task<ProjectTimelineSimpleResponse> UpdateProjectTimelineAsync(ProjectTimelineRequestDto request)
        {
            var exist = await _repository.ExistsAsync(request.WBSElement);
            if (!exist) throw new KeyNotFoundException($"Data with WBS No {request.WBSElement} not found.");

            var project = await _projectRepository.ExistsAsync(request.ProjectDef);
            if (!project) throw new KeyNotFoundException($"Data with Project Code {request.ProjectDef} not found.");

            var p = ProjectTimelineMapper.ToProjectTimelineFromRequest(request);
            var updateP = await _repository.UpdateAsync(p);
            return updateP.ToProjectTimelineSimpleResponse();
        }
    }
}