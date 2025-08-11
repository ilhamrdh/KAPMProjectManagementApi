using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAPMProjectManagementApi.Models
{
    [Table("trn_project_so")]
    public class TrnProjectSO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("TrnProject")]
        [Column("code_project", TypeName = "varchar(50)")]
        public string CodeProject { get; set; } = string.Empty;

        [ForeignKey("MstRoleProject")]
        [Column("role_id", TypeName = "varchar(50)")]
        public string RoleId { get; set; } = default!; // FK master Role Project

        [ForeignKey("MstEmployee")]
        [Column("nipp", TypeName = "varchar(15)")]
        public string Nipp { get; set; } = default!; // FK master Employee

        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; } = default!;

        [Column("start_date")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Column("finish_date")]
        [DataType(DataType.DateTime)]
        public DateTime FinishDate { get; set; }

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

        public virtual MstRoleProject MstRoleProject { get; set; } = default!;

        public virtual MstEmployee MstEmployee { get; set; } = default!;

        public virtual TrnProject TrnProject { get; set; } = default!;

    }

}