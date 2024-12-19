using ClinicXAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ClinicXAutomationSystem.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ClinicDBEntitiess db = new ClinicDBEntitiess();

        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewOrders()
        {
            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;

            if (currentUser == null)
            {
                return Content("Invalid user session.");
            }

            // Directly use ReferenceToId as it is an int
            int supplierID = currentUser.ReferenceToId ?? 0;

            // Fetch the relevant data for the supplier
            var productLine = db.PODrugLines
                .Include("drug")
                .Include("POHeader")
                .Where(p => p.POHeader.SupplierId == supplierID && p.orderStatus != "Supplied")
                .ToList();

            return View(productLine);
        }
        //[HttpPost]
        //public ActionResult ViewOrders()
        //{
        //    var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;

        //    int supplierID;
        //    if (!int.TryParse(currentUser.referencetoID, out supplierID))
        //    {
        //        return Content("Invalid user ID.");
        //    }

        //    var productHeader = db.POHeaders.Include("supplier").Where(s => s.supplierID == supplierID);

        //    var productLine = db.PODrugLines.Include("drug").Include("POHeader").Where(p => p.POHeader.supplierID == supplierID && p.orderStatus == "Pending");

        //    return View();
        //}

        [HttpPost]
        public ActionResult UpdateOrderStatus(int PODrugID, string orderStatus)
        {
            // Find the specific PODrugLine entry in the database
            var drugLine = db.PODrugLines.FirstOrDefault(p => p.PODrugId == PODrugID);
            if (drugLine == null)
            {
                return HttpNotFound();
            }

            // Update the orderStatus
            drugLine.orderStatus = orderStatus;

            // Save the changes
            db.SaveChanges();

            // Redirect back to the ViewOrders page
            return RedirectToAction("ViewOrders");
        }

        public ActionResult ViewSuppliedOrders()
        {
            var currentUser = Session["CurrentUser"] as Models.CurrentUserModel;

            if (currentUser == null)
            {
                return Content("Invalid user session.");
            }

            // Directly use ReferenceToId as it is an int
            int supplierID = currentUser.ReferenceToId ?? 0;

            // Fetch the relevant data for the supplier
            var productLine = db.PODrugLines
                .Include("drug")
                .Include("POHeader")
                .Where(p => p.POHeader.SupplierId == supplierID && p.orderStatus == "Supplied")
                .ToList();

            return View(productLine);
        }
    }
}

