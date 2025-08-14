using System.ComponentModel.DataAnnotations;
using KAPMProjectManagementApi.Emun;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProject
{
    public class ProjectRequestDto
    {
        [Required(ErrorMessage = "Project Definition is required")]
        [StringLength(50, ErrorMessage = "Project Definition cannot exceed 50 characters")]
        [JsonProperty("project_def")]
        public string ProjectDef { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "No SPMK cannot exceed 50 characters")]
        [JsonProperty("no_spmk")]
        public string NoSPMK { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "No Contract cannot exceed 50 characters")]
        [JsonProperty("no_contract")]
        public string NoContract { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Project Owner cannot exceed 50 characters")]
        [JsonProperty("project_owner")]
        public string ProjectOwner { get; set; } = default!;

        [Required(ErrorMessage = "Unit Project is required")]
        [StringLength(50, ErrorMessage = "Unit Project cannot exceed 50 characters")]
        [JsonProperty("unit_project")]
        public string UnitProject { get; set; } = default!;

        [Required(ErrorMessage = "PM Project is required")]
        [StringLength(50, ErrorMessage = "PM Project cannot exceed 50 characters")]
        [JsonProperty("pm_project")]
        public string PMProject { get; set; } = default!;

        [Required(ErrorMessage = "Payment Method is required")]
        [StringLength(50, ErrorMessage = "Payment Method cannot exceed 50 characters")]
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; } = default!;

        [StringLength(50, ErrorMessage = "Contract Value cannot exceed 50 characters")]
        [JsonProperty("contract_value")]
        public string ContractValue { get; set; } = string.Empty;

        [StringLength(10, ErrorMessage = "Bank cannot exceed 10 characters")]
        [JsonProperty("bank")]
        public string Bank { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Account Number cannot exceed 50 characters")]
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Account Name cannot exceed 50 characters")]
        [JsonProperty("account_name")]
        public string AccountName { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Working Method cannot exceed 50 characters")]
        [JsonProperty("working_method")]
        public string WorkingMethod { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "PPH cannot exceed 50 characters")]
        [JsonProperty("pph")]
        public string PPH { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start Date SPMK is required")]
        [DataType(DataType.DateTime)]
        [JsonProperty("start_date_spmk")]
        public DateTime StartDateSPMK { get; set; }

        [Range(0, 100, ErrorMessage = "Plan Percentage must be between 0 and 100")]
        [JsonProperty("plan_persentage")]
        public double PlanPersentage { get; set; }

        [Range(0, 100, ErrorMessage = "Actual Percentage must be between 0 and 100")]
        [JsonProperty("actual_persentage")]
        public double ActualPersentage { get; set; }

        [StringLength(100, ErrorMessage = "Progress Report cannot exceed 100 characters")]
        [JsonProperty("progress_report")]
        public string ProgressReport { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        [EnumDataType(typeof(EProjectStatus), ErrorMessage = "Status must be one of: Fast, Normal, TooLate, Critical")]
        [JsonProperty("status")]
        public EProjectStatus Status { get; set; }

        [StringLength(1, ErrorMessage = "Active must be 1 character")]
        [RegularExpression("^[YN]$", ErrorMessage = "Active must be Y or N")]
        [JsonProperty("active")]
        public string Active { get; set; } = "Y";
    }
}