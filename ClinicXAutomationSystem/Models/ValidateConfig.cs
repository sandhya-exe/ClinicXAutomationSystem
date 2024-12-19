using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicXAutomationSystem.Models
{
    [MetadataType(typeof(ValidationConfigForChemist))]
    public partial class chemist
    {


    }
    public class ValidationConfigForChemist
    {
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string contact { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string name { get; set; }

    }

    //Patient
    [MetadataType(typeof(ValidationConfigForPatient))]
    public partial class patient
    {
    }


    public class ValidationConfigForPatient
    {

        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DOB { get; set; }


        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string contact { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        public string address { get; set; }

        [RegularExpression(@"^(?i)(active|inactive)$", ErrorMessage = "Status must be either 'active' or 'inactive'.")]
        public string status { get; set; }


    }

    //Physician
    [MetadataType(typeof(ValidationConfigForChemist))]
    public partial class physician
    {


    }
    public class ValidationConfigForPhysician
    {
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string contact { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string name { get; set; }

        [Required]
        public string Specialisation { get; set; }

        [Required]
        public string address { get; set; }
        [Required]
        public int regNO { get; set; }

    }

    //Supplier
    [MetadataType(typeof(ValidationConfigForSupplier))]
    public partial class supplier
    {


    }
    public class ValidationConfigForSupplier
    {
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string contact { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string name { get; set; }

        [Required]
        public string address { get; set; }
       

    }
    public partial class Appointment
    {
    }
    public class ValidationForAppointment
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> AppointmentDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ScheduleDateTime { get; set; }

    }

      
       
  
    public class ValidateConfig
    {


    }
}