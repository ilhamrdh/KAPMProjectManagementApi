using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Dto.TrnProject;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnScheduleInvoice
{
    public class ScheduleInvoiceResponse
    {
        [JsonProperty("no")]
        public string No { get; set; } = default!;

        [JsonProperty("code_project")]
        public string CodeProject { get; set; } = default!;

        [JsonProperty("type")]
        public ETypeInvoice Type { get; set; }

        [JsonProperty("progress_report")]
        public string ProgressReport { get; set; } = default!;

        [JsonProperty("date_plan")]
        [DataType(DataType.DateTime)]
        public DateTime DatePlan { get; set; }

        [JsonProperty("date_actual")]
        [DataType(DataType.DateTime)]
        public DateTime DateActual { get; set; }

        [JsonProperty("total_plan")]
        public int TotalPlan { get; set; }

        [JsonProperty("status")]
        public EStatusInvoice Status { get; set; }

        [JsonProperty("active")]
        public string Active { get; set; } = string.Empty;

        [JsonProperty("project")]
        public virtual ProjectSimpleResponse TrnProject { get; set; } = default!;
    }

    public class ScheduleInvoiceSimpleResponse
    {
        [JsonProperty("no")]
        public string No { get; set; } = default!;

        [JsonProperty("type")]
        public ETypeInvoice Type { get; set; }

        [JsonProperty("progress_report")]
        public string ProgressReport { get; set; } = default!;

        [JsonProperty("date_plan")]
        [DataType(DataType.DateTime)]
        public DateTime DatePlan { get; set; }

        [JsonProperty("date_actual")]
        [DataType(DataType.DateTime)]
        public DateTime DateActual { get; set; }

        [JsonProperty("total_plan")]
        public int TotalPlan { get; set; }

        [JsonProperty("status")]
        public EStatusInvoice Status { get; set; }
    }
}