using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Dto.MstProjectManager;
using KAPMProjectManagementApi.Dto.MstUnitProject;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProject
{
    public class ProjectResponse
    {
        [JsonProperty("code_project")]
        public string CodeProject { get; set; } = default!;

        [JsonProperty("desc_project")]
        public string DescProject { get; set; } = default!;

        [JsonProperty("no_spmk")]
        public string NoSPMK { get; set; } = string.Empty;

        [JsonProperty("no_contract")]
        public string NoContract { get; set; } = string.Empty;

        [JsonProperty("project_owner")]
        public string ProjectOwner { get; set; } = default!;

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; } = default!;
        [JsonProperty("contract_value")]
        public string ContractValue { get; set; } = string.Empty;
        [JsonProperty("bank")]
        public string Bank { get; set; } = string.Empty;
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; } = string.Empty;
        [JsonProperty("account_name")]
        public string AccountName { get; set; } = string.Empty;
        [JsonProperty("working_method")]
        public string WorkingMethod { get; set; } = string.Empty;
        [JsonProperty("pph")]
        public string PPH { get; set; } = string.Empty;
        [JsonProperty("start_date_spmk")]
        public DateTime StartDateSPMK { get; set; }
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }
        [JsonProperty("finish_date")]
        public DateTime FinishDate { get; set; }
        [JsonProperty("plan_persentage")]
        public double PlanPersentage { get; set; }
        [JsonProperty("actual_persentage")]
        public double ActualPersentage { get; set; }
        [JsonProperty("progress_report")]
        public string ProgressReport { get; set; } = string.Empty;

        [JsonProperty("status")]
        // [EnumDataType(typeof(string))]
        public string Status { get; set; } = default!;

        [JsonProperty("active")]
        public string Active { get; set; } = "Y";

        // Navigation properties untuk response (opsional)
        [JsonProperty("unit_projects")]
        public UnitProjectSimpleResponse? MstUnitProject { get; set; }
        [JsonProperty("project_manager")]
        public ProjectManagerResponse? MstProjectManager { get; set; }
    }

    public class ProjectSimpleResponse
    {
        [JsonProperty("code_project")]
        public string CodeProject { get; set; } = default!;

        [JsonProperty("desc_project")]
        public string DescProject { get; set; } = default!;
    }
}