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

        // main page action 
        public IActionResult Index () {
            ViewBag.Title = "Index";
            return View (ViewBag.Title);
        }
        // company directory displays all the results 
        public IActionResult Directory (string empSearch) {
            var employees = _employee.Print ();
            if (employees.Count == 0) {
                ViewBag.display = "not-disp";
                return View (employees);
            }
            if (empSearch != null) {
                ViewBag.display = "disp";
                var updatedLists = _employee.Search (empSearch);
                return View (updatedLists);
            } else {
                ViewBag.display = "disp-full";
                return View (employees);
            }
        }
        // form 
        public IActionResult EmployeeForm () {
            ViewBag.Update = false;
            return View ();
        }
        // To create a new employee
        [HttpPost]
        public IActionResult CreateEmployee (EmployeeInformationViewModel employee) {
            if (ModelState.IsValid) {
                var Employee = new EmployeeInformation () {
                    Id = Guid.NewGuid (),
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Age = employee.Age,
                    Designation = employee.Designation,
                    Salary = employee.Salary,
                    Date = DateTime.Now,
                    Rating = 10
                };
                _employee.Create (Employee);
                return RedirectToAction ("Directory");
            }
            return View ("EmployeeForm", employee);
        }

        // to display the performance of all the employees
        public IActionResult Performance () {
            var performance = new PerformanceViewModel ();
            performance.DataPoint = new List<DataPointViewModel> ();
            performance.Rating = new List<RatingViewModel> ();
            var updatedEmployes = _employee.Print ();
            for (int i = 0; i < updatedEmployes.Count; i++) {
                performance.Rating.Add (new RatingViewModel {
                    Id = updatedEmployes[i].Id,
                        FirstName = updatedEmployes[i].FirstName,
                        Rating = updatedEmployes[i].Rating
                });

                performance.DataPoint.Add ((new DataPointViewModel (updatedEmployes[i].FirstName, updatedEmployes[i].Rating)));
            }
            ViewBag.DataPoints = JsonConvert.SerializeObject (performance.DataPoint);
            return View (performance);
        }
        // edit the employee
        public IActionResult Edit (Guid empId) {
            var employeeEdit = _employee.SearchId (empId);
            var EmployeeInformationViewModelUpdated = new EmployeeInformationViewModel () {
                Id = employeeEdit.Id,
                FirstName = employeeEdit.FirstName,
                LastName = employeeEdit.LastName,
                Age = employeeEdit.Age,
                Salary = employeeEdit.Salary,
                Designation = employeeEdit.Designation,
                Date = employeeEdit.Date
            };
            ViewBag.Update = true;
            return View ("EmployeeForm", EmployeeInformationViewModelUpdated);
        }

        [HttpPost]
        public IActionResult UpdateEmployee (EmployeeInformationViewModel employee) {
            if (ModelState.IsValid) {
                var employeeView = new EmployeeInformation () {
                    Id = employee.Id.Value,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Age = employee.Age,
                    Designation = employee.Designation,
                    Salary = employee.Salary
                };
                _employee.Update (employeeView);
                return RedirectToAction ("Directory");
            } else {
                ViewBag.Update = true;
                return View ("EmployeeForm", employee);
            }
        }
        // delete the employee
        [HttpGet]
        public IActionResult Delete (Guid empId) {
            _employee.DeleteId (empId);
            return RedirectToAction ("Directory");
        }
        // search the employee
        public IActionResult Search (string empSearch) {
            ViewData["Emp"] = empSearch;
            return RedirectToAction ("Directory", "Employee", new { empSearch = empSearch });
        }
        // Rating update 
        public IActionResult RatingUpdate (string popularity, int value, Guid Id) {
            _employee.Rank (popularity, value, Id);
            return RedirectToAction ("Performance");
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}