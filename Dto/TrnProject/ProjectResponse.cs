using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Dto.MstProjectManager;
using KAPMProjectManagementApi.Dto.MstUnitProject;
using KAPMProjectManagementApi.Dto.TrnProjectTimeline;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProject
{
    public class ProjectResponse
    {
        [JsonProperty("project_def")]
        public string ProjectDef { get; set; } = string.Empty;

        [JsonProperty("project_desc")]
        public string ProjectDesc { get; set; } = string.Empty;

        [JsonProperty("project_owner")]
        public string ProjectOwner { get; set; } = string.Empty;

        [JsonProperty("project_location")]
        public string ProjectLocation { get; set; } = string.Empty;

        [JsonProperty("start_date")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [JsonProperty("fiscal_year")]
        [DataType(DataType.DateTime)]
        public DateTime FiscalYear { get; set; }

        [JsonProperty("no_spmk")]
        public string NoSPMK { get; set; } = string.Empty;

        [JsonProperty("no_contract")]
        public string NoContract { get; set; } = string.Empty;

        [JsonProperty("start_date_spmk")]
        [DataType(DataType.DateTime)]
        public DateTime StartDateSPMK { get; set; }

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; } = string.Empty;

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

        [JsonProperty("plan_persentage")]
        public double PlanPersentage { get; set; }

        [JsonProperty("actual_persentage")]
        public double ActualPersentage { get; set; }

        [JsonProperty("progress_report")]
        public string ProgressReport { get; set; } = string.Empty;

        [JsonProperty("company_code")]
        public string CompanyCode { get; set; } = string.Empty;

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("active")]
        public string Active { get; set; } = string.Empty;

        // Navigation properties untuk response (opsional)
        [JsonProperty("project_profile")]
        public UnitProjectSimpleResponse? MstUnitProject { get; set; }
        [JsonProperty("project_responsible")]
        public ProjectManagerResponse? MstProjectManager { get; set; }
    }

    public class ProjectDetailResponse
    {
        [JsonProperty("project_def")]
        public string ProjectDef { get; set; } = string.Empty;

        [JsonProperty("project_desc")]
        public string ProjectDesc { get; set; } = string.Empty;

        [JsonProperty("project_owner")]
        public string ProjectOwner { get; set; } = string.Empty;

        [JsonProperty("project_location")]
        public string ProjectLocation { get; set; } = string.Empty;

        [JsonProperty("start_date")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [JsonProperty("fiscal_year")]
        [DataType(DataType.DateTime)]
        public DateTime FiscalYear { get; set; }

        [JsonProperty("no_spmk")]
        public string NoSPMK { get; set; } = string.Empty;

        [JsonProperty("no_contract")]
        public string NoContract { get; set; } = string.Empty;

        [JsonProperty("start_date_spmk")]
        [DataType(DataType.DateTime)]
        public DateTime StartDateSPMK { get; set; }

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; } = string.Empty;

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

        [JsonProperty("plan_persentage")]
        public double PlanPersentage { get; set; }

        [JsonProperty("actual_persentage")]
        public double ActualPersentage { get; set; }

        [JsonProperty("progress_report")]
        public string ProgressReport { get; set; } = string.Empty;

        [JsonProperty("company_code")]
        public string CompanyCode { get; set; } = string.Empty;

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("active")]
        public string Active { get; set; } = string.Empty;

        // Navigation properties untuk response (opsional)
        [JsonProperty("project_profile")]
        public UnitProjectSimpleResponse? MstUnitProject { get; set; }
        [JsonProperty("project_responsible")]
        public ProjectManagerResponse? MstProjectManager { get; set; }

        [JsonProperty("project_wbs")]
        public ICollection<ProjectTimelineSimpleResponse> ProjectTimelines { get; set; } = new List<ProjectTimelineSimpleResponse>();

    }

    public class ProjectSimpleResponse
    {
        [JsonProperty("project_def")]
        public string ProjectDef { get; set; } = string.Empty;

        [JsonProperty("project_desc")]
        public string ProjectDesc { get; set; } = string.Empty;

        [JsonProperty("project_owner")]
        public string ProjectOwner { get; set; } = string.Empty;

        [JsonProperty("project_location")]
        public string ProjectLocation { get; set; } = string.Empty;
    }
}