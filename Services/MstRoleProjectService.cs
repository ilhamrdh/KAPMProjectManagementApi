using KAPMProjectManagementApi.Dto.MstRoleProject;
using KAPMProjectManagementApi.Exceptions;
using KAPMProjectManagementApi.Interfaces.MasterRoleProject;
using KAPMProjectManagementApi.Mappers;

namespace KAPMProjectManagementApi.Services
{
    public class MstRoleProjectService : IMstRoleProjectService
    {
        private readonly IMstRoleProjectRepository _repository;
        public MstRoleProjectService(IMstRoleProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<RoleProjectSimpleResponse> CreateRoleProjectAsync(RoleProjectRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.RoleId);
            if (exist) throw new BadRequestException($"Data with Role Id {reuqest.RoleId} already exist.");

            var role = ProjectRoleMapper.ToRoleProjectFromRequest(reuqest);
            var create = await _repository.CreateAsync(role);
            return create.ToRoleProjectSimpleResponse();
        }

        public async Task<IEnumerable<RoleProjectSimpleResponse>> GetAllRoleProjectAsync()
        {
            var result = await _repository.GetAllAsync();
            return result.Select(p => p.ToRoleProjectSimpleResponse()).ToList();
        }

        public async Task<RoleProjectResponse?> GetRoleProjectByRoleIdAsync(string roleid)
        {
            var result = await _repository.GetByRoleIdAsync(roleid);
            if (result == null) throw new KeyNotFoundException($"Data with Role Id {roleid} not found.");
            return result.ToRoleProjectResponses();
        }

        public async Task<RoleProjectSimpleResponse> UpdateRoleProjectAsync(RoleProjectRequestDto reuqest)
        {
            var exist = await _repository.ExistsAsync(reuqest.RoleId);
            if (!exist) throw new KeyNotFoundException($"Data with Role Id {reuqest.RoleId} not found.");

            var role = ProjectRoleMapper.ToRoleProjectFromRequest(reuqest);
            var update = await _repository.UpdateAsync(role);
            return update.ToRoleProjectSimpleResponse();
        }
    }
}