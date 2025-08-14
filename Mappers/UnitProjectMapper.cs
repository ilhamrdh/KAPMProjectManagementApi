using KAPMProjectManagementApi.Dto.MstUnitProject;
using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Mappers
{
    public static class UnitProjectMapper
    {
        public static UnitProjectSimpleResponse ToUnitProjectSimpleResponse(this MstUnitProject model)
        {
            return new UnitProjectSimpleResponse
            {
                UnitProject = model.UnitProject,
                UnitDesc = model.UnitDesc,
            };
        }
        public static UnitProjectResponse ToUnitProjectResponses(this MstUnitProject model)
        {
            return new UnitProjectResponse
            {
                UnitProject = model.UnitProject,
                UnitDesc = model.UnitDesc,
                Active = model.Active,
                Projects = model.TrnProjects.Select(p => new ProjectSimpleResponse
                {
                    ProjectDef = p.ProjectDef,
                    ProjectDesc = p.ProjectDesc,
                }).ToList()
            };
        }

        public static MstUnitProject ToUnitProjectFromRequest(this UnitProjectRequestDto request)
        {
            return new MstUnitProject
            {
                UnitProject = request.UnitProject,
                UnitDesc = request.UnitDesc,
                UserAdd = request.UserAdd,
                Active = request.Active,
            };
        }
    }
}