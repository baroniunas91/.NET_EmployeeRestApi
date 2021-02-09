using EmployeeTask.RestApi.Models;
using System;
using System.Collections.Generic;

namespace EmployeeTask.RestApi.Services
{
    public class EmployeeService
    {
        public decimal CalculateAvgSalary(List<Employee> employees, int employeesCount)
        {
            if (employeesCount != 0)
            {
                decimal employeesSalariesSum = 0;
                foreach (var employee in employees)
                {
                    employeesSalariesSum += employee.CurrentSalary;
                }
                decimal avgSalary = Math.Floor((employeesSalariesSum / employeesCount) * 100) / 100;
                return avgSalary;
            }
            return 0;
        }
    }
}
