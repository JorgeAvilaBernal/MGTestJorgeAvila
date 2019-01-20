using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasGlobal.Core;
using MasGlobal.Common;
using System.Collections.Generic;
using System.Configuration;

namespace MasGlobal.Web.Tests.Core
{
    [TestClass]
    public class EmployeesCoreTest
    {
        [TestMethod]
        public void GetEmployees()
        {
            Fail error = new Fail();
            List<Employee> emps = EmployeesCore.GetEmployeesAsync(ConfigurationManager.AppSettings["APIUrl"], error);
            Assert.IsNotNull(emps);
            foreach (var item in emps)
                Assert.IsFalse(item.YearlySalary.Equals(0));
        }

        [TestMethod]
        public void GetEmployeeById()
        {
            Fail error = new Fail();
            List<Employee> emps = EmployeesCore.GetEmployeeById(ConfigurationManager.AppSettings["APIUrl"], 1, error);
            Assert.IsNotNull(emps);
            Assert.IsTrue(emps.Count.Equals(1));
            Assert.IsFalse(emps[0].YearlySalary.Equals(0));
        }
    }
}
