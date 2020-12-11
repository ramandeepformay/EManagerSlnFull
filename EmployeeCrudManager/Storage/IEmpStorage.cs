using System;
using System.Collections.Generic;
using EmployeeCrudManager.Models;

namespace EmployeeCrudManager.Storage {
    public interface IEmpStorage {
        void CreateEmp (EmployeeInformation employee);
        List<EmployeeInformation> Print ();
        List<EmployeeInformation> SearchEmp (string emp);
        EmployeeInformation SearchEmpId (Guid empId);
        EmployeeInformation DeleteEmp (string emp);
        void DeleteEmpId (Guid empId);
        EmployeeInformation Converter (Guid Id);
        string UpperFirstChar (string name);
        void Update (EmployeeInformation employee);
        void Rank (string popularity, int value, Guid Id);
    }
}