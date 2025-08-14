using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KAPMProjectManagementApi.Emun;

namespace KAPMProjectManagementApi.Models
{
    [Table("trn_project")]
    public class TrnProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Key]
        [Column("project_def", TypeName = "varchar(50)")]
        public string ProjectDef { get; set; } = string.Empty;

        [Column("project_desc", TypeName = "varchar(50)")]
        public string ProjectDesc { get; set; } = string.Empty;

        [ForeignKey("MstUnitProject")]
        [Column("project_profile", TypeName = "varchar(50)")]
        public string ProjectProfile { get; set; } = string.Empty; // FK Unit Project

        [ForeignKey("MstProjectManager")]
        [Column("project_responsible", TypeName = "varchar(50)")]
        public string ProjectResponsible { get; set; } = string.Empty; // FK PM

        [Column("project_owner", TypeName = "varchar(50)")]
        public string ProjectOwner { get; set; } = string.Empty;

        [Column("project_location", TypeName = "varchar(50)")]
        public string ProjectLocation { get; set; } = string.Empty;

        [Column("start_date")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Column("fiscal_year")]
        [DataType(DataType.DateTime)]
        public DateTime FiscalYear { get; set; }

        [Column("no_spmk", TypeName = "varchar(50)")]
        public string NoSPMK { get; set; } = string.Empty;

        [Column("no_contract", TypeName = "varchar(50)")]
        public string NoContract { get; set; } = string.Empty;

        [Column("start_date_spmk")]
        [DataType(DataType.DateTime)]
        public DateTime StartDateSPMK { get; set; }

        [Column("payment_method", TypeName = "varchar(50)")]
        public string PaymentMethod { get; set; } = string.Empty;

        [Column("contract_value", TypeName = "varchar(50)")]
        public string ContractValue { get; set; } = string.Empty;

        [Column("bank", TypeName = "varchar(10)")]
        public string Bank { get; set; } = string.Empty;

        [Column("account_number", TypeName = "varchar(50)")]
        public string AccountNumber { get; set; } = string.Empty;

        [Column("account_name", TypeName = "varchar(50)")]
        public string AccountName { get; set; } = string.Empty;

        [Column("working_method", TypeName = "varchar(50)")]
        public string WorkingMethod { get; set; } = string.Empty;

        [Column("pph", TypeName = "varchar(50)")]
        public string PPH { get; set; } = string.Empty;

        [Column("plan_persentage", TypeName = "decimal(18,2)")]
        public double PlanPersentage { get; set; }

        [Column("actual_persentage", TypeName = "decimal(18,2)")]
        public double ActualPersentage { get; set; }

        [Column("progress_report", TypeName = "varchar(100)")]
        public string ProgressReport { get; set; } = string.Empty;

        [Column("company_code", TypeName = "varchar(50)")]
        public string CompanyCode { get; set; } = string.Empty;

        [Column("status", TypeName = "varchar(50)")]
        public EProjectStatus Status { get; set; }

        [Column("active", TypeName = "varchar(1)")]
        public string Active { get; set; } = "Y";

        [Column("user_add", TypeName = "varchar(50)")]
        public string UserAdd { get; set; } = string.Empty;

        [Column("date_add")]
        [DataType(DataType.DateTime)]
        public DateTime DateAdd { get; set; }

        [Column("user_update", TypeName = "varchar(50)")]
        public string UserUpdate { get; set; } = string.Empty;

        [Column("date_update")]
        [DataType(DataType.DateTime)]
        public DateTime DateUpdate { get; set; }

        public virtual MstUnitProject MstUnitProject { get; set; } = new MstUnitProject();
        public virtual MstProjectManager MstProjectManager { get; set; } = new MstProjectManager();
        public virtual ICollection<TrnProjectReport> TrnProjectReports { get; set; } = new List<TrnProjectReport>();
        public virtual ICollection<TrnProjectTimeline> TrnProjectTimelines { get; set; } = new List<TrnProjectTimeline>();
        public virtual ICollection<TrnProjectSO> TrnProjectSOs { get; set; } = new List<TrnProjectSO>();
        public virtual ICollection<TrnProjectAdendum> TrnProjectAdendums { get; set; } = new List<TrnProjectAdendum>();
        public virtual ICollection<TrnProjectIssue> TrnProjectIssues { get; set; } = new List<TrnProjectIssue>();
        public virtual ICollection<TrnScheduleInvoice> TrnScheduleInvoice { get; set; } = new List<TrnScheduleInvoice>();
        public virtual ICollection<TrnProjectReportDtl> TrnProjectReportDtls { get; set; } = new List<TrnProjectReportDtl>();
    }
}