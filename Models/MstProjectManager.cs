using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAPMProjectManagementApi.Models
{
    [Table("mst_project_manager")]
    public class MstProjectManager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Key]
        [Column("nipp", TypeName = "varchar(15)")]
        public string Nipp { get; set; } = string.Empty;

        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; } = default!;

        [Column("active", TypeName = "varchar(1)")]
        public string Active { get; set; } = "Y";

        [Column("user_add", TypeName = "varchar(100)")]
        public string? UserAdd { get; set; }

        [Column("date_add")]
        [DataType(DataType.DateTime)]
        public DateTime DateAdd { get; set; } = DateTime.Now;

        [Column("user_update", TypeName = "varchar(100)")]
        public string? UserUpdate { get; set; }

        [Column("date_update")]
        [DataType(DataType.DateTime)]
        public DateTime? DateUpdate { get; set; }

        public virtual TrnProject TrnProject { get; set; } = default!;

    }
}