using KAPMProjectManagementApi.Dto.MstProjectManager;
using KAPMProjectManagementApi.Dto.Web;
using KAPMProjectManagementApi.Interfaces.MasterProjectManager;
using Microsoft.AspNetCore.Mvc;

namespace KAPMProjectManagementApi.Controllers
{
    [ApiController]
    [Route("api/v1/master/project-manager")]
    public class MstProjectManagerController : ControllerBase
    {
        private readonly IMstProjectManagerService _service;
        public MstProjectManagerController(IMstProjectManagerService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProjectManager([FromBody] ProjectManagerReuqestDto request)
        {
            var result = await _service.CreateProjectManagerAsync(request);
            WebResponse<ProjectManagerResponse> response = new WebResponse<ProjectManagerResponse>
            {
                StatusCode = 201,
                Message = "Success Create Project Manager",
                Success = true,
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetActionResultAsync()
        {
            var result = await _service.GetAllProjectManagerAsync();
            WebResponse<IEnumerable<ProjectManagerResponse>> response = new WebResponse<IEnumerable<ProjectManagerResponse>>
            {
                StatusCode = 200,
                Message = "Success Get All Project Manager",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{nipp}")]
        public async Task<IActionResult> GetProjectManagerByNippAsync(string nipp)
        {
            var result = await _service.GetProjectManagerByNippAsync(nipp);
            WebResponse<ProjectManagerResponse> response = new WebResponse<ProjectManagerResponse>
            {
                StatusCode = 200,
                Message = "Success Get Project Manager By NIPP",
                Data = result
            };
            return Ok(response);
        }

        [HttpPut("update")] //nipp
        public async Task<IActionResult> UpdateProjectManagerAsync([FromBody] ProjectManagerReuqestDto request)
        {
            var result = await _service.UpdateProjectManagerAsync(request);
            WebResponse<ProjectManagerResponse> response = new WebResponse<ProjectManagerResponse>
            {
                StatusCode = 200,
                Message = "Success Update Project Manager",
                Data = result,
            };
            return Ok(response);
        }
    }
}