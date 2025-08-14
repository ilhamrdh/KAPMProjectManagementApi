using KAPMProjectManagementApi.Dto.TrnProjectAdendum;
using KAPMProjectManagementApi.Exceptions;
using KAPMProjectManagementApi.Interfaces.TrnProject;
using KAPMProjectManagementApi.Interfaces.TrnProjectAdendum;
using KAPMProjectManagementApi.Interfaces.TrnProjectReport;
using KAPMProjectManagementApi.Interfaces.TrnProjectTimeline;
using KAPMProjectManagementApi.Mappers;

namespace KAPMProjectManagementApi.Services
{
    public class TrnProjectAdendumService : ITrnProjectAdendumService
    {
        private readonly ITrnProjectAdendumRepository _repository;
        private readonly ITrnProjectRepository _projectRepository;
        private readonly ITrnProjectTimelineRepository _ProjectTimelineRepository;

        public TrnProjectAdendumService(ITrnProjectAdendumRepository repository, ITrnProjectRepository projectRepository, ITrnProjectTimelineRepository projectTimelineRepository)
        {
            _repository = repository;
            _projectRepository = projectRepository;
            _ProjectTimelineRepository = projectTimelineRepository;
        }
        public async Task<ProjectAdendumSimpleResponse> CreateProjectAdendumAsync(ProjectAdendumRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.AdendumNo);
            if (exist) throw new BadRequestException($"Data with Adendum No {reuqest.AdendumNo} already exist.");

            var project = await _projectRepository.ExistsAsync(reuqest.ProjectDef);
            if (!project) throw new KeyNotFoundException($"Data with Code Project {reuqest.ProjectDef} not found");

            var timeline = await _ProjectTimelineRepository.ExistsAsync(reuqest.WBSElement);
            if (!timeline) throw new KeyNotFoundException($"Data with No WBS {reuqest.WBSElement} not found.");

            var mapper = ProjectAdendumMapper.ToProjectAdendumFromRequest(reuqest);
            var create = await _repository.CreateAsync(mapper);
            return create.ToProjectAdendumSimpleResponse();
        }

        public async Task<IEnumerable<ProjectAdendumSimpleResponse>> GetAllProjectAdendumAsync()
        {
            var results = await _repository.GetAllAsync();
            return results.Select(x => x.ToProjectAdendumSimpleResponse());
        }

        public async Task<ProjectAdendumResponse?> GetProjectAdendumByAdendumNoAsync(string adendumNo)
        {
            var result = await _repository.GetByAdendumNoAsync(adendumNo);
            if (result == null) throw new KeyNotFoundException($"Data with Adendum No {adendumNo} not found.");
            return result.ToProjectAdendumResponse();
        }

        public async Task<ProjectAdendumSimpleResponse> UpdateProjectAdendumAsync(ProjectAdendumRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.AdendumNo);
            if (!exist) throw new KeyNotFoundException($"Data with Adendum No {reuqest.AdendumNo} not found.");

            var project = await _projectRepository.ExistsAsync(reuqest.ProjectDef);
            if (!project) throw new KeyNotFoundException($"Data with Code Project {reuqest.ProjectDef} not found");

            var timeline = await _ProjectTimelineRepository.ExistsAsync(reuqest.WBSElement);
            if (!timeline) throw new KeyNotFoundException($"Data with No WBS {reuqest.WBSElement} not found.");

            var mapper = ProjectAdendumMapper.ToProjectAdendumFromRequest(reuqest);
            var update = await _repository.UpdateAsync(mapper);
            return update.ToProjectAdendumSimpleResponse();
        }
    }
}