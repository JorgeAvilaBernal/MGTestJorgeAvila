using MasGlobal.Common;
using MasGlobal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasGlobal.Core
{
    public static class EmployeesCore
    {
        public static List<Employee> GetEmployees(string url, Fail error)
        {
            error = new Fail();
            List<Employee> baseEmployees = new List<Employee>();
            try
            {
                var employeesDTO = EmployeeObjects.GetEmployees(url);
                //var employeesDTO = EmployeeObjects.GetEmployeeHttpClient(url); //for httpclient

                var hourlyPaidEmployees = from emp in employeesDTO
                                          where emp.ContractTypeName.Equals(ContractType.HourlySalaryEmployee.ToString())
                                          select new HourlyPaidEmployee()
                                          {
                                              ContractTypeName = emp.ContractTypeName,
                                              HourlySalary = emp.HourlySalary,
                                              Id = emp.Id,
                                              MonthlySalary = emp.MonthlySalary,
                                              Name = emp.Name,
                                              RoleDescription = emp.RoleDescription,
                                              RoleName = emp.RoleName,
                                              RoleId = emp.RoleId
                                          };

                var monthlyPaidEmployees = from emp in employeesDTO
                                           where emp.ContractTypeName.Equals(ContractType.MonthlySalaryEmployee.ToString())
                                           select new MonthlyPaidEmployee()
                                           {
                                               ContractTypeName = emp.ContractTypeName,
                                               HourlySalary = emp.HourlySalary,
                                               Id = emp.Id,
                                               MonthlySalary = emp.MonthlySalary,
                                               Name = emp.Name,
                                               RoleDescription = emp.RoleDescription,
                                               RoleName = emp.RoleName,
                                               RoleId = emp.RoleId
                                           };

                baseEmployees.AddRange(hourlyPaidEmployees);
                baseEmployees.AddRange(monthlyPaidEmployees);
                baseEmployees.ForEach(e => e.CalculateSalary());
            }
            catch (Exception ex)
            {
                error.HasError = true;
                error.Message = "Error ocurred getting the employees.";
                error.Exception = ex;
            }
            return baseEmployees;
        }

        public static List<Employee> GetEmployeeById(string url, int Id, Fail error)
        {
            error = new Fail();
            List<Employee> baseEmployee = new List<Employee>();
            try
            {
                var employeesDTO = GetEmployees(url, error);
                if (!error.HasError)
                    baseEmployee = employeesDTO.Where(e => e.Id.Equals(Id)).ToList();
            }
            catch (Exception ex)
            {
                error.HasError = true;
                error.Message = "Error ocurred getting the employee.";
                error.Exception = ex;
            }
            return baseEmployee;
        }
    }
}
