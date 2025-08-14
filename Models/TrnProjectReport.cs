using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KAPMProjectManagementApi.Emun;

namespace KAPMProjectManagementApi.Models
{
    [Table("trn_project_report")]
    public class TrnProjectReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Key]
        [Column("week_no")]
        public string WeekNo { get; set; } = string.Empty;

        [ForeignKey("TrnProject")]
        [Column("project_def", TypeName = "varchar(50)")]
        public string ProjectDef { get; set; } = string.Empty; // FK to trn_project

        [Column("date_report")]
        public DateTime DateReport { get; set; }

        [Column("plan_persentage")]
        public double PlanPersentage { get; set; }

        [Column("actual_persentage")]
        public double ActualPersentage { get; set; }

        [Column("deviation")]
        public ETypeDeviation Deviation { get; set; }

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

        public virtual TrnProject TrnProject { get; set; } = new TrnProject();

        public virtual ICollection<TrnProjectIssue> TrnProjectIssues { get; set; } = new List<TrnProjectIssue>();

        public virtual ICollection<TrnProjectReportDtl> TrnProjectReportDtls { get; set; } = new List<TrnProjectReportDtl>();
    }
}