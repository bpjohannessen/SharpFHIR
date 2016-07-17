﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFHIR.Service
{
    public interface IFhirService
    {
        IEnumerable<string> GetPatients(string searchName);
        string GetPatient(int id); 

    }
}
