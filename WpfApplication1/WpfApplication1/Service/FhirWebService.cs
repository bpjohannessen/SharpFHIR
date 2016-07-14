﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;

namespace WpfApplication1.Service
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
                names.Add(patient.Name[0].Given.First());
            }
            return names; 
        }
    }
}