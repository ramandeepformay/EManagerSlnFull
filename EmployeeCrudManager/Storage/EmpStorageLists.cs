using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EmployeeCrudManager.Models;
namespace EmployeeCrudManager.Storage {
   public class EmpStorageLists : IEmpStorage {
      private List<EmployeeInformation> _empInformation;

      //  List of all EmployeeInformation is initialized in the cconstructor
      public EmpStorageLists () {
         _empInformation = new List<EmployeeInformation> ();
      }

      //Receives and adding employee to the employee information lists
      public void CreateEmp (EmployeeInformation employee) {
         _empInformation.Add (employee);
      }
      // return all the employees of the company
      public IEnumerable<EmployeeInformation> Print () {

         var updatedLists = _empInformation.Select (emp => {
            emp.FirstName = UpperFirstChar (emp.FirstName);
            emp.LastName = UpperFirstChar (emp.LastName);
            // emp.Age = emp.Age;
            // emp.Salary = emp.Salary;
            emp.Designation = UpperFirstChar (emp.Designation);;
            return emp;
         }).ToList ();
         return updatedLists;
      }

      // search employees in the lists
      public EmployeeInformation SearchEmp (string emp) {
         for (int i = 0; i < _empInformation.Count; i++) {
            if (emp == _empInformation[i].FirstName) {
               return _empInformation[i];
            }
         }
         return null;
      }

      //  delete employee
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

      // promotion or demotion 

      public EmployeeInformation RankChanger (string emp, string user) {
         foreach (var res in _empInformation) {
            if (user == "pr" && res.FirstName == emp) {
               res.Rating++;
               return res;
            }
            if (user == "de" && res.FirstName == emp && res.Rating >= 0) {
               res.Rating--;
               return res;
            }
         }
         return null;
      }
      public string UpperFirstChar (string name) {
         if (name.Length > 0) {
            return char.ToUpper (name[0]) + name.Substring (1);
         } else return null;
      }

      public string FormatNumber (double salary) {
         return salary.ToString ("C", new System.Globalization.CultureInfo ("en-US"));
      }
   }
}