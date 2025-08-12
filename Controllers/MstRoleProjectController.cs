using KAPMProjectManagementApi.Dto.MstRoleProject;
using KAPMProjectManagementApi.Dto.Web;
using KAPMProjectManagementApi.Interfaces.MasterRoleProject;
using Microsoft.AspNetCore.Mvc;

namespace KAPMProjectManagementApi.Controllers
{
    [ApiController]
    [Route("api/master/role-project")]
    public class MstRoleProjectController : ControllerBase
    {
        private readonly IMstRoleProjectService _service;

        public MstRoleProjectController(IMstRoleProjectService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllRoleProjectAsync();
            WebResponse<IEnumerable<RoleProjectSimpleResponse>> response = new WebResponse<IEnumerable<RoleProjectSimpleResponse>>
            {
                StatusCode = 200,
                Message = "Success Get All Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RoleProjectRequestDto request)
        {
            var result = await _service.CreateRoleProjectAsync(request);
            WebResponse<RoleProjectSimpleResponse> response = new WebResponse<RoleProjectSimpleResponse>
            {
                StatusCode = 201,
                Message = "Success Create Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] RoleProjectRequestDto request)
        {
            var result = await _service.UpdateRoleProjectAsync(request);
            WebResponse<RoleProjectSimpleResponse> response = new WebResponse<RoleProjectSimpleResponse>
            {
                StatusCode = 200,
                Message = "Success Update Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{role_id}")] // id
        public async Task<IActionResult> GetByRoleId(string role_id)
        {
            var result = await _service.GetRoleProjectByRoleIdAsync(role_id);
            WebResponse<RoleProjectResponse> response = new WebResponse<RoleProjectResponse>
            {
                StatusCode = 200,
                Message = "Success Delete Role Project",
                Data = result
            };
            return Ok(response);
        }
    }
}