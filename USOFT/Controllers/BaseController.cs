using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USOFT.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
   
            public void cekSession()
            {
                if (HttpContext.Session["UserId"] == null)
	            {
                    RedirectToAction("LogOut", "Account", new { area = "" });
	            }
            }

            // If the current user is authenticated, check to make sure the user's
            // profile has been loaded into session
         
	}
}
