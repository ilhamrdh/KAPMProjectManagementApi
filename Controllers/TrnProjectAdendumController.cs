using KAPMProjectManagementApi.Dto.TrnProjectAdendum;
using KAPMProjectManagementApi.Dto.Web;
using KAPMProjectManagementApi.Interfaces.TrnProjectAdendum;
using Microsoft.AspNetCore.Mvc;

namespace KAPMProjectManagementApi.Controllers
{
    [ApiController]
    [Route("api/transaction/project-adendum")]
    public class TrnProjectAdendumController : ControllerBase
    {
        private readonly ITrnProjectAdendumService _service;

        public TrnProjectAdendumController(ITrnProjectAdendumService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllProjectAdendumAsync();
            WebResponse<IEnumerable<ProjectAdendumSimpleResponse>> response = new WebResponse<IEnumerable<ProjectAdendumSimpleResponse>>
            {
                StatusCode = 200,
                Message = "Success Get All Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProjectAdendumRequestDto request)
        {
            var result = await _service.CreateProjectAdendumAsync(request);
            WebResponse<ProjectAdendumSimpleResponse> response = new WebResponse<ProjectAdendumSimpleResponse>
            {
                StatusCode = 201,
                Message = "Success Create Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProjectAdendumRequestDto request)
        {
            var result = await _service.UpdateProjectAdendumAsync(request);
            WebResponse<ProjectAdendumSimpleResponse> response = new WebResponse<ProjectAdendumSimpleResponse>
            {
                StatusCode = 200,
                Message = "Success Update Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{no}")] // id
        public async Task<IActionResult> GetByRoleId(string no)
        {
            var result = await _service.GetProjectAdendumByAdendumNoAsync(no);
            WebResponse<ProjectAdendumResponse> response = new WebResponse<ProjectAdendumResponse>
            {
                StatusCode = 200,
                Message = "Success Delete Role Project",
                Data = result
            };
            return Ok(response);
        }
    }
}