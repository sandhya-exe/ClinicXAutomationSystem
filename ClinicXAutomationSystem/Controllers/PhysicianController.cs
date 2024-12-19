using ClinicXAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicXAutomationSystem.Controllers
{
    public class PhysicianController : Controller
    {
        // GET: Physician
        public ClinicDBEntitiess db = new ClinicDBEntitiess();
        public ActionResult Index()
        {
            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;
            int? id = currentUser.ReferenceToId;

            var phy = db.physicians.Find(id);
            string name = phy.name;

            return View();
        }

        //View his Appointment
        
        public ActionResult ViewAppointment()
        {
            // GET: Appointments/Details/5
            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;

            int curPhysicianId = (int)(currentUser.ReferenceToId);
            var appointment = db.Appointments.Include("patient").Where(p => p.physicianID == curPhysicianId).ToList();

            return View(appointment);

        }

        public ActionResult CreateAdvice(int id)
        {


            //  
            var app = db.Appointments.Find(id);

            ViewBag.Drugs = db.drugs.ToList();

            ViewBag.AppointmentID = id.ToString();
            ViewBag.PatientID = app.patientID.ToString();
            ViewBag.PatientName = app.patient.name;

            var adv = new Models.advice();
            adv.prescriptions.Add(new Models.prescription());


            return View(adv);
        }

        // POST: advices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public ActionResult CreateAdvice(Models.advice adv, int? PatientID, int? AppointmentID)
        {
            Models.ClinicDBEntitiess db = new Models.ClinicDBEntitiess();
            if (ModelState.IsValid)
            {
                adv.Appointment = db.Appointments.Find(AppointmentID);
                foreach (var prs in adv.prescriptions)
                {
                    prs.drug = db.drugs.Find(prs.drugID);
                }
                db.advices.Add(adv);
                db.SaveChanges();
                return RedirectToAction("ViewAppointment");
            }




            return Redirect("ViewAppointment");
        }


        public ActionResult CreatePrescriptions(string id)
        {
            ViewBag.slno = id;
            return PartialView();
        }



        public ActionResult ViewAdvice(int id)
        {
            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;

            int? physicianID = currentUser.ReferenceToId;


            var advice = db.advices
                .Include("Appointment")
                .Where(a => a.Appointment.physicianID == physicianID && a.AppointmentID == id)
                .ToList();


            ViewBag.Prescriptions = null;
            ViewBag.flgTxt = "Show";

            return View(advice);
        }

        public ActionResult ViewPrescription(int adviceID, string flgBtn, int id)
        {
            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;

            int? physicianID = currentUser.ReferenceToId;

            var prescriptions = db.prescriptions
                                  .Include("drug").Include("advice")
                                  .Where(p => p.adviceID == adviceID && p.advice.AppointmentID == id)
                                  .ToList();

            var advice = db.advices
                .Include("Appointment")
                .Where(a => a.Appointment.physicianID == physicianID && a.AppointmentID == id)
                .ToList();

            ViewBag.flgTxt = flgBtn == "Show" ? "Hide" : "Show";
            ViewBag.Prescriptions = flgBtn == "Show" ? prescriptions : null;
            ViewBag.CurrentAdviceID = adviceID;

            return View("ViewAdvice", advice);
        }
    }
}