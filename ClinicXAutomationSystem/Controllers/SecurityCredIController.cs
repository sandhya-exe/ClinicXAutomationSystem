using ClinicXAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ClinicXAutomationSystem.Controllers
{
    public class SecurityCredIController : Controller
    {
        // GET: SecurityCredI
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel user)
        {
            if (ModelState.IsValid)
            {

                Models.ClinicDBEntitiess _db = new ClinicDBEntitiess();

                Models.User usr = _db.Users.FirstOrDefault(dbusr => dbusr.UserName.ToLower() == user.UserName.ToLower() && dbusr.  Password == user.Password);


                if (usr != null)
                {
                    FormsAuthentication.SetAuthCookie(usr.UserName, false);
                    CurrentUserModel cusr = new CurrentUserModel();
                    cusr.UserName = usr.UserName;
                    //cusr.ReferenceToId = usr.ReferenceId.ToString();
                    cusr.ReferenceToId = usr.ReferenceId;
                    cusr.UserID = usr.UserId;
                    cusr.Role = usr.Role;

                    if (usr.Role.ToUpper() == "PHYSICIAN")
                    {
                        var phy = _db.physicians.Find(usr.ReferenceId);
                        cusr.UserName = phy.name;
                    }

                    if (usr.Role.ToUpper() == "PATIENT")
                    {
                        var ptn = _db.patients.Find(usr.ReferenceId);
                        cusr.UserName = ptn.name;
                    }

                    if (usr.Role.ToUpper() == "CHEMIST")
                    {
                        var chem = _db.chemists.Find(usr.ReferenceId);
                        cusr.UserName = chem.name;
                    }

                    if (usr.Role.ToUpper() == "SUPPLIER")
                    {
                        var supp = _db.suppliers.Find(usr.ReferenceId);
                        cusr.UserName = supp.name;
                    }



                    Session["CurrentUser"] = cusr;
                    return RedirectToAction("Index", usr.Role);
                }
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}