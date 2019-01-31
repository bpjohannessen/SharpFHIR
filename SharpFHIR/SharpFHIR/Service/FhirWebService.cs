using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;
using ObjectDumper;

namespace SharpFHIR.Service
{
    public class FhirWebService : IFhirService
    {

        private readonly string m_endPoint; 

        public FhirWebService(string endPoint)
        {
            m_endPoint = endPoint; 
        }

        public string GetPatient(int id)
        {
            return null; 
        }

        public IEnumerable<string> GetPatients(string patientName)
        {
            var endpoint = new Uri(m_endPoint);
            

            var client = new FhirClient(endpoint);
            var query = new string[] { "name=" + patientName };

            var bundle = client.Search("Patient", query);

            var names = new List<string>();

            foreach (var entry in bundle.Entry)
            {
                var patient = (Patient)entry.Resource;
                //names.Add(patient.Name.ToString());       
                names.Add("First name: " + patient.Name[0].Given.First());
                names.Add("Last name: " + patient.Name[0].Family.First());
                names.Add("DOB: " + patient.BirthDate);
                names.Add("DOB FHIR: " + patient.BirthDateElement + "\r\n");

                //var objDump1 = new ObjectDumper();
                //ObjectDumperExtensions.DumpToString(patient);


            }
            return names;
            
        }
    }
}
