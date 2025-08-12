using KAPMProjectManagementApi.Dto.MstEmployee;
using KAPMProjectManagementApi.Dto.Web;
using KAPMProjectManagementApi.Interfaces.MasterEmployee;
using Microsoft.AspNetCore.Mvc;

namespace KAPMProjectManagementApi.Controllers
{
    [ApiController]
    [Route("api/master/employee")]
    public class MstEmployeeController : ControllerBase
    {
        private readonly IMstEmployeeService _service;

        public MstEmployeeController(IMstEmployeeService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllEmployeeAsync();
            WebResponse<IEnumerable<EmployeeSimpleResponse>> response = new WebResponse<IEnumerable<EmployeeSimpleResponse>>
            {
                StatusCode = 200,
                Message = "Success Get All Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EmployeeRequestDto request)
        {
            var result = await _service.CreateEmployeeAsync(request);
            WebResponse<EmployeeSimpleResponse> response = new WebResponse<EmployeeSimpleResponse>
            {
                StatusCode = 201,
                Message = "Success Create Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] EmployeeRequestDto request)
        {
            var result = await _service.UpdateEmployeeAsync(request);
            WebResponse<EmployeeSimpleResponse> response = new WebResponse<EmployeeSimpleResponse>
            {
                StatusCode = 200,
                Message = "Success Update Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{nipp}")] // id
        public async Task<IActionResult> GetByRoleId(string nipp)
        {
            var result = await _service.GetEmployeeByNippAsync(nipp);
            WebResponse<EmployeeResponse> response = new WebResponse<EmployeeResponse>
            {
                StatusCode = 200,
                Message = "Success Delete Role Project",
                Data = result
            };
            return Ok(response);
        }
    }
}