using System.ComponentModel.DataAnnotations;

namespace Employee_Dept_Crud.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public string? Imageurl { get; set; }
        [Required]
        [Display(Name = "Dept Name")]
        public int Did { get; set; }
        [Display(Name ="Dept Name")]
        public string? Dname { get; set; }
    }
}
