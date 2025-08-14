using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAPMProjectManagementApi.Models
{
    [Table("trn_sap_wbs")]
    public class TrnSapWbs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Key]
        [Column("wbs_element", TypeName = "varchar(50)")]
        public string WBSElement { get; set; } = string.Empty;

        [Column("wbs_level", TypeName = "varchar(50)")]
        public int WBSLevel { get; set; }

        [Column("wbs_desc", TypeName = "varchar(50)")]
        public string WBSDesc { get; set; } = string.Empty;

        [Column("project_type", TypeName = "varchar(100)")]
        public string ProjectType { get; set; } = string.Empty;

        [Column("active", TypeName = "varchar(1)")]
        public string Active { get; set; } = "Y";

        [Column("start_date")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

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