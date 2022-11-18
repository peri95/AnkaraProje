using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnkaraProje.Models;

namespace AnkaraProje.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        DbAnkaraPortfolioEntities db= new DbAnkaraPortfolioEntities();
        public ActionResult Inbox()
        {
            var mail = Session["EmployeeMail"].ToString();
            var values = db.TblMessage.Where(x => x.ReceiverMessage == mail).ToList();
            return View(values);
        }
        public ActionResult Outbox()
        {
            var mail = Session["EmployeeMail"].ToString();
            var values = db.TblMessage.Where(x => x.SenderMessage == mail).ToList();
            return View(values);
        }
        public ActionResult MessageDetails(int id)
        {
            var values = db.TblMessage.Find(id);
            return View(values);
        }

        public ActionResult ProfileGet()
        {
            var mail = Session["EmployeeMail"].ToString();
            ViewBag.v1 = db.TblEmployee.Where(x => x.EmployeeMail == mail).Select(y => y.EmployeeName).FirstOrDefault();
            ViewBag.v2 = db.TblEmployee.Where(x => x.EmployeeMail == mail).Select(y => y.EmployeeSurname).FirstOrDefault();
            ViewBag.v3 = db.TblEmployee.Where(x => x.EmployeeMail == mail).Select(y => y.EmployeeMail).FirstOrDefault();
            ViewBag.v4 = db.TblEmployee.Where(x => x.EmployeeMail == mail).Select(y => y.EmployeePassword).FirstOrDefault();
            ViewBag.v5 = db.TblEmployee.Where(x => x.EmployeeMail == mail).Select(y => y.EmployeeID).FirstOrDefault();
            return View();
        }           

    }
}