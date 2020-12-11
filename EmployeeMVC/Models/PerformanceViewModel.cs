using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace EmployeeMVC.Models {

    public class PerformanceViewModel {

        public List<DataPointViewModel> DataPoint { get; set; }

        public List<RatingViewModel> Rating { get; set; }
    }

}