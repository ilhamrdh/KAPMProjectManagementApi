using KAPMProjectManagementApi.Dto.MstEmployee;
using KAPMProjectManagementApi.Exceptions;
using KAPMProjectManagementApi.Interfaces.MasterEmployee;
using KAPMProjectManagementApi.Mappers;

namespace KAPMProjectManagementApi.Services
{
    public class MstEmployeeService : IMstEmployeeService
    {
        private readonly IMstEmployeeRepository _repository;
        public MstEmployeeService(IMstEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeSimpleResponse> CreateEmployeeAsync(EmployeeRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.Nipp);
            if (exist) throw new BadRequestException($"Data with NIPP {reuqest.Nipp} already exist.");

            var employee = EmployeeMapper.ToEmployeeFromRequest(reuqest);
            var createP = await _repository.CreateAsync(employee);
            return createP.ToEmployeeSimpleResponse();
        }

        public async Task<IEnumerable<EmployeeSimpleResponse>> GetAllEmployeeAsync()
        {
            var result = await _repository.GetAllAsync();
            return result.Select(p => p.ToEmployeeSimpleResponse()).ToList();
        }

        public async Task<EmployeeResponse?> GetEmployeeByNippAsync(string nipp)
        {
            var result = await _repository.GetByNippAsync(nipp);
            if (result == null) throw new KeyNotFoundException($"Data with NIPP {nipp} not found.");
            return result.ToEmployeeResponse();
        }

        public async Task<EmployeeSimpleResponse> UpdateEmployeeAsync(EmployeeRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.Nipp);
            if (!exist) throw new KeyNotFoundException($"Data with NIPP {reuqest.Nipp} not found.");

            var employee = EmployeeMapper.ToEmployeeFromRequest(reuqest);
            var updateP = await _repository.UpdateAsync(employee);
            return updateP.ToEmployeeSimpleResponse();
        }
    }
}