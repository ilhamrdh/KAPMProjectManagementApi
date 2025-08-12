using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KAPMProjectManagementApi.Emun;

namespace KAPMProjectManagementApi.Models
{
    [Table("trn_project_timeline")]
    public class TrnProjectTimeline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Key]
        [Column("wbs_no", TypeName = "varchar(50)")]
        public string WBSNo { get; set; } = default!;

        [ForeignKey("TrnProject")]
        [Column("code_project", TypeName = "varchar(50)")]
        public string CodeProject { get; set; } = default!;

        [Column("wbs_level", TypeName = "varchar(50)")]
        public int WBSLevel { get; set; } = default!;

        [Column("wbs_name", TypeName = "varchar(50)")]
        public string WBSName { get; set; } = string.Empty;

        [Column("responsible", TypeName = "varchar(100)")]
        public string Responsible { get; set; } = string.Empty;

        [Column("status")]
        public EProjectTimeline Status { get; set; }

        [Column("active", TypeName = "varchar(1)")]
        public string Active { get; set; } = "Y";

        [Column("start_date")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Column("finish_date")]
        [DataType(DataType.DateTime)]
        public DateTime FinishDate { get; set; }

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

        public virtual TrnProject? TrnProject { get; set; }

        public virtual ICollection<TrnProjectReportDtl> TrnProjectReportDtls { get; set; } = new List<TrnProjectReportDtl>();
        public virtual ICollection<TrnProjectAdendum> TrnProjectAdendums { get; set; } = new List<TrnProjectAdendum>();
    }
}