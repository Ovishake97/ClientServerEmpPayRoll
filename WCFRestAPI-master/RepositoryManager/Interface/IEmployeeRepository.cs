using Common.Contracts;
using RepositoryManager.Model;
using System.Collections.Generic;

namespace RepositoryManager.Interface
{
    public interface IEmployeeRepository
    {
        IList<EmployeeContract> GetAllEmployee();

        EmployeeContract AddEmployee(EmployeeContract employeeContract);

        int UpdateEmployee(EmployeeContract employeeContract, int EmpId);

        EmployeeContract GetById(int empId);

        int DeleteEmployee(int empId);

        EmployeeContract GetEmployeeByEmail(string email);

        IList<EmployeeContract> GetSearchedEmployee(string keyword);
        double GetAverageEmployeeSalary();
    }
}




