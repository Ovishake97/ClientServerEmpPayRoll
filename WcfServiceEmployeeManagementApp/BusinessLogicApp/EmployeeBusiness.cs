using Common;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicApp
{
    public class EmployeeBusiness: IEmployeeBusiness
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeBusiness()
        {
            employeeRepository = new EmployeeRepository();
        }
        public EmployeeContract AddEmployee(EmployeeContract employeeContract)
        {
            try
            {
                //if (employeeRepository.GetEmployeeByEmail(employeeContract.Email) != null)
                //{
                //    throw new Exception("Employee already registered, please try with other email id");
                //}
                EmployeeContract empDetails = employeeRepository.AddEmployee(employeeContract);
                if (empDetails.Id > 0)
                {
                    return empDetails;
                }
                else
                {
                    throw new Exception("Employee not able to add.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<EmployeeContract> AddMultipleEmployees(List<EmployeeContract> employeeContract)
        {
            try
            {
                
                List<EmployeeContract> empDetails = employeeRepository.AddMultipleEmployees(employeeContract);
                return empDetails;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<EmployeeContract> GetAllEmployee()
        {
            IList<EmployeeContract> employeeContracts = employeeRepository.GetAllEmployee();
            if (employeeContracts != null)
            {
                return employeeContracts;
            }
            else
            {
                return new List<EmployeeContract>();
            }
        }

        public string UpdateEmployee(EmployeeContract employeeContract, int EmpId)
        {
            if (employeeRepository.UpdateEmployee(employeeContract, EmpId) == 1)
            {
                return "Employee updated successfully";
            }
            else
            {
                return "Employee not updated";
            }
        }

        public EmployeeContract GetById(int empId)
        {
            EmployeeContract employeeContract=null;
            EmployeeDetail Employee = employeeRepository.GetById(empId);
            if (Employee != null)
            {
                employeeContract = new EmployeeContract()
                {
                    Name = Employee.Name,
                    Email = Employee.Email,
                    Salary = (int)Employee.Salary,
                    Id = Employee.Id
                };
                return employeeContract;
            }     
            else
            {
                return employeeContract;
            }
        }

        public string DeleteEmployee(int empId)
        {
            if (employeeRepository.DeleteEmployee(empId) == 1)
            {
                return "Employee deleted successfuly";
            }
            else
            {
                return "Employee does not exists.";
            }
        }

        public IList<EmployeeContract> GetSearchedEmployee(string keyword)
        {
            IList<EmployeeContract> employeeContracts = employeeRepository.GetSearchedEmployee(keyword);
            if (employeeContracts != null)
            {
                return employeeContracts;
            }
            else
            {
                return new List<EmployeeContract>();
            }
        }

        public double GetAverageEmployeeSalary()
        {
            return employeeRepository.GetAverageEmployeeSalary();
        }
    }
}
