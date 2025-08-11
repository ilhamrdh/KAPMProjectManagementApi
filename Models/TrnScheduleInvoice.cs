using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KAPMProjectManagementApi.Emun;

namespace KAPMProjectManagementApi.Models
{
    [Table("trn_schedule_invoice")]
    public class TrnScheduleInvoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Key]
        [Column("no", TypeName = "varchar(50)")]
        public string No { get; set; } = default!;

        [ForeignKey("code_project")]
        [Column("code_project", TypeName = "varchar(50)")]
        public string CodeProject { get; set; } = default!;

        [Column("type")]
        public ETypeInvoice Type { get; set; }

        [Column("progress_report", TypeName = "varchar(100)")]
        public string ProgressReport { get; set; } = default!;

        [Column("date_plan")]
        [DataType(DataType.DateTime)]
        public DateTime DatePlan { get; set; }

        [Column("date_actual")]
        [DataType(DataType.DateTime)]
        public DateTime DateActual { get; set; }

        [Column("total_plan")]
        public int TotalPlan { get; set; }

        [Column("status")]
        public EStatusInvoice Status { get; set; }

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

        public virtual TrnProject TrnProject { get; set; } = default!;

    }
}