using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasGlobal.Web.Controllers;
using System.Web.Helpers;

namespace MasGlobal.Web.Tests.Controllers
{
    [TestClass]
    public class EmployeesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            EmployeesController controller = new EmployeesController();
            
            string result = controller.Get();
            
            Assert.IsNotNull(result);
            var emps = Json.Decode(result);
            Assert.AreEqual(2, emps.Length);
        }

        [TestMethod]
        public void GetById()
        {
            EmployeesController controller = new EmployeesController();
            
            string result = controller.Get(1);
            
            Assert.IsNotNull(result);
        }
    }
}
