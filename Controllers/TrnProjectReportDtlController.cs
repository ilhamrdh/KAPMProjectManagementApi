using KAPMProjectManagementApi.Dto.TrnProjectReportDetail;
using KAPMProjectManagementApi.Dto.Web;
using KAPMProjectManagementApi.Interfaces.TrnProjectReportDtl;
using Microsoft.AspNetCore.Mvc;

namespace KAPMProjectManagementApi.Controllers
{
    [ApiController]
    [Route("api/transaction/project-report-detail")]
    public class TrnProjectReportDtlController : ControllerBase
    {
        private readonly ITrnProjectReportDtlService _service;

        public TrnProjectReportDtlController(ITrnProjectReportDtlService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllProjectReportDtlAsync();
            WebResponse<IEnumerable<ProjectReportDetailSimpleResponse>> response = new WebResponse<IEnumerable<ProjectReportDetailSimpleResponse>>
            {
                StatusCode = 200,
                Message = "Success Get All Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProjectReportDetailRequestDto request)
        {
            var result = await _service.CreateProjectReportDtlAsync(request);
            WebResponse<ProjectReportDetailSimpleResponse> response = new WebResponse<ProjectReportDetailSimpleResponse>
            {
                StatusCode = 201,
                Message = "Success Create Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProjectReportDetailRequestDto request)
        {
            var result = await _service.UpdateProjectReportDtlAsync(request);
            WebResponse<ProjectReportDetailSimpleResponse> response = new WebResponse<ProjectReportDetailSimpleResponse>
            {
                StatusCode = 200,
                Message = "Success Update Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{no_sr}")] // id
        public async Task<IActionResult> GetByRoleId(string no_sr)
        {
            var result = await _service.GetProjectReportDtlByNoSrAsync(no_sr);
            WebResponse<ProjectReportDetailResponse> response = new WebResponse<ProjectReportDetailResponse>
            {
                StatusCode = 200,
                Message = "Success Delete Role Project",
                Data = result
            };
            return Ok(response);
        }
    }
}