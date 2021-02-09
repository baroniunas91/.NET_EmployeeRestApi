using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTask.RestApi.Dto
{
    public class EmployeeSearchDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthdateFrom { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthdateUpTo { get; set; }
    }
}