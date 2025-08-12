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
        [Column("code_project", TypeName = "varchar(50)")]
        public string CodeProject { get; set; } = default!;

        [Column("desc_project", TypeName = "varchar(50)")]
        public string DescProject { get; set; } = default!;

        [Column("no_spmk", TypeName = "varchar(50)")]
        public string NoSPMK { get; set; } = string.Empty;

        [Column("project_owner", TypeName = "varchar(50)")]
        public string ProjectOwner { get; set; } = default!;

        [Column("no_contract", TypeName = "varchar(50)")]
        public string NoContract { get; set; } = string.Empty;

        [ForeignKey("MstUnitProject")]
        [Column("unit_project", TypeName = "varchar(50)")]
        public string UnitProject { get; set; } = default!; // FK => master unit project

        [ForeignKey("MstProjectManager")]
        [Column("pm_project", TypeName = "varchar(50)")]
        public string PMProject { get; set; } = default!; // FK => master project manager

        [Column("payment_method", TypeName = "varchar(50)")]
        public string PaymentMethod { get; set; } = default!;

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

        [Column("start_date_spmk")]
        [DataType(DataType.DateTime)]
        public DateTime StartDateSPMK { get; set; }

        [Column("start_date")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Column("finish_date")]
        [DataType(DataType.DateTime)]
        public DateTime FinishDate { get; set; }

        [Column("plan_persentage", TypeName = "decimal(18,2)")]
        public double PlanPersentage { get; set; }

        [Column("actual_persentage", TypeName = "decimal(18,2)")]
        public double ActualPersentage { get; set; }

        [Column("progress_report", TypeName = "varchar(100)")]
        public string ProgressReport { get; set; } = string.Empty;

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

        public virtual MstUnitProject MstUnitProject { get; set; } = default!;
        public virtual MstProjectManager MstProjectManager { get; set; } = default!;
        public virtual ICollection<TrnProjectReport> TrnProjectReports { get; set; } = new List<TrnProjectReport>();
        public virtual ICollection<TrnProjectTimeline> TrnProjectTimelines { get; set; } = new List<TrnProjectTimeline>();
        public virtual ICollection<TrnProjectSO> TrnProjectSOs { get; set; } = new List<TrnProjectSO>();
        public virtual ICollection<TrnProjectAdendum> TrnProjectAdendums { get; set; } = new List<TrnProjectAdendum>();
        public virtual ICollection<TrnProjectIssue> TrnProjectIssues { get; set; } = new List<TrnProjectIssue>();
        public virtual ICollection<TrnScheduleInvoice> TrnScheduleInvoice { get; set; } = new List<TrnScheduleInvoice>();
        public virtual ICollection<TrnProjectReportDtl> TrnProjectReportDtls { get; set; } = new List<TrnProjectReportDtl>();
    }
}