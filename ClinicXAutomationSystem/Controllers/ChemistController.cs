//using ClinicXAutomationSystem.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Runtime.Remoting.Messaging;
//using System.Web;
//using System.Web.Mvc;

//namespace ClinicXAutomationSystem.Controllers
//{
//    public class ChemistController : Controller
//    {
//        private ClinicDBEntitiess db = new ClinicDBEntitiess();

//        // GET: Chemist
//        public ActionResult Index()
//        {
//            return View();
//        }
//        public ActionResult PurchaseOrder()
//        { return View(); }
//        public ActionResult CreatePO()
//        {
//            ViewBag.SupplierID = new SelectList(db.suppliers, "supplierID", "name");


//            ViewBag.Drugs = db.drugs.ToList();



//            POHeader header = new POHeader();
//            header.PODate = DateTime.Now;

//            header.PODrugLines.Add(new PODrugLine());


//            return View(header);
//        }
//        [HttpPost]
//        public ActionResult CreatePO(Models.POHeader POHeader)
//        {

//            POHeader.supplier = db.suppliers.Find(POHeader.SupplierId);


//            foreach (var DrgLn in POHeader.PODrugLines)

//            {
//                DrgLn.orderStatus = "pending";
//                DrgLn.drug = db.drugs.Find(DrgLn.DrugId);

//            }

//            db.POHeaders.Add(POHeader);
//            db.SaveChanges();

//            ViewBag.SupplierID = new SelectList(db.suppliers, "supplierID", "name");


//            ViewBag.Drugs = db.drugs.ToList();
//            POHeader header = new POHeader();
//            header.PODate = DateTime.Now;

//            header.PODrugLines.Add(new PODrugLine());
//            return View(header);
//        }

//        public ActionResult CreateProductLine(string id)
//        {
//            ViewBag.slno = id;
//            return PartialView();

//            //try
//            //{
//            //    var model = db.PODrugLines.ToList();
//            //    return View(model);
//            //}
//            //catch (Exception ex)
//            //{
//            //    // Log the exception (using NLog, Serilog, or similar tools)
//            //    Console.WriteLine(ex.Message);
//            //    return View(new List<PODrugLine>()); // Return an empty model as fallback
//            //}
//        }
//        public ActionResult ViewPO()
//        {

//            // Replace 'ProductLine' with your actual table/entity name
//            var model = db.POHeaders.ToList();

//            // Ensure the model is not null
//            if (model == null)
//            {
//                // Handle the case where no data is found (optional)
//                model = new List<POHeader>();
//            }

//            return View(model);
//        }


//        //Drug
//        public ActionResult DrugIndex()
//        {

//            return View(db.drugs.ToList());
//        }

//        // GET: Drug/Details/5
//        public ActionResult DrugDetails(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            drug drug = db.drugs.Find(id);
//            if (drug == null)
//            {
//                return HttpNotFound();
//            }
//            return View(drug);
//        }

//        // GET: Drug/Create
//        public ActionResult DrugCreate()
//        {
//            return View();
//        }

//        // POST: Drug/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult DrugCreate([Bind(Include = "drugID,name,description,price,Stock,expiry")] drug drug)
//        {
//            if (drug.expiry < DateTime.Now.Date)
//            {
//                ModelState.AddModelError("expiry", "The expiry date cannot be in the past.");
//            }
//            if (ModelState.IsValid)
//            {
//                db.drugs.Add(drug);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(drug);
//        }

//        // GET: Drug/Edit/5
//        public ActionResult DrugEdit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            drug drug = db.drugs.Find(id);
//            if (drug == null)
//            {
//                return HttpNotFound();
//            }
//            return View(drug);
//        }

//        // POST: Drug/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult DrugEdit([Bind(Include = "drugID,name,description,price,Stock,expiry")] drug drug)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(drug).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(drug);
//        }

//        // GET: Drug/Delete/5
//        public ActionResult DrugDelete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            drug drug = db.drugs.Find(id);
//            if (drug == null)
//            {
//                return HttpNotFound();
//            }
//            return View(drug);
//        }

//        // POST: Drug/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            drug drug = db.drugs.Find(id);
//            db.drugs.Remove(drug);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//    }
//}




using ClinicXAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace ClinicXAutomationSystem.Controllers
{
    public class ChemistController : Controller
    {
        private ClinicDBEntitiess db = new ClinicDBEntitiess();

        // GET: Chemist
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PurchaseOrder()
        { return View(); }
        public ActionResult CreatePO()
        {
            ViewBag.SupplierID = new SelectList(db.suppliers, "supplierID", "name");


            ViewBag.Drugs = db.drugs.ToList();



            POHeader header = new POHeader();
            header.PODate = DateTime.Now;

            header.PODrugLines.Add(new PODrugLine());


            return View(header);
        }
        [HttpPost]
        public ActionResult CreatePO(Models.POHeader POHeader)
        {
            // Ensure the PODate is valid (greater than 1753-01-01)
            if (POHeader.PODate < new DateTime(1753, 1, 1))
            {
                POHeader.PODate = new DateTime(1753, 1, 1); // Adjust to minimum valid datetime
            }
            POHeader.supplier = db.suppliers.Find(POHeader.SupplierId);

            foreach (var DrgLn in POHeader.PODrugLines)
            {
                DrgLn.orderStatus = "pending";
                DrgLn.drug = db.drugs.Find(DrgLn.DrugId);
            }

            db.POHeaders.Add(POHeader);
            db.SaveChanges();

            ViewBag.SupplierID = new SelectList(db.suppliers, "supplierID", "name");
            ViewBag.Drugs = db.drugs.ToList();

            POHeader header = new POHeader();

            if (POHeader.PODate == default(DateTime))
            {
                POHeader.PODate = DateTime.Now;
            }

            header.PODrugLines.Add(new PODrugLine());

            // Return the updated POHeader model to the view
            return RedirectToAction("PurchaseOrder", "Chemist");
        }

        //public ActionResult CreatePO(Models.POHeader POHeader)
        //{

        //    POHeader.supplier = db.suppliers.Find(POHeader.SupplierId);


        //    foreach (var DrgLn in POHeader.PODrugLines)

        //    {
        //        DrgLn.orderStatus = "pending";
        //        DrgLn.drug = db.drugs.Find(DrgLn.DrugId);

        //    }

        //    db.POHeaders.Add(POHeader);
        //    db.SaveChanges();

        //    ViewBag.SupplierID = new SelectList(db.suppliers, "supplierID", "name");


        //    ViewBag.Drugs = db.drugs.ToList();
        //    POHeader header = new POHeader();
        //    header.PODate = DateTime.Now;

        //    header.PODrugLines.Add(new PODrugLine());
        //    return View(header);
        //}

        public ActionResult CreateProductLine(string id)
        {
            ViewBag.slno = id;
            return PartialView();

            //try
            //{
            //    var model = db.PODrugLines.ToList();
            //    return View(model);
            //}
            //catch (Exception ex)
            //{
            //    // Log the exception (using NLog, Serilog, or similar tools)
            //    Console.WriteLine(ex.Message);
            //    return View(new List<PODrugLine>()); // Return an empty model as fallback
            //}
        }
        public ActionResult ViewPO()
        {
            var model = db.POHeaders
                          .Include(p => p.supplier)
                          .Include(p => p.PODrugLines.Select(d => d.drug))
                          .ToList();

            if (model == null)
            {
                model = new List<POHeader>();
            }

            return View(model);
        }

        public ActionResult DrugIndex()
        {

            return View(db.drugs.ToList());
        }

        // GET: Drug/Details/5
        //public ActionResult DrugDetails(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    drug drug = db.drugs.Find(id);
        //    if (drug == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(drug);
        //}

        // GET: Drug/Create
        public ActionResult DrugCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DrugCreate([Bind(Include = "drugID, name,description,price,Stock,expiry")] drug drug)
        {
            if (drug.expiry < DateTime.Now.Date)
            {
                ModelState.AddModelError("expiry", "The expiry date cannot be in the past.");
            }
            if (ModelState.IsValid)
            {
                db.drugs.Add(drug);
                db.SaveChanges();
                return RedirectToAction("DrugIndex", "Chemist");
            }

            return View(drug);
        }

        // GET: Drug/Edit/5
        public ActionResult DrugEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drug drug = db.drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        [HttpPost]
        public ActionResult DrugEdit([Bind(Include = "drugID, name,description,price,Stock,expiry")] drug drug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drug);
        }

        // GET: Drug/Delete/5
        public ActionResult DrugDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drug drug = db.drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        // POST: Drug/Delete/5
        [HttpPost]
        public ActionResult DrugDelete(int id)
        {
            drug drug = db.drugs.Find(id);
            db.drugs.Remove(drug);
            db.SaveChanges();
            return RedirectToAction("DrugIndex", "Chemist");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

    }
}