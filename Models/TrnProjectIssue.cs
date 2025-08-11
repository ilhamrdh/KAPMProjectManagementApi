using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KAPMProjectManagementApi.Emun;

namespace KAPMProjectManagementApi.Models
{
    [Table("trn_project_issue")]
    public class TrnProjectIssue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Key]
        [Column("no_issue")]
        public string NoIssue { get; set; } = default!;

        [ForeignKey("TrnProject")]
        [Column("code_project", TypeName = "varchar(50)")]
        public string CodeProject { get; set; } = default!;

        [ForeignKey("TrnProjectReport")]
        [Column("week_no", TypeName = "varchar(50)")]
        public string WeekNo { get; set; } = default!;

        [ForeignKey("TrnProjectReportDtl")]
        [Column("no_sr", TypeName = "varchar(50)")]
        public string NoSr { get; set; } = default!;

        [Column("wbs_no", TypeName = "varchar(50)")]
        public string WBSNo { get; set; } = default!;

        [Column("problem", TypeName = "varchar(255)")]
        public string Problem { get; set; } = string.Empty;

        [Column("action_plan", TypeName = "varchar(255)")]
        public string ActionPlan { get; set; } = string.Empty;

        [Column("action_problem", TypeName = "varchar(255)")]
        public string ActionProblem { get; set; } = string.Empty;

        [Column("status")]
        public EProjectIssue Status { get; set; }

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

        public virtual TrnProject TrnProject { get; set; } = default!;
        public virtual TrnProjectReport TrnProjectReport { get; set; } = default!;
        public virtual TrnProjectReportDtl TrnProjectReportDtl { get; set; } = default!;
    }
}