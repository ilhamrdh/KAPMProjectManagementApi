using KAPMProjectManagementApi.Dto.TrnProjectReportDetail;
using KAPMProjectManagementApi.Exceptions;
using KAPMProjectManagementApi.Interfaces.TrnProjectReport;
using KAPMProjectManagementApi.Interfaces.TrnProjectReportDtl;
using KAPMProjectManagementApi.Interfaces.TrnProjectTimeline;
using KAPMProjectManagementApi.Mappers;

namespace KAPMProjectManagementApi.Services
{
    public class TrnProjectReportDtlService : ITrnProjectReportDtlService
    {
        private readonly ITrnProjectReportDtlRepository _repository;
        private readonly ITrnProjectReportRepository _projectReportRepository;
        private readonly ITrnProjectTimelineRepository _trnProjectTimelineRepository;

        public TrnProjectReportDtlService(ITrnProjectReportDtlRepository repository, ITrnProjectReportRepository projectReportRepository, ITrnProjectTimelineRepository trnProjectTimelineRepository)
        {
            _repository = repository;
            _projectReportRepository = projectReportRepository;
            _trnProjectTimelineRepository = trnProjectTimelineRepository;
        }

        public async Task<ProjectReportDetailSimpleResponse> CreateProjectReportDtlAsync(ProjectReportDetailRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.NoSr);
            if (exist) throw new BadRequestException($"Data with No SR {reuqest.NoSr} already exist.");

            var project = await _projectReportRepository.ExistsAsync(reuqest.WeekNo);
            if (!project) throw new KeyNotFoundException($"Data with Week No {reuqest.WeekNo} not found.");

            var timeline = await _trnProjectTimelineRepository.ExistsAsync(reuqest.NoSr);
            if (!timeline) throw new KeyNotFoundException($"Data with No SR {reuqest.NoSr} not found.");

            var p = ProjectReportDetailMapper.ToProjectReportDetailFromRequest(reuqest);
            var createP = await _repository.CreateAsync(p);
            return createP.ToProjectReportDetailSimpleResponse();
        }

        public async Task<IEnumerable<ProjectReportDetailSimpleResponse>> GetAllProjectReportDtlAsync()
        {
            var result = await _repository.GetAllAsync();
            return result.Select(p => p.ToProjectReportDetailSimpleResponse()).ToList();
        }

        public async Task<ProjectReportDetailResponse?> GetProjectReportDtlByNoSrAsync(string noSr)
        {
            var result = await _repository.GetByNoSrAsync(noSr);
            if (result == null) throw new KeyNotFoundException($"Data with No SR {noSr} not found.");
            return result.ToProjectReportDetailResponse();
        }

        public async Task<ProjectReportDetailSimpleResponse> UpdateProjectReportDtlAsync(ProjectReportDetailRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.NoSr);
            if (!exist) throw new KeyNotFoundException($"Data with No SR {reuqest.NoSr} not found.");

            var project = await _projectReportRepository.ExistsAsync(reuqest.WeekNo);
            if (!project) throw new KeyNotFoundException($"Data with Week No {reuqest.WeekNo} not found.");

            var timeline = await _trnProjectTimelineRepository.ExistsAsync(reuqest.NoSr);
            if (!timeline) throw new KeyNotFoundException($"Data with No SR {reuqest.NoSr} not found.");

            var mapper = ProjectReportDetailMapper.ToProjectReportDetailFromRequest(reuqest);
            var update = await _repository.UpdateAsync(mapper);
            return update.ToProjectReportDetailSimpleResponse();
        }
    }
}