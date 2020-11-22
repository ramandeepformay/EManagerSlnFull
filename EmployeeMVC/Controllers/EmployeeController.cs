using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmployeeCrudManager;
using EmployeeCrudManager.Models;
using EmployeeMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace EmployeeMVC.Controllers {
    public class EmployeeController : Controller {
        private EmpMgtSys _employee;

        public EmployeeController (EmpMgtSys employee) {
            _employee = employee;
        }

        public IActionResult Index () {
            ViewBag.Title = "Index";
            var employees = _employee.Print ();
            return View (ViewBag.Title);
            // return View ();
        }
        public IActionResult Directory () {
            var employees = _employee.Print ();
            return View (employees);
            // return View ();
        }

        public IActionResult EmployeeForm () {
            return View ();
        }

        [HttpPost]
        public IActionResult CreateEmployee (EmployeeInformationViewModel _emp) {
            var age = Convert.ToInt32 (_emp.Age);
            // var sal = Convert.ToInt32 (_emp.Salary);
            _employee.Create (_emp.FirstName, _emp.LastName, age, _emp.Designation, _emp.Salary);
            return RedirectToAction ("Directory");
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}