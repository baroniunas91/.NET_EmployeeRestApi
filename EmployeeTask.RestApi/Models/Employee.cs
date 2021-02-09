using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTask.RestApi.Models
{
    public class Employee : IValidatableObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EmploymentDate { get; set; }
        [Required]
        public string HomeAddress { get; set; }
        [Required]
        [Range(0, 100000.00)]
        public decimal CurrentSalary { get; set; }
        [Required]
        public string Role { get; set; }
        public int? BossId { get; set; }
        public Employee Boss { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Validate names
            int validateNames = string.Compare(FirstName, LastName);
            if (validateNames == 0)
            {
                yield return new ValidationResult("FirstName and LastName should not be equal!", new[] { "FirstName" });
            }
            //Validate age
            DateTime today = DateTime.Today;
            int age = today.Year - Birthdate.Year;
            if (age < 18 || age > 70)
            {
                yield return new ValidationResult("Employee must be at least 18 years old and not older than 70 years!", new[] { "Birthdate" });
            }
            //Validate employment date: is it earlier than 2000-01-01
            DateTime bday = EmploymentDate;
            int validateEmploymentDate = DateTime.Compare(EmploymentDate, new DateTime(2000,01,01));
            if (validateEmploymentDate < 0)
            {
                yield return new ValidationResult("EmploymentDate cannot be earlier than 2000-01-01!", new[] { "EmploymentDate" });
            }
            //Validate employment date: is it not a future date
            int validateEmploymentDateFuture = DateTime.Compare(today, EmploymentDate);
            if (validateEmploymentDateFuture < 0)
            {
                yield return new ValidationResult("EmploymentDate cannot be a future date!", new[] { "EmploymentDate" });
            }
        }
    }
}
