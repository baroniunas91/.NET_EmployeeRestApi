using EmployeeTask.RestApi.Dto;
using EmployeeTask.RestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeTask.RestApi.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetEmployee(int id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task UpdateEmployeeSalary(int id, EmployeeDto employeeDto);
        Task DeleteEmployee(int id);
        Task<List<Employee>> SearchEmployee(EmployeeSearchDto employeeSearchDto);
        Task<List<Employee>> GetEmployeesByBossId(int id);
        Task<EmployeeByRoleDto> GetCountAndAvgSalary(string role);
    }
}
