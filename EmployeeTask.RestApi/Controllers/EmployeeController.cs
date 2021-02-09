using EmployeeTask.RestApi.Dto;
using EmployeeTask.RestApi.Interfaces;
using EmployeeTask.RestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeTask.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            return await _employeeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await _employeeRepository.GetEmployee(id);
        }

        [HttpPost]
        public async Task Add(Employee employee)
        {
            await _employeeRepository.AddEmployee(employee);
        }

        [HttpPut]
        public async Task Update(Employee employee)
        {
            await _employeeRepository.UpdateEmployee(employee);
        }

        [HttpPut("{id}")]
        public async Task UpdateEmployeeSalary(int id, EmployeeDto employeeDto)
        {
            await _employeeRepository.UpdateEmployeeSalary(id, employeeDto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }

        [HttpPost("search")]
        public async Task<List<Employee>> SearchEmployee(EmployeeSearchDto employeeSearchDto)
        {
            return await _employeeRepository.SearchEmployee(employeeSearchDto);
        }

        [HttpGet("byboss/{id}")]
        public async Task<List<Employee>> GetByBossId(int id)
        {
            return await _employeeRepository.GetEmployeesByBossId(id);
        }

        [HttpGet("byrole/{role}")]
        public async Task<EmployeeByRoleDto> GetByRole(string role)
        {
            return await _employeeRepository.GetCountAndAvgSalary(role);
        }
    }
}