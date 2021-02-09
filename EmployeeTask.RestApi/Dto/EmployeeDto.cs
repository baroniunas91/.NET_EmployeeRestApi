using System.ComponentModel.DataAnnotations;

namespace EmployeeTask.RestApi.Dto
{
    public class EmployeeDto
    {
        [Required]
        [Range(0, 100000.00)]
        public decimal CurrentSalary { get; set; }
    }
}
