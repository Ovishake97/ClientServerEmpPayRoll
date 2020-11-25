using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEmployeeRepository
    {
        IList<EmployeeContract> GetAllEmployee();

        EmployeeContract AddEmployee(EmployeeContract employeeContract);

        List<EmployeeContract> AddMultipleEmployees(List<EmployeeContract> employeeContract);

        int UpdateEmployee(EmployeeContract employeeContract, int EmpId);

        EmployeeDetail GetById(int empId);

        int DeleteEmployee(int empId);

        EmployeeContract GetEmployeeByEmail(string email);

        IList<EmployeeContract> GetSearchedEmployee(string keyword);
        double GetAverageEmployeeSalary();
    }
}
