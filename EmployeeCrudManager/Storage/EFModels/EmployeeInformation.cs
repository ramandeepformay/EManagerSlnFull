using System;
namespace EmployeeCrudManager.Storage.EFModels {
    public class EmployeeInformation {
        public Guid EmployeeInformationId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Designation { get; set; }

        public double Salary { get; set; }

        public int Rating { get; set; }

        public DateTime Date { get; set; }

        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}