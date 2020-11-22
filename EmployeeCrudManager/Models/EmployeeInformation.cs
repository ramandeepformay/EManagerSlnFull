using System;

namespace EmployeeCrudManager.Models {
    public class EmployeeInformation {
        public EmployeeInformation (string firstName, string lastName, int age, string designation, double salary) {
            Id = Guid.NewGuid ();
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Designation = designation;
            Salary = salary;
            Rating = 0;
        }
        // properties 
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Designation { get; set; }

        public double Salary { get; set; }

        public int Rating { get; set; }

        public string FullName {
            get { return $"{FirstName} {LastName}"; }
        }
        public string Display () {
            string details = $"FullName: {FullName}\n";
            details += $"Age: {Age}\n";
            details += $"Designation: {Designation}\n";
            details += $"Salary: {Salary}\n";
            details += "-------------------------\n";
            return details;
        }
    }
}