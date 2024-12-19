using ClinicXAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicXAutomationSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        private ClinicDBEntitiess db = new ClinicDBEntitiess();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ErrorHttpStatus()
        {
            return View();
        }
        
        public ActionResult Features()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Support()
        {
            return View();
        }

        public ActionResult Drug()
        {
            var drugs = db.drugs.ToList();
            return View(drugs);
        }
    }
}