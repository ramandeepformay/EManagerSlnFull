using System;
using System.ComponentModel.DataAnnotations;
namespace EmployeeMVC.Models {

    public class RatingViewModel {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public int Rating { get; set; }
    }
}