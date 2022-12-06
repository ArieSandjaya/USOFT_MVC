using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using USOFT.Models;
using USOFT.DataAccess.Users;

namespace USOFT.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: /Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        //
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            UserLogOn ULogOn = new UserLogOn();
            var bStatus = ULogOn.doLogon(model.UserName, model.Password);
            if (bStatus == true)
            {
                return RedirectToAction("Users","Master");
            }
            return View(model);
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            ViewBag.Message = "You dont have privilege to access menu,please re-Log in";
            return RedirectToAction("Login", "Account");
        }
	}
}