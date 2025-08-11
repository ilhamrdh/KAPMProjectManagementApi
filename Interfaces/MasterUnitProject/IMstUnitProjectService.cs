using KAPMProjectManagementApi.Dto.MstUnitProject;

namespace KAPMProjectManagementApi.Interfaces.MasterUnitProject
{
    public interface IMstUnitProjectService
    {
        Task<IEnumerable<UnitProjectResponse>> GetAllUnitPtojectAsync();
        Task<UnitProjectResponse?> GetUnitProjectByUnitCodeAsync(string unitCode);
        Task<UnitProjectResponse> CreateUnitProjectAsync(UnitProjectRequestDto request);
        Task<UnitProjectResponse> UpdateUnitProjectAsync(UnitProjectRequestDto request);

    }
}