using ClinicXAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicXAutomationSystem.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ClinicDBEntitiess db = new ClinicDBEntitiess();
        public ActionResult Index()
        {
            return Content("You have registered. Wait for confirmation!");
        }
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(string name, DateTime DOB,string contact, string email, string address, string gender)
        {
            if (ModelState.IsValid)
            {
                // Set default values for 'status' and 'account'
                string status = "INACTIVE";
                string account = "unregistered";
                
                // Create a new patient instance
                var newPatient = new patient
                {
                    name = name,
                    DOB = DOB,
                   
                    //age = DateTime.Today.Year - DOB.Year,
                    contact = contact,
                    email = email,
                    address = address,
                    gender = gender,
                    status = status,   // Default 'INACTIVE'
                    account = account  // Default 'unregistered'
                };

                // Add the new patient to the database
                db.patients.Add(newPatient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}