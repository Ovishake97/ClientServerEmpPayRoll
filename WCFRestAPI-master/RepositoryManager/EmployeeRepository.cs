using Common.Contracts;
using RepositoryManager.Interface;
using RepositoryManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryManager
{
    public class EmployeeRepository : IEmployeeRepository
    {
        payroll_serviceEntities employeeManagementEntitiesObj;
        public EmployeeRepository()
        {
            employeeManagementEntitiesObj = new payroll_serviceEntities();
        }

        public EmployeeContract AddEmployee(EmployeeContract employeeContract)
        {
            EmployeeDetail employee = new EmployeeDetail()
            {
                Name = employeeContract.Name,
                Email = employeeContract.Email,
                Salary = employeeContract.Salary
            };
            employeeManagementEntitiesObj.EmployeeDetails.Add(employee);
            employeeManagementEntitiesObj.SaveChanges();
            employeeContract.Id = employee.Id;
            return employeeContract;


        }

        public int DeleteEmployee(int empId)
        {
            var employee = (from a in employeeManagementEntitiesObj.EmployeeDetails 
                            where a.Id == empId select a).FirstOrDefault();
            if(employee!=null)
            {
                employeeManagementEntitiesObj.EmployeeDetails.Remove(employee);
                return employeeManagementEntitiesObj.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public IList<EmployeeContract> GetAllEmployee()
        {
            var query = (from a in employeeManagementEntitiesObj.EmployeeDetails select a).Distinct();
            List<EmployeeContract> employeeData = new List<EmployeeContract>();

            query.ToList().ForEach(x =>
            {
                employeeData.Add(new EmployeeContract
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Salary = (int)x.Salary
                });
            });

            return employeeData;
        }

        public EmployeeContract GetById(int empId)
        {
            var Employee = employeeManagementEntitiesObj.EmployeeDetails
                .Find(empId);
            EmployeeContract employeeContract = new EmployeeContract()
            {
                Name = Employee.Name,
                Email = Employee.Email,
                Salary = (int)Employee.Salary,
                Id = Employee.Id
            };
            return employeeContract;
        }

        public int UpdateEmployee(EmployeeContract employeeContract, int EmpId)
        {
            EmployeeDetail employee = employeeManagementEntitiesObj
                .EmployeeDetails.Find(EmpId);
            if(employee != null)
            {
                employee.Email = employeeContract.Email;
                employee.Name = employeeContract.Name;
                employee.Salary = employeeContract.Salary;
                return employeeManagementEntitiesObj.SaveChanges();
            }
            else
            {
                throw new Exception("Employee do not exists");
            }
        }

        public EmployeeContract GetEmployeeByEmail(string email)
        {
            EmployeeDetail employeeDetail = (from a in employeeManagementEntitiesObj.EmployeeDetails 
                                             where a.Email == email select a).FirstOrDefault();
            if(employeeDetail != null)
            {
                EmployeeContract employeeContract = new EmployeeContract()
                {
                    Name = employeeDetail.Name,
                    Email = employeeDetail.Email,
                    Salary = (int)employeeDetail.Salary,
                    Id = employeeDetail.Id
                };
                return employeeContract;
            }

            return null;
        }

        public IList<EmployeeContract> GetSearchedEmployee(string keyword)
        {
            var data = (from a in employeeManagementEntitiesObj.EmployeeDetails where a.Email.ToLower().Contains(keyword.ToLower()) select a).Distinct();
            List<EmployeeContract> employeeData = new List<EmployeeContract>();

            data.ToList().ForEach(x =>
            {
                employeeData.Add(new EmployeeContract
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Salary = (int)x.Salary
                });
            });

            return employeeData;
        }

        public double GetAverageEmployeeSalary()
        {
            double data = (double)(from a in employeeManagementEntitiesObj.EmployeeDetails
                        select new
                        {
                            Salary = a.Salary
                        }).Average(x=>x.Salary);
            return data;
        }
    }
}
