using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace KAPMProjectManagementApi.Dto.TrnProjectSO
{
    public class ProjectSORequestCreateDto
    {
        [Required(ErrorMessage = "Code Project is required")]
        [StringLength(50, ErrorMessage = "Code Project must be at most 50 characters long")]
        public string CodeProject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role Id is required")]
        [StringLength(50, ErrorMessage = "Role Id must be at most 50 characters long")]
        public string RoleId { get; set; } = default!; // FK master Role Project
        [Required(ErrorMessage = "Nipp is required")]
        [StringLength(50, ErrorMessage = "Nipp must be at most 50 characters long")]
        public string Nipp { get; set; } = default!; // FK master Employee

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be at most 100 characters long")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.DateTime)]
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [JsonProperty("finish_date")]
        public DateTime FinishDate { get; set; }

        [StringLength(1, ErrorMessage = "Active must be 1 character")]
        [RegularExpression("^[YN]$", ErrorMessage = "Active must be Y or N")]
        public string Active { get; set; } = "Y";
    }

    public class ProjectSORequestUpdateDto
    {
        [Required(ErrorMessage = "Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Code Project is required")]
        [StringLength(50, ErrorMessage = "Code Project must be at most 50 characters long")]
        public string CodeProject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role Id is required")]
        [StringLength(50, ErrorMessage = "Role Id must be at most 50 characters long")]
        public string RoleId { get; set; } = default!; // FK master Role Project
        [Required(ErrorMessage = "Nipp is required")]
        [StringLength(50, ErrorMessage = "Nipp must be at most 50 characters long")]
        public string Nipp { get; set; } = default!; // FK master Employee

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be at most 100 characters long")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.DateTime)]
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [JsonProperty("finish_date")]
        public DateTime FinishDate { get; set; }

        [StringLength(1, ErrorMessage = "Active must be 1 character")]
        [RegularExpression("^[YN]$", ErrorMessage = "Active must be Y or N")]
        public string Active { get; set; } = "Y";
    }
}