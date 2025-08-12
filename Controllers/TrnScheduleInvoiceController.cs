using KAPMProjectManagementApi.Dto.TrnScheduleInvoice;
using KAPMProjectManagementApi.Dto.Web;
using KAPMProjectManagementApi.Interfaces.TrnScheduleInvoice;
using Microsoft.AspNetCore.Mvc;

namespace KAPMProjectManagementApi.Controllers
{
    [ApiController]
    [Route("api/transaction/schedule-invoice")]
    public class TrnScheduleInvoiceController : ControllerBase
    {
        private readonly ITrnScheduleInvoiceService _service;

        public TrnScheduleInvoiceController(ITrnScheduleInvoiceService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllScheduleInvoiceAsync();
            WebResponse<IEnumerable<ScheduleInvoiceSimpleResponse>> response = new WebResponse<IEnumerable<ScheduleInvoiceSimpleResponse>>
            {
                StatusCode = 200,
                Message = "Success Get All Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ScheduleInvoiceRequestDto request)
        {
            var result = await _service.CreateScheduleInvoiceAsync(request);
            WebResponse<ScheduleInvoiceSimpleResponse> response = new WebResponse<ScheduleInvoiceSimpleResponse>
            {
                StatusCode = 201,
                Message = "Success Create Role Project",
                Data = result
            };
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ScheduleInvoiceRequestDto request)
        {
            var result = await _service.UpdateScheduleInvoiceAsync(request);
            WebResponse<ScheduleInvoiceSimpleResponse> response = new WebResponse<ScheduleInvoiceSimpleResponse>
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
            var result = await _service.GetScheduleInvoiceByNoAsync(no);
            WebResponse<ScheduleInvoiceResponse> response = new WebResponse<ScheduleInvoiceResponse>
            {
                StatusCode = 200,
                Message = "Success Delete Role Project",
                Data = result
            };
            return Ok(response);
        }
    }
}