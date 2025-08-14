using KAPMProjectManagementApi.Dto.TrnScheduleInvoice;
using KAPMProjectManagementApi.Exceptions;
using KAPMProjectManagementApi.Interfaces.TrnProject;
using KAPMProjectManagementApi.Interfaces.TrnScheduleInvoice;
using KAPMProjectManagementApi.Mappers;

namespace KAPMProjectManagementApi.Services
{
    public class TrnScheduleInvoiceService : ITrnScheduleInvoiceService
    {
        private readonly ITrnScheduleInvoiceRepository _repository;
        private readonly ITrnProjectRepository _projectRepository;

        public TrnScheduleInvoiceService(ITrnScheduleInvoiceRepository repository, ITrnProjectRepository projectRepository)
        {
            _repository = repository;
            _projectRepository = projectRepository;
        }
        public async Task<ScheduleInvoiceSimpleResponse> CreateScheduleInvoiceAsync(ScheduleInvoiceRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.No);
            if (exist) throw new BadRequestException($"Data with No {reuqest.No} already exist.");

            var project = await _projectRepository.ExistsAsync(reuqest.ProjectDef);
            if (!project) throw new KeyNotFoundException($"Data with Project Code {reuqest.ProjectDef} not found.");

            var mapper = ScheduleInvoiceMapper.ToScheduleInvoiceFromRequest(reuqest);
            var create = await _repository.CreateAsync(mapper);
            return create.ToScheduleInvoiceSimpleResponse();
        }

        public async Task<IEnumerable<ScheduleInvoiceSimpleResponse>> GetAllScheduleInvoiceAsync()
        {
            var results = await _repository.GetAllAsync();
            return results.Select(x => x.ToScheduleInvoiceSimpleResponse());
        }

        public async Task<ScheduleInvoiceResponse?> GetScheduleInvoiceByNoAsync(string no)
        {
            var result = await _repository.GetByNoAsync(no);
            if (result == null) throw new KeyNotFoundException($"Data with No {no} not found.");
            return result.ToScheduleInvoiceResponse();
        }

        public async Task<ScheduleInvoiceSimpleResponse> UpdateScheduleInvoiceAsync(ScheduleInvoiceRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.No);
            if (!exist) throw new KeyNotFoundException($"Data with No {reuqest.No} not found.");

            var project = await _projectRepository.ExistsAsync(reuqest.ProjectDef);
            if (!project) throw new KeyNotFoundException($"Data with Project Code {reuqest.ProjectDef} not found.");

            var mapper = ScheduleInvoiceMapper.ToScheduleInvoiceFromRequest(reuqest);
            var update = await _repository.UpdateAsync(mapper);
            return update.ToScheduleInvoiceSimpleResponse();
        }
    }
}