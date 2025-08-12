using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAPMProjectManagementApi.Models
{
    [Table("mst_employee")]
    public class MstEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Key]
        [Column("nipp", TypeName = "varchar(15)")]
        public string Nipp { get; set; } = default!;

        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; } = default!;

        [Column("grade", TypeName = "varchar(5)")]
        public string Grade { get; set; } = string.Empty;

        [Column("plans", TypeName = "varchar(50)")]
        public string Plans { get; set; } = string.Empty;

        [Column("orgeh", TypeName = "varchar(100)")]
        public string Orgeh { get; set; } = string.Empty;

        [Column("persa", TypeName = "varchar(100)")]
        public string Persa { get; set; } = string.Empty;

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

        public virtual TrnProjectSO TrnProjectSO { get; set; } = default!;
    }
}