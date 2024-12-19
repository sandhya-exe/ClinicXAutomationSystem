using ClinicXAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClinicXAutomationSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public ClinicDBEntitiess db = new ClinicDBEntitiess();

        public ActionResult Index()
        {
            return View();
        }

        //Get Physician 
        public ActionResult PhysicianIndex()
        {
            return View(db.physicians.ToList());
        }
        public ActionResult PhysicianCreate()
        {
            return View();
        }
        // POST: physicians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhysicianCreate([Bind(Include = "physicianID,name,Specialisation,contact,email,address,regNO")] physician physician)
        {
            if (ModelState.IsValid)
            {
                db.physicians.Add(physician);

                db.SaveChanges();


                Models.User user = new Models.User()
                {
                    Password = physician.name.Substring(0, 4) + DateTime.Now.ToString("ddMM"),
                    UserName = physician.name.Substring(0, 4) + "@ClinicB",
                    Role = "" +
                    "physician"
                };

                user.ReferenceId = physician.physicianID;
                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("PhysicianIndex");
            }

            return View(physician);
        }
        // GET: physicians/Delete/5
        public ActionResult PhysicianDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            physician physician = db.physicians.Find(id);
            if (physician == null)
            {
                return HttpNotFound();
            }
            return View(physician);
        }

        // POST: physicians/Delete/5
        [HttpPost, ActionName("PhysicianDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {



            physician physician = db.physicians.Find(id);
            db.physicians.Remove(physician);
            db.SaveChanges();

            //to delete user from user table
            var user = db.Users
            .FirstOrDefault(u => u.Role == "physician" && u.ReferenceId == id);

            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("PhysicianIndex");
        }
        // GET: physicians/Details/5
        public ActionResult PhysicianDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            physician physician = db.physicians.Find(id);
            if (physician == null)
            {
                return HttpNotFound();
            }
            return View(physician);
        }

        // GET: physicians/Edit/5
        public ActionResult PhysicianEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            physician physician = db.physicians.Find(id);
            if (physician == null)
            {
                return HttpNotFound();
            }
            return View(physician);
        }

        // POST: physicians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhysicianEdit([Bind(Include = "physicianID,name,Specialisation,contact,email,address,regNO")] physician physician)
        {
            if (ModelState.IsValid)
            {
                db.Entry(physician).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PhysicianIndex");
            }
            return View(physician);
        }






        //----------------------------Patient--------------------------------


        // GET: patients
        public ActionResult PatientIndex()
        {
            return View(db.patients.ToList());
        }

      

        // GET: patients/Create
        public ActionResult PatientCreate()
        {
            return View();
        }

        // POST: patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PatientCreate([Bind(Include = "patientID,name,DOB,contact,email,address,gender,status")] patient patient)
        {

            if (ModelState.IsValid)
            {
               
                patient.account = "unregistered";
                db.patients.Add(patient);
                db.SaveChanges();


                Models.User user = new Models.User()
                {
                    Password = patient.name.Length-1 + DateTime.Now.ToString("ddMM"),
                    UserName = patient.name.Length - 1 + "@ClinicB",
                    Role = "patient"
                };

                user.ReferenceId = patient.patientID;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("PatientIndex");
            }

            return View(patient);
        }

        // GET: patients/Edit/5
        public ActionResult PatientEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PatientEdit([Bind(Include = "patientID,name,DOB,contact,email,address,gender,status,account")] patient patient)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PatientIndex");
            }
            return View(patient);
        }
        //Add registered patient
        public ActionResult PatientAdd(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PatientAdd([Bind(Include = "patientID,name,DOB,age,contact,email,address,gender,status,account")] patient patient)
        {
            if (ModelState.IsValid)
            {
                Models.User user = new Models.User()
                {
                    Password = patient.name.Substring(0, patient.name.Length - 1) + DateTime.Now.ToString("ddMM"),
                    UserName = patient.name.Substring(0, patient.name.Length - 1) + "@ClinicB",
                    Role = "patient"
                };

                user.ReferenceId = patient.patientID;
                db.Users.Add(user);
                db.SaveChanges();
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PatientIndex");
            }
            return View(patient);
        }

        // GET: patients/Delete/5
        public ActionResult PatientDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: patients/Delete/5
        [HttpPost, ActionName("PatientDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PatientDeleteConfirmed(int id)
        {
            patient patient = db.patients.Find(id);
            db.patients.Remove(patient);
            db.SaveChanges();

            //to delete user from user table
            var user = db.Users
            .FirstOrDefault(u => u.Role == "patient" && u.ReferenceId == id);

            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("PatientIndex");
        }












        //-------------------chemist------------------------




        // GET: chemists
        public ActionResult ChemistIndex()
        {
            return View(db.chemists.ToList());
        }

        // GET: chemists/Details/5
        public ActionResult ChemistDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chemist chemist = db.chemists.Find(id);
            if (chemist == null)
            {
                return HttpNotFound();
            }
            return View(chemist);
        }

        // GET: chemists/Create
        public ActionResult ChemistCreate()
        {
            return View();
        }

        // POST: chemists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChemistCreate([Bind(Include = "chemistID,name,contact,email")] chemist chemist)
        {
            if (ModelState.IsValid)
            {
                db.chemists.Add(chemist);
                db.SaveChanges();

                Models.User user = new Models.User()
                {
                    Password = chemist.name.Substring(0, 4) + DateTime.Now.ToString("ddMM"),
                    UserName = chemist.name.Substring(0, 4) + "@ClinicB",
                    Role = "chemist"
                };

                user.ReferenceId = chemist.chemistID;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("ChemistIndex");
            }

            return View(chemist);
        }

        // GET: chemists/Edit/5
        public ActionResult ChemistEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chemist chemist = db.chemists.Find(id);
            if (chemist == null)
            {
                return HttpNotFound();
            }
            return View(chemist);
        }

        // POST: chemists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChemistEdit([Bind(Include = "chemistID,name,contact,email")] chemist chemist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chemist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChemistIndex");
            }
            return View(chemist);
        }

        // GET: chemists/Delete/5
        public ActionResult ChemistDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chemist chemist = db.chemists.Find(id);
            if (chemist == null)
            {
                return HttpNotFound();
            }
            return View(chemist);
        }

        // POST: chemists/Delete/5
        [HttpPost, ActionName("ChemistDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ChemistDeleteConfirmed(int id)
        {
            chemist chemist = db.chemists.Find(id);
            db.chemists.Remove(chemist);
            db.SaveChanges();

            var user = db.Users
             .FirstOrDefault(u => u.Role == "chemist" && u.ReferenceId == id);

            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("ChemistIndex");
        }

        ////------------------------supplier--------------------------
        // GET: suppliers
        public ActionResult SupplierIndex()
        {
            return View(db.suppliers.ToList());
        }

        // GET: suppliers/Details/5
        public ActionResult SupplierDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supplier supplier = db.suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: suppliers/Create
        public ActionResult SupplierCreate()
        {
            return View();
        }

        // POST: suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SupplierCreate([Bind(Include = "supplierID,name,contact,address,email")] supplier supplier)
        {
            if (ModelState.IsValid)
            {

                db.suppliers.Add(supplier);
                db.SaveChanges();


                Models.User user = new Models.User()
                {
                    Password = supplier.name.Substring(0, 4) + DateTime.Now.ToString("ddMM"),
                    UserName = supplier.name.Substring(0, 4) + "@ClinicB",
                    Role = "" +
                    "supplier"
                };

                user.ReferenceId = supplier.supplierID;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("SupplierIndex");
            }

            return View(supplier);
        }

        // GET: suppliers/Edit/5
        public ActionResult SupplierEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supplier supplier = db.suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SupplierEdit( supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SupplierIndex");
            }
            return View(supplier);
        }

        // GET: suppliers/Delete/5
        public ActionResult SupplierDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supplier supplier = db.suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: suppliers/Delete/5
        [HttpPost, ActionName("SupplierDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult SupplierDeleteConfirmed(int id)
        {
            supplier supplier = db.suppliers.Find(id);
            db.suppliers.Remove(supplier);
            db.SaveChanges();

            var user = db.Users
            .FirstOrDefault(u => u.Role == "supplier" && u.ReferenceId == id);

            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("SupplierIndex");
        }
        //--------------------------Appointment--------------------------
        public ActionResult AppointmentIndex()

        {
            return View();
        }


    }
}
