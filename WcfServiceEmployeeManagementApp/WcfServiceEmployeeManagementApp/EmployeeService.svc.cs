using BusinessLogicApp;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceEmployeeManagementApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        public List<EmployeeContract> employees;
        private readonly IEmployeeBusiness employeeBusiness;
        public EmployeeService()
        {
            employeeBusiness = new EmployeeBusiness();
        }

        public IList<EmployeeContract> GetAllEmployee()
        {
            return employeeBusiness.GetAllEmployee();
        }

        public EmployeeContract AddEmployee(EmployeeContract employeeContract)
        {
            try
            {
                return employeeBusiness.AddEmployee(employeeContract);
            }
            catch (Exception e)
            {
                ErrorClass err = new ErrorClass();
                err.success = false;
                err.message = e.Message;
                throw new WebFaultException<ErrorClass>(err, HttpStatusCode.NotFound);
                //return null;
            }
        }

        public List<EmployeeContract> AddMultipleEmployees(List<EmployeeContract> employees)
        {
            try
            {
                return employeeBusiness.AddMultipleEmployees(employees);
            }
            catch (Exception e)
            {
                ErrorClass err = new ErrorClass();
                err.success = false;
                err.message = e.Message;
                throw new WebFaultException<ErrorClass>(err, HttpStatusCode.NotFound);
                //return null;
            }
        }

        public EmployeeContract GetById(string empId)
        {
            int employeeId = Convert.ToInt32(empId);
            return employeeBusiness.GetById(employeeId);
        }

        public string DeleteEmployee(string empId)
        {
            int employeeId = Convert.ToInt32(empId);
            return employeeBusiness.DeleteEmployee(employeeId);
        }

        public string UpdateEmployee(EmployeeContract employeeContract, string empId)
        {
            int employeeId = Convert.ToInt32(empId);
            return employeeBusiness.UpdateEmployee(employeeContract, employeeId);
        }

        public IList<EmployeeContract> GetSearchedEmployee(string keyword)
        {
            return employeeBusiness.GetSearchedEmployee(keyword);
        }
        public double GetAverageEmployeeSalary()
        {
            return employeeBusiness.GetAverageEmployeeSalary();
        }
    }
}
