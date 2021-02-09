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
    }
}
