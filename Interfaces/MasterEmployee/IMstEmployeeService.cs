using KAPMProjectManagementApi.Dto.MstEmployee;

namespace KAPMProjectManagementApi.Interfaces.MasterEmployee
{
    public interface IMstEmployeeService
    {
        Task<IEnumerable<EmployeeSimpleResponse>> GetAllEmployeeAsync();
        Task<EmployeeResponse?> GetEmployeeByNippAsync(string nipp);
        Task<EmployeeSimpleResponse> CreateEmployeeAsync(EmployeeRequestDto reuqest);
        Task<EmployeeSimpleResponse> UpdateEmployeeAsync(EmployeeRequestDto reuqest);
    }
}