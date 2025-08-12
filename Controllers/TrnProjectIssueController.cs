using KAPMProjectManagementApi.Dto.TrnProjectIssue;
using KAPMProjectManagementApi.Dto.Web;
using KAPMProjectManagementApi.Interfaces.TrnProjectIssue;
using Microsoft.AspNetCore.Mvc;

namespace KAPMProjectManagementApi.Controllers
{
    [ApiController]
    [Route("api/transaction/issue")]
    public class TrnProjectIssueController : ControllerBase
    {
        private readonly ITrnProjectIssueService _service;

        public TrnProjectIssueController(ITrnProjectIssueService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllProjectIssueAsync();
            WebResponse<IEnumerable<ProjectIssueSimpleResponse>> response = new WebResponse<IEnumerable<ProjectIssueSimpleResponse>>
            {
                StatusCode = 200,
                Message = "Success Get All Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProjectIssueRequestDto request)
        {
            var result = await _service.CreateProjectIssueAsync(request);
            WebResponse<ProjectIssueSimpleResponse> response = new WebResponse<ProjectIssueSimpleResponse>
            {
                StatusCode = 201,
                Message = "Success Create Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProjectIssueRequestDto request)
        {
            var result = await _service.UpdateProjectIssueAsync(request);
            WebResponse<ProjectIssueSimpleResponse> response = new WebResponse<ProjectIssueSimpleResponse>
            {
                StatusCode = 200,
                Message = "Success Update Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{no_issue}")] // id
        public async Task<IActionResult> GetByRoleId(string no_issue)
        {
            var result = await _service.GetProjectIssueByNoIssueAsync(no_issue);
            WebResponse<ProjectIssueResponse> response = new WebResponse<ProjectIssueResponse>
            {
                StatusCode = 200,
                Message = "Success Delete Role Project",
                Data = result
            };
            return Ok(response);
        }
    }
}