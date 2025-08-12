using KAPMProjectManagementApi.Dto.TrnProjectSO;
using KAPMProjectManagementApi.Dto.Web;
using KAPMProjectManagementApi.Interfaces.TrnProjectSO;
using Microsoft.AspNetCore.Mvc;

namespace KAPMProjectManagementApi.Controllers
{
    [ApiController]
    [Route("api/transaction/project-so")]
    public class TrnProjectSOController : ControllerBase
    {
        private readonly ITrnProjectSOService _service;
        public TrnProjectSOController(ITrnProjectSOService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProjectSORequestCreateDto request)
        {
            var result = await _service.CreateProjectSOAsync(request);
            WebResponse<ProjectSOSimpleResponse> response = new WebResponse<ProjectSOSimpleResponse>
            {
                StatusCode = 201,
                Message = "Success Create Project SO",
                Data = result
            };
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProjectSORequestUpdateDto request)
        {
            var result = await _service.UpdateProjectSOAsync(request);
            WebResponse<ProjectSOSimpleResponse> response = new WebResponse<ProjectSOSimpleResponse>
            {
                StatusCode = 200,
                Message = "Success Update Project SO",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllProjectSOAsync();
            WebResponse<IEnumerable<ProjectSOSimpleResponse>> response = new WebResponse<IEnumerable<ProjectSOSimpleResponse>>
            {
                StatusCode = 200,
                Message = "Success Get All Project SO",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{id}")] // code_project
        public async Task<IActionResult> GetByCodeProjectAsync(int id)
        {
            var result = await _service.GetProjectSOByIdAsync(id);
            WebResponse<ProjectSOResponse> response = new WebResponse<ProjectSOResponse>
            {
                StatusCode = 200,
                Message = "Success Get Project SO By Code Project",
                Data = result
            };
            return Ok(response);
        }
    }
}