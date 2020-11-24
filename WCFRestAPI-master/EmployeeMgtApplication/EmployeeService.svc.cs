using BusinessManager;
using BusinessManager.Interface;
using Common.Contracts;
using Newtonsoft.Json;
using RepositoryManager.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Web;

namespace EmployeeMgtApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
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
            catch(Exception e)
            {
                ErrorClass err = new ErrorClass();
                err.success = false;
                err.message = e.Message;
                throw  new WebFaultException<ErrorClass>(err, HttpStatusCode.NotFound);
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
