using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dotnetmvc6.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        public string EmployeeName  { get; set; }
        [Range(0,150, ErrorMessage ="Age must be between 0 to 150 years")]
        public int Age { get; set; }
        public int Salary { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
