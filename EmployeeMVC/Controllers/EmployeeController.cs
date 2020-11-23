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
using Newtonsoft.Json;

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
            // var age = Convert.ToInt32 (_emp.Age);
            // var sal = Convert.ToInt32 (_emp.Salary);
            if (ModelState.IsValid) {
                _employee.Create (_emp.FirstName, _emp.LastName, _emp.Age, _emp.Designation, _emp.Salary);
                return RedirectToAction ("Directory");
            }
            return View ("EmployeeForm", _emp);
        }

        public IActionResult Performance (List<EmployeeInformation> employee) {

            List<DataPointViewModel> dataPoints = new List<DataPointViewModel> ();
            dataPoints.Add ((new DataPointViewModel ("Ramandeep", 40)));
            ViewBag.DataPoints = JsonConvert.SerializeObject (dataPoints);
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}