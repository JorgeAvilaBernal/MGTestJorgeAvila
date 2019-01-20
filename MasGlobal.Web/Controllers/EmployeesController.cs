using MasGlobal.Common;
using MasGlobal.Core;
using Newtonsoft.Json;
using System.Configuration;
using System.Web.Http;

namespace MasGlobal.Web.Controllers
{
    public class EmployeesController : ApiController
    {
        public string Get()
        {
            string response = string.Empty;
            Fail error = new Fail();
            var employees = EmployeesCore.GetEmployees(ConfigurationManager.AppSettings["APIUrl"], error);
            EmployeeViewModel vm = new EmployeeViewModel
            {
                Error = error.HasError,
                Message = error.Message
            };
            if (!error.HasError)
                vm.Employees = employees;
            return JsonConvert.SerializeObject(vm);
        }
        
        public string Get(int id)
        {
            string response = string.Empty;
            Fail error = new Fail();
            var employees = EmployeesCore.GetEmployeeById(ConfigurationManager.AppSettings["APIUrl"], id, error);
            EmployeeViewModel vm = new EmployeeViewModel
            {
                Error = error.HasError,
                Message = error.Message
            };
            if (!error.HasError)
                vm.Employees = employees;
            return JsonConvert.SerializeObject(vm);
        }
    }
}
