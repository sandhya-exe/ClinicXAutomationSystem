//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicXAutomationSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class patientHistory
    {
        public int historyID { get; set; }
        public Nullable<int> patientID { get; set; }
        public string artifacts { get; set; }
        public string notes { get; set; }
    
        public virtual patient patient { get; set; }
    }
}
