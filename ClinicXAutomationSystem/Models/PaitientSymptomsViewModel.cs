using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicXAutomationSystem.Models
{
    public class PatientSymptomsViewModel
    {
        public int PatientID { get; set; }
        public List<int> SelectedSymptoms { get; set; } // List of selected symptom IDs
        public List<SymptomCategoryGroup> SymptomsGroupedByCategory { get; set; }
    }

    public class SymptomCategoryGroup
    {
        public string Category { get; set; }
        public List<Symptom> Symptoms { get; set; }
    }

    public class Symptom
    {
        public int SymptomID { get; set; }
        public string SymptomName { get; set; }
    }
}