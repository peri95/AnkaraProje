using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AnkaraProje.Models;

namespace AnkaraProje.Controllers
{
    public class EmployeeLoginController : Controller
    {
        // GET: EmployeeLogin
        DbAnkaraPortfolioEntities db = new DbAnkaraPortfolioEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblEmployee p)
        {
            var values = db.TblEmployee.FirstOrDefault(X => X.EmployeeMail == p.EmployeeMail && X.EmployeePassword == p.EmployeePassword);
            if (values != null)
            {
                //giriş yapma işlemi
                FormsAuthentication.SetAuthCookie(values.EmployeeMail, false);
                Session["EmployeeMail"] = values.EmployeeMail;
                return RedirectToAction("ProfileGet", "Message");
            }
            else
            {
                return RedirectToAction("Index");

            }
        }
    }
}