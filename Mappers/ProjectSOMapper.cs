using KAPMProjectManagementApi.Dto.TrnProjectSO;
using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Mappers
{
    public static class ProjectSOMapper
    {
        public static ProjectSOResponse ToProjectSOResponse(this TrnProjectSO model)
        {
            return new ProjectSOResponse
            {
                Id = model.Id,
                Name = model.Name,
                Active = model.Active,
                StartDate = model.StartDate,
                FinishDate = model.FinishDate,
                RoleProject = model.MstRoleProject.ToRoleProjectSimpleResponse(),
                MstEmployee = model.MstEmployee.ToEmployeeSimpleResponse(),
                TrnProject = model.TrnProject.ToProjectSimpleResponses(),
            };
        }
        public static ProjectSOSimpleResponse ToProjectSOSimpleResponse(this TrnProjectSO model)
        {
            return new ProjectSOSimpleResponse
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static TrnProjectSO ToProjectSOFromCreateRequest(this ProjectSORequestCreateDto model)
        {
            return new TrnProjectSO
            {
                Name = model.Name,
                Nipp = model.Nipp,
                ProjectDef = model.ProjectDef,
                RoleId = model.RoleId,
                Active = model.Active,
                StartDate = model.StartDate,
                FinishDate = model.FinishDate,
            };
        }

        public static TrnProjectSO ToProjectSOFromUpdateRequest(this ProjectSORequestUpdateDto model)
        {
            return new TrnProjectSO
            {
                Name = model.Name,
                Nipp = model.Nipp,
                ProjectDef = model.ProjectDef,
                RoleId = model.RoleId,
                Active = model.Active,
                StartDate = model.StartDate,
                FinishDate = model.FinishDate,
            };
        }
    }
}