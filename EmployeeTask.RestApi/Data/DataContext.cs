using EmployeeTask.RestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.RestApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, FirstName = "Dominick", LastName = "Crouch", Birthdate = new System.DateTime(1991,12,22), EmploymentDate = new System.DateTime(2016, 01, 01), HomeAddress = "Vilnius, Ozo g. 30", CurrentSalary = 5000, Role="CEO", BossId = null },
                new Employee() { Id = 2, FirstName = "John", LastName = "Crouch", Birthdate = new System.DateTime(1991,12,22), EmploymentDate = new System.DateTime(2018, 01, 01), HomeAddress = "Vilnius, Ozo g. 30", CurrentSalary = 3000, Role="Project Manager", BossId = 1 },
                new Employee() { Id = 3, FirstName = "Donny", LastName = "Crouch", Birthdate = new System.DateTime(1991,12,22), EmploymentDate = new System.DateTime(2020, 06, 01), HomeAddress = "Vilnius, Ozo g. 30", CurrentSalary = 2000, Role=".NET developer", BossId = 2 },
                new Employee() { Id = 4, FirstName = "Rick", LastName = "Crouch", Birthdate = new System.DateTime(1991,12,22), EmploymentDate = new System.DateTime(2020, 01, 01), HomeAddress = "Vilnius, Ozo g. 30", CurrentSalary = 2000, Role= ".NET developer", BossId = 2 },
                new Employee() { Id = 5, FirstName = "Bill", LastName = "Crouch", Birthdate = new System.DateTime(1991,12,22), EmploymentDate = new System.DateTime(2019, 01, 01), HomeAddress = "Vilnius, Ozo g. 30", CurrentSalary = 2000, Role= ".NET developer", BossId = 2 },
                new Employee() { Id = 6, FirstName = "Rodger", LastName = "Crouch", Birthdate = new System.DateTime(1991,12,22), EmploymentDate = new System.DateTime(2018, 01, 01), HomeAddress = "Vilnius, Ozo g. 30", CurrentSalary = 2000, Role= ".NET developer", BossId = 2 }
            );
        }
    }
}
