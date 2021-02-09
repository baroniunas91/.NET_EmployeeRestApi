using EmployeeTask.RestApi.Data;
using EmployeeTask.RestApi.Dto;
using EmployeeTask.RestApi.Interfaces;
using EmployeeTask.RestApi.Models;
using EmployeeTask.RestApi.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTask.RestApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        private readonly EmployeeService _employeeService;

        public EmployeeRepository(DataContext context, EmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = await _context.Employees.OrderBy(x => x.Id).ToListAsync();
            return employees;
        }

        public async Task AddEmployee(Employee employee)
        {
            var ceo = await _context.Employees.Where(x => x.Role.ToLower() == "ceo").ToListAsync();
            if (ceo.Count != 0)
            {
                if (employee.Role.ToLower() == "ceo")
                {
                    throw new ArgumentException(
                        $"Only one employee can be with CEO role!");
                }
            }
            try
            {
                if (employee.Role.ToLower() == "ceo")
                {
                    employee.BossId = null;
                }
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception(
                        $"You have to enter boss id from employees list! If you do not have any employees, you have to create employee with CEO role first");
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeSalary(int id, EmployeeDto employeeDto)
        {
            var employee = _context.Employees.First(x => x.Id == id);
            employee.CurrentSalary = employeeDto.CurrentSalary;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = _context.Employees.First(i => i.Id == id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> SearchEmployee(EmployeeSearchDto employeeSearchDto)
        {
            var employee = await _context.Employees.Where(i => i.FirstName.Contains(employeeSearchDto.FirstName) && i.Birthdate > employeeSearchDto.BirthdateFrom && i.Birthdate < employeeSearchDto.BirthdateUpTo).ToListAsync();
            return employee;
        }

        public async Task<List<Employee>> GetEmployeesByBossId(int id)
        {
            var employees = await _context.Employees.Where(x => x.BossId == id).ToListAsync();
            return employees;
        }

        public async Task<EmployeeByRoleDto> GetCountAndAvgSalary(string role)
        {
            var answer = new EmployeeByRoleDto();
            var employeesByRole = await _context.Employees.Where(x => x.Role == role).ToListAsync();
            int employeeCount = employeesByRole.Count;

            answer.EmployeeCount = employeeCount;
            answer.AverageSalary = _employeeService.CalculateAvgSalary(employeesByRole, employeeCount);
            return answer;
        }
    }
}
