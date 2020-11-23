using System.Collections.Generic;
using EmployeeCrudManager.Models;

namespace EmployeeCrudManager.Storage {
    public interface IEmpStorage {
        void CreateEmp (EmployeeInformation employee);
        IEnumerable<EmployeeInformation> Print ();
        EmployeeInformation SearchEmp (string emp);
        EmployeeInformation DeleteEmp (string emp);
        EmployeeInformation RankChanger (string emp, string user);
        string UpperFirstChar (string name);

        string FormatNumber (double salary);
    }
}