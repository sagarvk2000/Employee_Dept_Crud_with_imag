using System.ComponentModel.DataAnnotations;

namespace Employee_Dept_Crud.Models
{
    public class Department
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Did { get; set; }
        [Required]        
        public string? Dname { get; set; }
    }
}
