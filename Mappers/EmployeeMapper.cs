using KAPMProjectManagementApi.Dto.MstEmployee;
using KAPMProjectManagementApi.Models;

namespace KAPMProjectManagementApi.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeResponse ToEmployeeResponse(this MstEmployee model)
        {
            return new EmployeeResponse
            {
                Nipp = model.Nipp,
                Name = model.Name,
                Grade = model.Grade,
                Orgeh = model.Orgeh,
                Persa = model.Persa,
                Plans = model.Plans,
                Active = model.Active,
                ProjectSO = model.TrnProjectSO.ToProjectSOSimpleResponse(),
            };
        }

        public static EmployeeSimpleResponse ToEmployeeSimpleResponse(this MstEmployee model)
        {
            return new EmployeeSimpleResponse
            {
                Nipp = model.Nipp,
                Grade = model.Grade,
                Name = model.Name,
                Orgeh = model.Orgeh,
                Persa = model.Persa,
                Plans = model.Plans,
            };
        }

        public static MstEmployee ToEmployeeFromRequest(this EmployeeRequestDto model)
        {
            return new MstEmployee
            {
                Nipp = model.Nipp,
                Name = model.Name,
                Grade = model.Grade,
                Orgeh = model.Orgeh,
                Persa = model.Persa,
                Plans = model.Plans,
                Active = model.Active,
            };
        }
    }
}