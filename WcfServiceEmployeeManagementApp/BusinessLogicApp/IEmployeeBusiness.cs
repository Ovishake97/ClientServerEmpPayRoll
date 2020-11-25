using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicApp
{
    public interface IEmployeeBusiness
    {
        IList<EmployeeContract> GetAllEmployee();

        EmployeeContract AddEmployee(EmployeeContract employeeContract);

        List<EmployeeContract> AddMultipleEmployees(List<EmployeeContract> employeeContract);

        string UpdateEmployee(EmployeeContract employeeContract, int EmpId);

        EmployeeContract GetById(int empId);

        string DeleteEmployee(int empId);

        IList<EmployeeContract> GetSearchedEmployee(string keyword);
        double GetAverageEmployeeSalary();
    }
}
