using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EmployeeCrudManager.Models;
namespace EmployeeCrudManager.Storage {
   public class EmpStorageLists : IEmpStorage {
      private List<EmployeeInformation> _empInformation;

      //  list of all EmployeeInformation is initialized in the constructor
      public EmpStorageLists () {
         _empInformation = new List<EmployeeInformation> ();
      }

      //receives and adding employee to the employee information lists
      public void CreateEmp (EmployeeInformation employee) {
         _empInformation.Add (employee);
      }
      // return all the employees of the company
      public List<EmployeeInformation> Print () {
         if (_empInformation != null) {
            var updatedLists = _empInformation.Select (emp => {
               emp.FirstName = UpperFirstChar (emp.FirstName);
               emp.LastName = UpperFirstChar (emp.LastName);
               emp.Designation = UpperFirstChar (emp.Designation);;
               return emp;
            }).ToList ();
            return updatedLists;
         } else { return null; }

      }

      // search employee in the list using employee id property
      public EmployeeInformation SearchEmpId (Guid empId) {
         for (int i = 0; i < _empInformation.Count; i++) {
            if (empId == _empInformation[i].Id) {
               return _empInformation[i];
            }
         }
         return null;
      }

      // search employees in the list using employee name property
      public List<EmployeeInformation> SearchEmp (string emp) {

         var query = from x in _empInformation select x;
         if (!String.IsNullOrEmpty (emp)) {
            query = query.Where (x => x.FirstName.ToLower ().Contains (emp.ToLower ()));
            return query.ToList ();
         } else {
            return null;
         }
      }

      // delete employee in the list using employee id property
      public void DeleteEmpId (Guid empId) {
         // for (int i = 0; i < _empInformation.Count; i++) {
         //    var res = _empInformation[i];
         //    if (empId == _empInformation[i].Id) {
         //       _empInformation.Remove (_empInformation[i]);
         //       return res;
         //    }
         // }
         // return null;
      }

      // delete employee using employee name property
      public EmployeeInformation DeleteEmp (string emp) {
         for (int i = 0; i < _empInformation.Count; i++) {
            var res = _empInformation[i];
            if (emp == _empInformation[i].FirstName) {
               _empInformation.Remove (_empInformation[i]);
               return res;
            }
         }
         return null;
      }
      public EmployeeInformation Converter (Guid empId) {
         for (int i = 0; i < _empInformation.Count; i++) {
            var res = _empInformation[i];
            if (empId == _empInformation[i].Id) {
               _empInformation.Add (_empInformation[i]);
               return res;
            }
         }
         return null;
      }

      //  update employee
      public void Update (EmployeeInformation employee) {
         var updatedEmployee = Converter (employee.Id);
         updatedEmployee.FirstName = employee.FirstName;
         updatedEmployee.LastName = employee.LastName;
         updatedEmployee.Age = employee.Age;
         updatedEmployee.Designation = employee.Designation;
         updatedEmployee.Salary = employee.Salary;
      }

      public void Rank (string popularity, int value, Guid Id) {

      }

      // to convert the  first character of the name to upper case 
      public string UpperFirstChar (string name) {
         if (name.Length > 0) {
            return char.ToUpper (name[0]) + name.Substring (1);
         } else return null;
      }
   }
}