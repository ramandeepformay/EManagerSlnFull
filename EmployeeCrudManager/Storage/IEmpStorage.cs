using System;
using System.Collections.Generic;
using EmployeeCrudManager.Models;

namespace EmployeeCrudManager.Storage {
    public interface IEmpStorage {
        void CreateEmp (EmployeeInformation employee);
        List<EmployeeInformation> Print (Guid User);
        List<EmployeeInformation> SearchEmp (string emp, Guid User);
        EmployeeInformation SearchEmpId (Guid empId, Guid User);
        void DeleteEmpId (Guid empId, Guid User);
        string UpperFirstChar (string name);
        void Update (EmployeeInformation employee);
        void Rank (string popularity, int value, Guid Id);
    }
}