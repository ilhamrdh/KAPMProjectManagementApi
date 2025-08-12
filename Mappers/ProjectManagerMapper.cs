using KAPMProjectManagementApi.Dto.MstProjectManager;
using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Mappers
{
    public static class ProjectManagerMapper
    {
        public static ProjectManagerResponse ToProjectManagerResponses(this MstProjectManager model)
        {
            return new ProjectManagerResponse
            {
                Nipp = model.Nipp,
                Name = model.Name,
                Active = model.Active
            };
        }

        public static MstProjectManager ToProjectManagerFromRequest(this ProjectManagerReuqestDto reuqest)
        {
            return new MstProjectManager
            {
                Nipp = reuqest.Nipp,
                Name = reuqest.Name,
                Active = reuqest.Active
            };
        }
    }
}