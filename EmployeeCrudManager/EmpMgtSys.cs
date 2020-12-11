using System;
using System.Collections.Generic;
using EmployeeCrudManager.Models;
using EmployeeCrudManager.Storage;
namespace EmployeeCrudManager

{
    public class EmpMgtSys {
        // Constructor is getting initialized using EmpStorageLists
        public EmpMgtSys (IEmpStorage empStorage) {
            _empStorage = empStorage;
        }
        private readonly IEmpStorage _empStorage;

        // print method called of EmpstorageLists
        public List<EmployeeInformation> Print () {
            return _empStorage.Print ();
        }
        // searchEmp method called  using first name property 
        public List<EmployeeInformation> Search (string input) {
            var result = _empStorage.SearchEmp (input);
            return result;
        }

        // searchEmp method called  using id property 
        public EmployeeInformation SearchId (Guid id) {
            var result = _empStorage.SearchEmpId (id);
            return result;
        }
        // this method first add a new emp an then return a list of employess including newly created employee
        public void Create (EmployeeInformation employee) {

            _empStorage.CreateEmp (employee);
        }
        // this method updates employee information
        public void Update (EmployeeInformation employee) {
            _empStorage.Update (employee);
        }
        // deletes employee using first name

        // deletes employee using id property
        public void DeleteId (Guid id) {
            _empStorage.DeleteEmpId (id);
        }

        public void Rank (string popularity, int value, Guid Id) {
            _empStorage.Rank (popularity, value, Id);
        }

    }
}