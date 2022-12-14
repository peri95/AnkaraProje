using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AnkaraProje.Models;

namespace AnkaraProje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        DbAnkaraPortfolioEntities db= new DbAnkaraPortfolioEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            var values = db.TblAdmin.FirstOrDefault(X=>X.Username== p.Username && X.Password ==p.Password);
            if(values!=null)
            {
                //giriş yapma işlemi
                FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["Username"] = values.Username;
                return RedirectToAction("SkillList", "Skill");
            }
            else
            {
                ViewBag.v = "Hatalı Kullanıcı Adı veya Şifre";
                return View();
                
            }
            
        }
    }
}