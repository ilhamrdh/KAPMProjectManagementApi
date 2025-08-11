using KAPMProjectManagementApi.Dto.MstUnitProject;
using KAPMProjectManagementApi.Dto.Web;
using KAPMProjectManagementApi.Interfaces.MasterUnitProject;
using Microsoft.AspNetCore.Mvc;

namespace KAPMProjectManagementApi.Controllers
{
    [ApiController]
    [Route("api/v1/master/unit-project")]
    public class MstUnitProjectController : ControllerBase
    {
        private readonly IMstUnitProjectService _service;
        public MstUnitProjectController(IMstUnitProjectService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UnitProjectRequestDto request)
        {
            var result = await _service.CreateUnitProjectAsync(request);
            WebResponse<UnitProjectResponse> response = new WebResponse<UnitProjectResponse>
            {
                StatusCode = 201,
                Message = "Success Create Unit Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllUnitPtojectAsync();
            WebResponse<IEnumerable<UnitProjectResponse>> response = new WebResponse<IEnumerable<UnitProjectResponse>>
            {
                StatusCode = 200,
                Message = "Success Get All Unit Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{unitProject}")]
        public async Task<IActionResult> GetByUnitProjectAsync(string unitProject)
        {
            var result = await _service.GetUnitProjectByUnitCodeAsync(unitProject);
            WebResponse<UnitProjectResponse> response = new WebResponse<UnitProjectResponse>
            {
                StatusCode = 200,
                Message = "Success Get Unit Project By Unit Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UnitProjectRequestDto request)
        {
            var result = await _service.UpdateUnitProjectAsync(request);
            WebResponse<UnitProjectResponse> response = new WebResponse<UnitProjectResponse>
            {
                StatusCode = 200,
                Message = "Success Update Unit Project",
                Data = result
            };
            return Ok(result);
        }

    }
}