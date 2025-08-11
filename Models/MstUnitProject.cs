using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAPMProjectManagementApi.Models
{
    [Table("mst_unit_project")]
    public class MstUnitProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Key]
        [Column("unit_project", TypeName = "varchar(50)")]
        public string UnitProject { get; set; } = default!;

        [Column("unit_desc", TypeName = "varchar(100)")]
        public string UnitDesc { get; set; } = string.Empty;

        [Column("active", TypeName = "varchar(1)")]
        public string Active { get; set; } = "Y";

        [Column("user_add", TypeName = "varchar(100)")]
        public string UserAdd { get; set; } = string.Empty;

        [Column("date_add")]
        [DataType(DataType.DateTime)]
        public DateTime DateAdd { get; set; } = DateTime.Now;

        [Column("user_update", TypeName = "varchar(100)")]
        public string? UserUpdate { get; set; }

        [Column("date_update")]
        [DataType(DataType.DateTime)]
        public DateTime? DateUpdate { get; set; }

        public ICollection<TrnProject> TrnProjects { get; set; } = new List<TrnProject>();

    }
}