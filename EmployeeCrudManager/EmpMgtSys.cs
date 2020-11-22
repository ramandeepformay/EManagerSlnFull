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

            //creating instances and calling the createEmp of EmpStoragelISTS 
            _empStorage.CreateEmp (new EmployeeInformation ("Ramandeep", "Formay", 27, "Developer", 27000));
            _empStorage.CreateEmp (new EmployeeInformation ("Amanpreet", "Formay", 25, "Accountant", 37000));
        }
        private readonly IEmpStorage _empStorage;

        // print method called of EmpstorageLists
        public List<EmployeeInformation> Print () {
            return _empStorage.Print ();
        }
        // SearchEmp method called 
        public EmployeeInformation Search (string input) {
            var result = _empStorage.SearchEmp (input);
            return result;
        }
        // this method first add a new emp an then return a list of employess including newly created employee
        public void Create (string first, string last, int age, string designation, double salary) {
            _empStorage.CreateEmp (new EmployeeInformation (first, last, age, designation, salary));
            // return _empStorage.Print ();
        }
        public EmployeeInformation DeleteEmp (string emp) {
            return _empStorage.DeleteEmp (emp);
        }

        public EmployeeInformation Rank (string emp, string user) {
            return _empStorage.RankChanger (emp, user);
        }
    }
}