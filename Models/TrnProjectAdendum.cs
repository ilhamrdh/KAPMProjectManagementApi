using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KAPMProjectManagementApi.Emun;

namespace KAPMProjectManagementApi.Models
{
    [Table("trn_project_adendum")]
    public class TrnProjectAdendum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Key]
        [Column("adendum_no", TypeName = "varchar(50)")]
        public string AdendumNo { get; set; } = default!;

        [Column("type_adendum", TypeName = "varchar(50)")]
        public string TypeAdendum { get; set; } = string.Empty;

        [ForeignKey("TrnProject")]
        [Column("project_def", TypeName = "varchar(50)")]
        public string ProjectDef { get; set; } = default!;

        [ForeignKey("TrnProjectTimeline")]
        [Column("wbs_element", TypeName = "varchar(50)")]
        public string WBSElement { get; set; } = default!;

        [Column("cost_before", TypeName = "decimal(18,2)")]
        public double CostBefore { get; set; }

        [Column("cost_after", TypeName = "decimal(18,2)")]
        public double CostAfter { get; set; }

        [Column("date_before")]
        [DataType(DataType.DateTime)]
        public DateTime DateBefore { get; set; }

        [Column("date_after")]
        [DataType(DataType.DateTime)]
        public DateTime DateAfter { get; set; }

        [Column("reason", TypeName = "varchar(255)")]
        public string Reason { get; set; } = default!;

        [Column("status")]
        public EProjectAdendum Status { get; set; }

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

        public virtual TrnProject? TrnProject { get; set; }

        public virtual TrnProjectTimeline TrnProjectTimeline { get; set; } = default!;

    }
}