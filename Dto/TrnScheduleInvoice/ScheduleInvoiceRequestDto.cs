using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnScheduleInvoice
{
    public class ScheduleInvoiceRequestDto
    {
        [JsonProperty("no")]
        [Required(ErrorMessage = "No is required")]
        [StringLength(50, ErrorMessage = "No must be at most 50 characters")]
        public string No { get; set; } = default!;

        [JsonProperty("project_def")]
        [Required(ErrorMessage = "Project Def is required")]
        [StringLength(50, ErrorMessage = "Project Def must be at most 50 characters")]
        public string ProjectDef { get; set; } = default!;

        [JsonProperty("type")]
        [EnumDataType(typeof(ETypeInvoice), ErrorMessage = "Status must be one of: DP, Termin, ZeroToHundred, Monthly")]
        public ETypeInvoice Type { get; set; }

        [JsonProperty("progress_report")]
        [Required(ErrorMessage = "Progress Report is required")]
        [StringLength(100, ErrorMessage = "Progress Report must be at most 100 characters")]
        public string ProgressReport { get; set; } = default!;

        [JsonProperty("date_plan")]
        [DataType(DataType.DateTime)]
        public DateTime DatePlan { get; set; }

        [JsonProperty("date_actual")]
        [DataType(DataType.DateTime)]
        public DateTime DateActual { get; set; }

        [JsonProperty("total_plan")]
        [Range(0, int.MaxValue, ErrorMessage = "Total Plan must be greater than or equal to 0")]
        public int TotalPlan { get; set; }

        [JsonProperty("status")]
        [EnumDataType(typeof(EStatusInvoice), ErrorMessage = "Status must be one of: Waiting, Requsted, OnProgress, Deliver")]
        public EStatusInvoice Status { get; set; }

        [JsonProperty("active")]
        [StringLength(1, ErrorMessage = "Active must be 1 character")]
        [RegularExpression("^[YN]$", ErrorMessage = "Active must be Y or N")]
        public string Active { get; set; } = string.Empty;
    }
}