using KAPMProjectManagementApi.Dto.TrnProjectTimeline;
using KAPMProjectManagementApi.Dto.Web;
using KAPMProjectManagementApi.Interfaces.TrnProjectTimeline;
using Microsoft.AspNetCore.Mvc;

namespace KAPMProjectManagementApi.Controllers
{
    [ApiController]
    [Route("api/v1/transaction/project-timeline")]
    public class TrnProjectTimelineController : ControllerBase
    {
        private readonly ITrnProjectTimelineService _service;

        public TrnProjectTimelineController(ITrnProjectTimelineService service)
        {
            _service = service;
        }

        /// <summary>
        /// Membuat data project timeline baru.
        /// </summary>
        /// <remarks>
        /// Status di isi dengan = Waiting, OnProgress, atau Done
        /// </remarks>
        /// <param name="request">Data request project timeline.</param>
        /// <returns>Status sukses atau gagal.</returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProjectTimelineRequestDto request)
        {
            var result = await _service.CreateProjectTimelineAsync(request);
            WebResponse<ProjectTimelineSimpleResponse> response = new WebResponse<ProjectTimelineSimpleResponse>
            {
                StatusCode = 201,
                Message = "Success Create Project Timeline",
                Data = result
            };
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProjectTimelineRequestDto request)
        {
            var result = await _service.UpdateProjectTimelineAsync(request);
            WebResponse<ProjectTimelineSimpleResponse> response = new WebResponse<ProjectTimelineSimpleResponse>
            {
                StatusCode = 200,
                Message = "Success Update Project Timeline",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllProjectTimelineAsync();
            WebResponse<IEnumerable<ProjectTimelineSimpleResponse>> response = new WebResponse<IEnumerable<ProjectTimelineSimpleResponse>>
            {
                StatusCode = 200,
                Message = "Success Get All Project Timeline",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{wbs_no}")] // wbs_no
        public async Task<IActionResult> GetByCodeProjectAsync(string wbs_no)
        {
            var result = await _service.GetProjectTimelineByNoWBSAsync(wbs_no);
            WebResponse<ProjectTimelineResponse> response = new WebResponse<ProjectTimelineResponse>
            {
                StatusCode = 200,
                Message = "Success Get Project Timeline By Code Project",
                Data = result
            };
            return Ok(response);
        }

    }
}