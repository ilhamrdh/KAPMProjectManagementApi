using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAPMProjectManagementApi.Models
{
    [Table("trn_sap_hrd")]
    public class TrnSapHrd
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

        [Column("status_system", TypeName = "varchar(50)")]
        public string StatusSystem { get; set; } = string.Empty;

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
    }
}