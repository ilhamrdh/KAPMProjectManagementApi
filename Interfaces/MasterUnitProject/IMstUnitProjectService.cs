using KAPMProjectManagementApi.Dto.MstUnitProject;

namespace KAPMProjectManagementApi.Interfaces.MasterUnitProject
{
    public interface IMstUnitProjectService
    {
        Task<IEnumerable<UnitProjectSimpleResponse>> GetAllUnitPtojectAsync();
        Task<UnitProjectResponse?> GetUnitProjectByUnitCodeAsync(string unitCode);
        Task<UnitProjectSimpleResponse> CreateUnitProjectAsync(UnitProjectRequestDto request);
        Task<UnitProjectSimpleResponse> UpdateUnitProjectAsync(UnitProjectRequestDto request);

    }
}