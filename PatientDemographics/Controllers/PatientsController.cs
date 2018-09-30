using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientDemographicsDAL;
using PatientDemographics.Models;
using System.Web.Http.Cors;

namespace PatientDemographics.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class PatientsController : ApiController
    {

        public IEnumerable<PatientVM> Get()
        {
            List<PatientVM> lstPatientVM = new List<PatientVM>();
            using (PatientDemographicDBEntities entities = new PatientDemographicDBEntities())
            {
               // return entities.Patients.ToList();
               foreach(Patient patient in entities.Patients)
                {
                    string xmlPatientDetails = patient.Patient_Details;
                    Object obj = Utility.ObjectToXML(xmlPatientDetails, typeof(PatientVM));
                    PatientVM patientVM = (PatientVM)obj;
                    lstPatientVM.Add(patientVM);     
                }
                
            }
            return lstPatientVM.ToList();
        }

        //public HttpResponseMessage Get(int id)
        //{
        //    using (PatientDemographicDBEntities entities = new PatientDemographicDBEntities())
        //    {
        //        var entity = entities.Patients.FirstOrDefault(e => e.Patient_ID == id);
        //        if (entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound,
        //                "Patient with Id " + id.ToString() + " not found");
        //        }
        //    }
        //}
        public HttpResponseMessage Post([FromBody]PatientVM patientvm)
        {
            try
            {
               
                // Convert Patient VM to XML to save to database
                string xml = Utility.GetXMLFromObject(patientvm);

                // Pass converted XML to Patient model object
                Patient patient = new Patient();
                patient.Patient_Details = xml;
                using (PatientDemographicDBEntities entities = new PatientDemographicDBEntities())
                {
                    entities.Patients.Add(patient);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, patient);
                    message.Headers.Location = new Uri(Request.RequestUri + patient.Patient_ID.ToString());
                    return message;

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

       

    }
}
