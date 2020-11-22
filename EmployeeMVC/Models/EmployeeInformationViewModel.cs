using System;
using System.ComponentModel.DataAnnotations;
namespace EmployeeMVC.Models {
    public class EmployeeInformationViewModel {
        // public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Designation { get; set; }

        public double Salary { get; set; }

        // public int Rating { get; set; }

    }
}