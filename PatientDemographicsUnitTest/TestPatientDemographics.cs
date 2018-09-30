using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientDemographics;
using PatientDemographics.Models;
using PatientDemographics.Controllers;


namespace PatientDemographicsUnitTest
{
    [TestClass]
    class TestPatientDemographics
    {
        [TestMethod]
        public void GetAllPatient_ShouldReturnAllPatient()
        {
            var testPatients = GetTestPatient();
            var controller = new PatientsController();

            var result = controller.Get() as List<PatientVM>;
            Assert.AreEqual(testPatients.Count, result.Count);
        }

        [TestMethod]
        public void PostPatient_ShoudReturnCreatedPatient()
        {
            var testPatients = GetTestPatient();
            var controller = new PatientsController();
            foreach(PatientVM  patientVM in testPatients)
            {
                var result = controller.Post(patientVM);
                Assert.AreEqual(System.Net.HttpStatusCode.Created,result.StatusCode);
            }

        }

        private List<PatientVM> GetTestPatient()
        {
            var testPatients = new List<PatientVM>();
            testPatients.Add(new PatientVM { Forenames = "Demo1", Surname = "surname1",DOB="12/05/2018",Gender="Male",HomeNumber="123456789",WorkNumber="123456789",MobileNumber="123456789" });
            testPatients.Add(new PatientVM { Forenames = "Demo2", Surname = "surname2", DOB = "12/05/2018", Gender = "Male", HomeNumber = "123456789", WorkNumber = "123456789", MobileNumber = "123456789" });
            testPatients.Add(new PatientVM { Forenames = "Demo3", Surname = "surname3", DOB = "12/05/2018", Gender = "Male", HomeNumber = "123456789", WorkNumber = "123456789", MobileNumber = "123456789" });
            testPatients.Add(new PatientVM { Forenames = "Demo4", Surname = "surname4", DOB = "12/05/2018", Gender = "Male", HomeNumber = "123456789", WorkNumber = "123456789", MobileNumber = "123456789" });

            return testPatients;
        }
    }
}
