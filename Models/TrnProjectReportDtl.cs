using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KAPMProjectManagementApi.Emun;

namespace KAPMProjectManagementApi.Models
{
    [Table("trn_project_report_dtl")]
    public class TrnProjectReportDtl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Key]
        [Column("no_sr")]
        public string NoSr { get; set; } = default!;

        [ForeignKey("TrnProjectReport")]
        [Column("week_no")]
        public string WeekNo { get; set; } = default!;

        [ForeignKey("TrnProject")]
        [Column("code_project")]
        public string CodeProject { get; set; } = default!;

        [ForeignKey("TrnProjectTimeline")]
        [Column("wbs_no", TypeName = "varchar(50)")]
        public string WBSNo { get; set; } = default!;

        [Column("plan_date")]
        [DataType(DataType.DateTime)]
        public DateTime PlanDate { get; set; }

        [Column("actual_date")]
        [DataType(DataType.DateTime)]
        public DateTime ActualDate { get; set; }

        [Column("status")]
        public EProjectReportDtl Status { get; set; }

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

        public virtual TrnProjectTimeline TrnProjectTimeline { get; set; } = default!;

        public virtual ICollection<TrnProjectIssue> TrnProjectIssues { get; set; } = new List<TrnProjectIssue>();
    }
}