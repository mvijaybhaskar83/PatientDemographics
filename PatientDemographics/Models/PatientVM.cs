using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientDemographics.Models
{
    public class PatientVM
    {
        public int Patient_ID { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string HomeNumber { get; set; }
        public string WorkNumber { get; set; }
        public string MobileNumber { get; set; }
    }
}