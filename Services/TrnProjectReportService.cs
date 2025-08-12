using KAPMProjectManagementApi.Dto.TrnProjectReport;
using KAPMProjectManagementApi.Exceptions;
using KAPMProjectManagementApi.Interfaces.TrnProject;
using KAPMProjectManagementApi.Interfaces.TrnProjectReport;
using KAPMProjectManagementApi.Mappers;

namespace KAPMProjectManagementApi.Services
{
    public class TrnProjectReportService : ITrnProjectReportService
    {
        private readonly ITrnProjectReportRepository _repository;
        private readonly ITrnProjectRepository _projectRepository;
        public TrnProjectReportService(ITrnProjectReportRepository repository, ITrnProjectRepository projectRepository)
        {
            _repository = repository;
            _projectRepository = projectRepository;
        }
        public async Task<ProjectReportSimpleResponse> CreateProjectReportAsync(ProjectReportRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.WeekNo);
            if (exist) throw new BadRequestException($"Data with Week No {reuqest.WeekNo} already exist.");

            var project = await _projectRepository.ExistsAsync(reuqest.CodeProject);
            if (!project) throw new KeyNotFoundException($"Data with Project Code {reuqest.CodeProject} not found.");

            var p = ProjectReportMapper.ToProjectReportFromRequest(reuqest);
            var createP = await _repository.CreateAsync(p);
            return createP.ToProjectReportSimpleResponse();
        }

        public async Task<IEnumerable<ProjectReportSimpleResponse>> GetAllProjectReportAsync()
        {
            var result = await _repository.GetAllAsync();
            return result.Select(p => p.ToProjectReportSimpleResponse()).ToList();
        }

        public async Task<ProjectReportResponse?> GetProjectReportByWeekNoAsync(string weekNo)
        {
            var result = await _repository.GetByWeekNoAsync(weekNo);
            if (result == null) throw new KeyNotFoundException($"Data with Week No {weekNo} not found.");
            return result.ToProjectReportResponse();
        }

        public async Task<ProjectReportSimpleResponse> UpdateProjectReportAsync(ProjectReportRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.WeekNo);
            if (!exist) throw new KeyNotFoundException($"Data with Week No {reuqest.WeekNo} not found.");

            var project = await _projectRepository.ExistsAsync(reuqest.CodeProject);
            if (!project) throw new KeyNotFoundException($"Data with Project Code {reuqest.CodeProject} not found.");

            var pr = ProjectReportMapper.ToProjectReportFromRequest(reuqest);
            var update = await _repository.UpdateAsync(pr);
            return update.ToProjectReportSimpleResponse();
        }
    }
}