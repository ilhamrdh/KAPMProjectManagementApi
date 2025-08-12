using KAPMProjectManagementApi.Dto.TrnProjectIssue;
using KAPMProjectManagementApi.Exceptions;
using KAPMProjectManagementApi.Interfaces.TrnProject;
using KAPMProjectManagementApi.Interfaces.TrnProjectIssue;
using KAPMProjectManagementApi.Interfaces.TrnProjectReport;
using KAPMProjectManagementApi.Interfaces.TrnProjectReportDtl;
using KAPMProjectManagementApi.Interfaces.TrnProjectTimeline;
using KAPMProjectManagementApi.Mappers;

namespace KAPMProjectManagementApi.Services
{
    public class TrnProjectIssueService : ITrnProjectIssueService
    {
        private readonly ITrnProjectIssueRepository _repository;
        private readonly ITrnProjectRepository _projectRepository;
        private readonly ITrnProjectTimelineRepository _projectTimelineRepository;
        private readonly ITrnProjectReportDtlRepository _projectReportDtlRepository;
        private readonly ITrnProjectReportRepository _projectReportRepository;

        public TrnProjectIssueService(ITrnProjectIssueRepository repository, ITrnProjectRepository projectRepository, ITrnProjectTimelineRepository projectTimelineRepository, ITrnProjectReportDtlRepository projectReportDtlRepository, ITrnProjectReportRepository trnProjectReportRepository)
        {
            _repository = repository;
            _projectRepository = projectRepository;
            _projectTimelineRepository = projectTimelineRepository;
            _projectReportDtlRepository = projectReportDtlRepository;
            _projectReportRepository = trnProjectReportRepository;

        }
        public async Task<ProjectIssueSimpleResponse> CreateProjectIssueAsync(ProjectIssueRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.NoSr);
            if (exist) throw new BadRequestException($"Data with No SR {reuqest.NoSr} already exist.");

            var project = await _projectRepository.ExistsAsync(reuqest.CodeProject);
            if (!project) throw new KeyNotFoundException($"Data with Project Code {reuqest.CodeProject} not found.");

            var timeline = await _projectTimelineRepository.ExistsAsync(reuqest.NoSr);
            if (!timeline) throw new KeyNotFoundException($"Data with No SR {reuqest.NoSr} not found.");

            var report = await _projectReportDtlRepository.ExistsAsync(reuqest.NoSr);
            if (!report) throw new KeyNotFoundException($"Data with No SR {reuqest.NoSr} not found.");

            var report2 = await _projectReportRepository.ExistsAsync(reuqest.WeekNo);
            if (!report2) throw new KeyNotFoundException($"Data with Week No {reuqest.WeekNo} not found.");

            var p = ProjectIssueMapper.ToProjectIssueFromRequest(reuqest);
            var create = await _repository.CreateAsync(p);
            return create.ToProjectIssueSimpleResponse();
        }

        public async Task<IEnumerable<ProjectIssueSimpleResponse>> GetAllProjectIssueAsync()
        {
            var results = await _repository.GetAllAsync();
            return results.Select(x => x.ToProjectIssueSimpleResponse());
        }

        public async Task<ProjectIssueResponse?> GetProjectIssueByNoIssueAsync(string noIssue)
        {
            var result = await _repository.GetByNoIssueAsync(noIssue);
            if (result == null) throw new KeyNotFoundException($"Data with No Issue {noIssue} not found.");
            return result.ToProjectIssueResponse();
        }

        public async Task<ProjectIssueSimpleResponse> UpdateProjectIssueAsync(ProjectIssueRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.NoIssue);
            if (!exist) throw new KeyNotFoundException($"Data with No Issue {reuqest.NoIssue} not found.");

            var project = await _projectRepository.ExistsAsync(reuqest.CodeProject);
            if (!project) throw new KeyNotFoundException($"Data with Project Code {reuqest.CodeProject} not found.");

            var timeline = await _projectTimelineRepository.ExistsAsync(reuqest.NoSr);
            if (!timeline) throw new KeyNotFoundException($"Data with No SR {reuqest.NoSr} not found.");

            var report = await _projectReportDtlRepository.ExistsAsync(reuqest.NoSr);
            if (!report) throw new KeyNotFoundException($"Data with No SR {reuqest.NoSr} not found.");

            var report2 = await _projectReportRepository.ExistsAsync(reuqest.WeekNo);
            if (!report2) throw new KeyNotFoundException($"Data with Week No {reuqest.WeekNo} not found.");

            var p = ProjectIssueMapper.ToProjectIssueFromRequest(reuqest);
            var update = await _repository.UpdateAsync(p);
            return update.ToProjectIssueSimpleResponse();
        }
    }
}