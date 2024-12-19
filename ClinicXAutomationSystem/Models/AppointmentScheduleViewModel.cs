using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicXAutomationSystem.Models
{
    public class AppointmentScheduleViewModel
    {

        public List<Appointment> OldAppointments { get; set; }
        public List<Appointment> UpcomingAppointments { get; set; }
    }
}