using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Dto.Web;
using KAPMProjectManagementApi.Interfaces.TrnProject;
using Microsoft.AspNetCore.Mvc;

namespace KAPMProjectManagementApi.Controllers
{
    [ApiController]
    [Route("api/v1/transaction/project")]
    public class TrnProjectController : ControllerBase
    {
        private readonly ITrnProjectService _service;

        public TrnProjectController(ITrnProjectService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProjectRequestDto request)
        {
            var result = await _service.CreateProjectAsync(request);
            WebResponse<ProjectResponse> response = new WebResponse<ProjectResponse>
            {
                StatusCode = 201,
                Message = "Success Create Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllProjectAsync();
            WebResponse<IEnumerable<ProjectResponse>> response = new WebResponse<IEnumerable<ProjectResponse>>
            {
                StatusCode = 200,
                Message = "Success Get All Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{code_project}")]
        public async Task<IActionResult> GetByCodeProjectAsync(string code_project)
        {
            var result = await _service.GetProjectByCodeProjectAsync(code_project);
            WebResponse<ProjectResponse> response = new WebResponse<ProjectResponse>
            {
                StatusCode = 200,
                Message = "Success Get Project By Code Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProjectRequestDto request)
        {
            var result = await _service.UpdateProjectAsync(request);
            WebResponse<ProjectResponse> response = new WebResponse<ProjectResponse>
            {
                StatusCode = 200,
                Message = "Success Update Project",
                Data = result
            };

            return Ok(response);
        }
    }
}