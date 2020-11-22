using EmployeeCrudManager.Models;
using System.Collections.Generic;

namespace EmployeeCrudManager.Storage
{
    public interface IEmpStorage
    {
        void CreateEmp(EmployeeInformation employee);
        List<EmployeeInformation> Print();
        EmployeeInformation SearchEmp(string emp);
        EmployeeInformation DeleteEmp(string emp);
        EmployeeInformation RankChanger(string emp, string user);
    }
}