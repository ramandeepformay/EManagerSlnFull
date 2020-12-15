using System;
using System.ComponentModel.DataAnnotations;
namespace EmployeeMVC.Models {
    public class EmployeeInformationViewModel {
        public Guid? Id { get; set; }

        [Required]
        [StringLength (30)]
        [RegularExpression ("^[a-zA-Z]+$", ErrorMessage = "Numbers are not allowed")]
        public string FirstName { get; set; }

        [Required]
        [StringLength (30)]
        [RegularExpression ("^[a-zA-Z]+$", ErrorMessage = "Numbers are not allowed")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression ("^([2-5][0-9]|6[0-5])$", ErrorMessage = "Age must be between 19 and 66")]
        public int Age { get; set; }

        [Required]
        [StringLength (20)]
        [RegularExpression ("^[a-zA-Z]+$", ErrorMessage = "Numbers are not allowed")]
        public string Designation { get; set; }

        [Required]
        [RegularExpression ("^([3-8][0-9]{4}|9[0-8][0-9]{3}|99[0-8][0-9]{2}|999[0-8][0-9]|9999[0-9]|90000)$", ErrorMessage = "Salary must be between 29,999 and 100,000")]
        // |[1-8][0-9]{5}
        public double Salary { get; set; }

        public int? Rating { get; set; }
        public DateTime? Date { get; set; }
    }
}