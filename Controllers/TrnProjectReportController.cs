using KAPMProjectManagementApi.Dto.TrnProjectReport;
using KAPMProjectManagementApi.Dto.Web;
using KAPMProjectManagementApi.Interfaces.TrnProjectReport;
using Microsoft.AspNetCore.Mvc;

namespace KAPMProjectManagementApi.Controllers
{
    [ApiController]
    [Route("api/transaction/project-report")]
    public class TrnProjectReportController : ControllerBase
    {
        private readonly ITrnProjectReportService _service;

        public TrnProjectReportController(ITrnProjectReportService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllProjectReportAsync();
            WebResponse<IEnumerable<ProjectReportSimpleResponse>> response = new WebResponse<IEnumerable<ProjectReportSimpleResponse>>
            {
                StatusCode = 200,
                Message = "Success Get All Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProjectReportRequestDto request)
        {
            var result = await _service.CreateProjectReportAsync(request);
            WebResponse<ProjectReportSimpleResponse> response = new WebResponse<ProjectReportSimpleResponse>
            {
                StatusCode = 201,
                Message = "Success Create Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProjectReportRequestDto request)
        {
            var result = await _service.UpdateProjectReportAsync(request);
            WebResponse<ProjectReportSimpleResponse> response = new WebResponse<ProjectReportSimpleResponse>
            {
                StatusCode = 200,
                Message = "Success Update Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{week_no}")] // id
        public async Task<IActionResult> GetByRoleId(string week_no)
        {
            var result = await _service.GetProjectReportByWeekNoAsync(week_no);
            WebResponse<ProjectReportResponse> response = new WebResponse<ProjectReportResponse>
            {
                StatusCode = 200,
                Message = "Success Delete Role Project",
                Data = result
            };
            return Ok(response);
        }
    }
}