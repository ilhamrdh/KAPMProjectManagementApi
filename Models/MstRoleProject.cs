using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KAPMProjectManagementApi.Emun;

namespace KAPMProjectManagementApi.Models
{
    [Table("mst_role_project")]
    public class MstRoleProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Key]
        [Column("role_id", TypeName = "varchar(50)")]
        public string RoleId { get; set; } = default!;

        [Column("role_type")]
        [EnumDataType(typeof(EProjectRole))]
        public EProjectRole RoleType { get; set; }

        [Column("role_name", TypeName = "varchar(50)")]
        public string RoleName { get; set; } = default!;

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

        public virtual ICollection<TrnProjectSO> ProjectSOs { get; set; } = new List<TrnProjectSO>();
    }
}