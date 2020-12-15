using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EmployeeCrudManager.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeeCrudManager.Storage {
   public class EmpStorageListsEF : IEmpStorage {
      private ApplicationContext _context;
      public EmpStorageListsEF (ApplicationContext context) {
         _context = context;
      }

      //receives and adding employee to the employee database lists
      public void CreateEmp (EmployeeInformation employee) {
         var employeeDb = ConverterViewDbtoPostDB (employee);
         _context.Add (employeeDb);
         _context.SaveChanges ();
      }

      // return all the employees of the company
      public List<EmployeeInformation> Print (Guid User) {
         List<EmployeeInformation> emp = new List<EmployeeInformation> ();
         var emploeeDb = _context.EmployeeInformations
            .AsNoTracking ()
            .Where (x => x.IsDeleted == false && x.UserId == User)
            .ToList ();
         foreach (var x in emploeeDb) {
            var newEmpDb = ConverterDbtoViewDb (x);
            emp.Add (newEmpDb);
         }
         if (emp != null) {
            var updatedLists = emp.Select (emp => {
                  emp.FirstName = UpperFirstChar (emp.FirstName);
                  emp.LastName = UpperFirstChar (emp.LastName);
                  emp.Designation = UpperFirstChar (emp.Designation);
                  return emp;
               })
               .ToList ();
            return updatedLists;
         } else {
            return null;
         }
      }

      // search employee in the list using employee id property
      public EmployeeInformation SearchEmpId (Guid empId, Guid User) {
         var empDbId = _context.EmployeeInformations
            .AsNoTracking ()
            .Where (x => x.IsDeleted == false && x.UserId == User)
            .First (x => x.EmployeeInformationId == empId);
         var empView = ConverterDbtoViewDb (empDbId);
         return empView;
      }

      // search employees in the list using employee name property
      public List<EmployeeInformation> SearchEmp (string emp, Guid User) {
         List<EmployeeInformation> newEmp = new List<EmployeeInformation> ();
         var query = from x in _context.EmployeeInformations select x;
         if (!String.IsNullOrEmpty (emp)) {
            query = query
               .Where (x => x.IsDeleted == false && x.UserId == User)
               .Where (x => x.FirstName.ToLower ()
                  .StartsWith (emp.ToLower ()));
            foreach (var x in query) {
               var converted = ConverterDbtoViewDb (x);
               newEmp.Add (converted);
            }
            return newEmp;
         } else {
            return null;
         }

      }

      // delete employee in the list using employee id property
      public void DeleteEmpId (Guid empId, Guid User) {
         var employeeDb = _context.EmployeeInformations
            .AsNoTracking ()
            .First (x => x.EmployeeInformationId == empId && x.UserId == User);
         employeeDb.IsDeleted = true;
         _context.EmployeeInformations.Update (employeeDb);
         _context.SaveChanges ();
      }

      //  update employee
      public void Update (EmployeeInformation employee) {
         var empDB = ConverterViewDbtoPostDB (employee);
         _context.EmployeeInformations.Update (empDB);
         _context.SaveChanges ();
      }

      public void Rank (string popularity, int value, Guid Id) {
         var empDB = _context.EmployeeInformations
            .AsNoTracking ().First (x => x.EmployeeInformationId == Id);
         if (popularity == "inc") {
            empDB.Rating = empDB.Rating += 2;
            _context.EmployeeInformations.Update (empDB);
            _context.SaveChanges ();
         }
         if (popularity == "dec") {
            empDB.Rating = empDB.Rating -= 2;
            _context.EmployeeInformations.Update (empDB);
            _context.SaveChanges ();
         }
      }

      // to convert the  first character of the name to upper case 
      public string UpperFirstChar (string name) {
         if (name.Length > 0) {
            return char.ToUpper (name[0]) + name.Substring (1);
         } else {
            return null;
         }
      }

      private static EmployeeInformation ConverterDbtoViewDb (EFModels.EmployeeInformation x) {
         return new EmployeeInformation () {
            Id = x.EmployeeInformationId,
               FirstName = x.FirstName,
               LastName = x.LastName,
               Age = x.Age,
               Designation = x.Designation,
               Salary = x.Salary,
               Rating = x.Rating,
               Date = x.Date,
               UserId = x.UserId
         };
      }

      private static EFModels.EmployeeInformation ConverterViewDbtoPostDB (EmployeeInformation employee) {
         return new EFModels.EmployeeInformation () {
            EmployeeInformationId = employee.Id,
               FirstName = employee.FirstName,
               LastName = employee.LastName,
               Age = employee.Age,
               Designation = employee.Designation,
               Salary = employee.Salary,
               Rating = employee.Rating,
               Date = employee.Date,
               UserId = employee.UserId
         };
      }
   }
}