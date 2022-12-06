using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USOFT.DataAccess;
using USOFT.DataAccess.Users;
using USOFT.Models;
using USOFT.DataAccess.General;
using USOFT.DataAccess.Departement;
using USOFT.DataAccess.Currency;
using USOFT.DataAccess.Branch;
using USOFT.DataAccess.Measurement;
using USOFT.DataAccess.Upload;
using System.Collections;
using PagedList;
using System.Data.Entity.Core.Objects;
using Newtonsoft;

namespace USOFT.Areas.Master.Controllers
{
    public class PrivilegeController : Controller
    {
        //
        // GET: /Master/Privilege/
        Models.MainViewModels main = new Models.MainViewModels();
        PopulatedDdl ddl = new PopulatedDdl();
        USOFTEntities db = new USOFTEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Privilege(string id)
        {
             Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
                PopulatedDdl dll = new PopulatedDdl();
                ViewBag.dpt = new SelectList(dll.deptCombo().AsEnumerable(), "DepartementCode", "DepartementName");
                ViewBag.menu = new SelectList(dll.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
                return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public JsonResult GetPrevData(GetMenuResult ddl, string searchvalue, GetDepartmentToCombo_Result dpt, string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            List<Object> obj = main.GetPrev(searchvalue, ddl.ParamField, dpt.DepartementCode, page, pageSize);
            var result = (List<getPrevList_Result>)obj[0];
            int totalRecord = Convert.ToInt32(obj[2]);
            var totalPages = (int)Math.Ceiling((float)totalRecord / (float)pageSize);
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecord,
                rows = result
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPrivilegeMenu()
        {
            List<spPrivilegeMenuList_Result> priv = new List<spPrivilegeMenuList_Result>();
            priv = main.getPrivMenu();
            var result = priv;
           
            var jsonData = new
            {
             
             
                rows = result
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditPrivilege(string value)
        {
            List<spPrivilegeView_Result> prev = new List<spPrivilegeView_Result>();
            prev = db.spPrivilegeView(value).ToList();
            ViewBag.PrevId = prev[0].PrivilegeCode;
            ViewBag.PrevName = prev[0].PrivilegeName;
            ViewBag.PrivShortName = prev[0].PrivilegeShortName;
            ViewBag.oldCode = prev[0].OldCode;
            ViewBag.dpt = new SelectList(ddl.deptCombo().AsEnumerable(), "DepartementCode", "DepartementName");
            ViewBag.active = new SelectList(ddl.ActiveStateToCombo().AsEnumerable());
            return View();
        }
        [HttpPost]
        public ActionResult EditPrivilege(spPrivilegeView_Result prive, GetDepartmentToCombo_Result departement, string isActive)
        {
            
            PrivilageModel priv = new PrivilageModel();
            bool active;
            if (isActive == "Active")
            {
                active = true;
            }
            else
                active = false;

            priv.updatePrev(prive.PrivilegeCode, prive.PrivilegeName, prive.PrivilegeShortName, departement.DepartementCode, prive.OldCode, active, Session["UserId"].ToString());
            return RedirectToAction("EditPrivilege", "Privilege" ,new {value =prive.PrivilegeCode });
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult BatchUpdate(List<spPrivilegeMenuList_Result> viewModelsBatch)
        {
            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddPrivilege(string id)
        {
              Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege(id);

                if (result[0].CanInsert == true)
                {
                    ViewBag.menuId = id;
                    ViewBag.dpt = new SelectList(ddl.deptCombo().AsEnumerable(), "DepartementCode", "DepartementName");
                    ViewBag.active = new SelectList(ddl.ActiveStateToCombo().AsEnumerable());
                    return View();
                }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult AddPrivilege(Privilege prive, GetDepartmentToCombo_Result dept, string isActive)
        {
            PrivilageModel priv = new PrivilageModel();
            bool active;
            if (isActive == "Active")
            {
                active = true;
            }
            else
                active = false;
            priv.createPrev(prive.PrivilegeCode, prive.PrivilegeName, prive.PrivilegeShortName, dept.DepartementCode, prive.OldCode, active, "arie");
            return RedirectToAction("AddPrivilege", "Privilege");
        }
	} 
}