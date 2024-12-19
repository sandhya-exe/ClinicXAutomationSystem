using ClinicXAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ClinicXAutomationSystem.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ClinicDBEntitiess db = new ClinicDBEntitiess();

        //[Authorize(Roles = "PATIENT")]
        // GET: Patients
        public ActionResult Index()
        {
            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;
            int? id = currentUser.ReferenceToId;

            var pat = db.patients.Find(id);
            string name = pat.name;

            return View();
        }


        #region Appointment GET POSt
        // GET : Appointment
        public ActionResult CreateAppointment()
        {
            return View();
        }
        // POST: Appointment
        [HttpPost]
        public ActionResult CreateAppointment([Bind(Include = "AppointmentDate, Criticality, Reason, Note")] Appointment appointment)
        {
            if (ModelState.IsValid)


            {
                var cu = Session["CurrentUser"] as Models.CurrentUserModel;
                var p = db.patients.Find(cu.ReferenceToId);

                appointment.patientID = p.patientID;
                appointment.Status = "Pending";
                // p.Appointments.Add(appointment);



                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Content("There is some issue with the appointment");
        }
        #endregion

        public ActionResult ViewAllAppointment()
        {
            Models.AppointmentScheduleViewModel schedule = new AppointmentScheduleViewModel();



            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;
            
            if (currentUser.ReferenceToId == null)
            {
                // Handle case where ReferenceToId is null
                return Content("Invalid user ID.");
            }
            int? patientID = currentUser.ReferenceToId;



            schedule.OldAppointments = db.Appointments.Include("physician").Where(p => p.patientID == patientID && p.ScheduleDateTime < DateTime.Now).ToList();

            schedule.UpcomingAppointments = db.Appointments.Include("physician").Where(p => p.patientID == patientID && p.ScheduleDateTime > DateTime.Now || p.ScheduleDateTime == null).ToList();

            return View(schedule);
        }

        public ActionResult EditDetails()
        {

            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;

            if (currentUser == null)
            {
                // Handle case where the session user is null
                return Content("No current user found.");
            }

            // Directly use referencetoID as it is already an int
            int? patientID = currentUser.ReferenceToId;

            // Retrieve the patient from the database using the ID
            patient patient = db.patients.Find(patientID);

            if (patient == null)
            {
                // Handle case where patient is not found
                return Content("Patient not found.");
            }

            return View(patient);
        }

        [HttpPost]
        public ActionResult EditDetails([Bind(Include = "name, contact, email, address")] patient patient)
        {
            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;

            int? patientID = currentUser.ReferenceToId;

            if (ModelState.IsValid)
            {
                // Find the existing patient by patientID
                var existingPatient = db.patients.Find(patientID);

                if (existingPatient != null)
                {
                    // Update only the editable fields
                    existingPatient.name = patient.name;
                   
                    existingPatient.contact = patient.contact;
                    existingPatient.email = patient.email;
                    existingPatient.address = patient.address;

                    // Status and Gender are not modified
                    // These fields will remain unchanged in the database

                    // Update the database
                    db.Entry(existingPatient).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(patient);
        }

        public ActionResult ViewAdvice()
        {
            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;

            int? patientID = currentUser.ReferenceToId;

            var advice = db.advices
                .Include("Appointment")
                .Where(a => a.Appointment.patientID == patientID)
                .ToList();


            var prescriptions = db.prescriptions.Include("advice")
                .Where(p => p.advice.Appointment.patientID == patientID)
                .ToList();

            ViewBag.Prescriptions = prescriptions;
            ViewBag.flgTxt = "Show";

            return View(advice);
        }

        public ActionResult ViewPrescription(int adviceID, string flgBtn)
        {
            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;

            int? patientID = currentUser.ReferenceToId;
            var prescriptions = db.prescriptions
                                  .Include("drug")
                                  .Where(p => p.adviceID == adviceID)
                                  .ToList();

            var advice = db.advices
                .Include("Appointment")
                .Where(a => a.Appointment.patientID == patientID)
                .ToList();

            ViewBag.flgTxt = flgBtn == "Show" ? "Hide" : "Show";
            ViewBag.Prescriptions = flgBtn == "Show" ? prescriptions : null;
            ViewBag.CurrentAdviceID = adviceID;

            return View("ViewAdvice", advice);
        }


        public ActionResult AddViewHistory()
        {
            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;

            int? patientID = currentUser.ReferenceToId;

            // Fetch all symptoms grouped by category
            var symptomsGroupedByCategory = db.symptoms
                .GroupBy(s => s.Category)
                .Select(g => new SymptomCategoryGroup
                {
                    Category = g.Key,
                    Symptoms = g.Select(s => new Symptom
                    {
                        SymptomID = s.symptomID,
                        SymptomName = s.symptomName
                    }).ToList()
                })
                .ToList();

            // Get previously selected symptoms for the current patient
            var selectedSymptoms = db.PatientSymptoms
                .Where(ps => ps.PatientID == patientID)
                .Select(ps => ps.SymptomID)
                .ToList();

            var model = new PatientSymptomsViewModel
            {
                PatientID = (int)patientID,
                SymptomsGroupedByCategory = symptomsGroupedByCategory,
                SelectedSymptoms = selectedSymptoms
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddViewHistory(List<string> SelectedSymptoms)
        {
            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;

            int? patientID = currentUser.ReferenceToId;

            if (ModelState.IsValid)
            {
                // Remove existing symptoms for the patient
                var existingSymptoms = db.PatientSymptoms.Where(ps => ps.PatientID == patientID).ToList();
                db.PatientSymptoms.RemoveRange(existingSymptoms);



                db.SaveChanges();

                // Insert selected symptoms into the PatientSymptoms table
                foreach (var symptomID in SelectedSymptoms.Where(s => s != "false"))
                {
                    var patientSymptom = new PatientSymptom
                    {
                        PatientID = (int)patientID,
                        SymptomID = int.Parse(symptomID)
                    };

                    db.PatientSymptoms.Add(patientSymptom);
                }

                db.SaveChanges();
                return RedirectToAction("Index", "Patient"); // Or redirect to another page as needed
            }

            return RedirectToAction("index");
        }

    }

}