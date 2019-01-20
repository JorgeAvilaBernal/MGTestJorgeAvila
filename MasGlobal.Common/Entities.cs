using System;
using System.Collections.Generic;

namespace MasGlobal.Common
{
    public class Fail
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }

    public class EmployeeViewModel
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public List<Employee> Employees { get; set; }
    }
}