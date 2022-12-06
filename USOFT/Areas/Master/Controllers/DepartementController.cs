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
    public class DepartementController : Controller
    {
        //
        // GET: /Master/Departement/
        Models.MainViewModels main = new Models.MainViewModels();
        PopulatedDdl ddl = new PopulatedDdl();
        USOFTEntities db = new USOFTEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Departement(string id)
        {Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
            ViewBag.menu = new SelectList(ddl.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
            return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });

        }
        [HttpPost]
        public JsonResult GetDeptData(GetMenuResult ddl, string searchvalue, string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = main.GetDept(searchvalue, ddl.ParamField, page, pageSize);
            var result = (List<spDeptList_Result>)obj[0];
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
        public ActionResult EditDepartement(string value)
        {
            List<spDepartementView_Result> dept = new List<spDepartementView_Result>();
            DeptMeodel dpt = new DeptMeodel();
            dept = dpt.getDeptResult(value);
            ViewBag.Deptcode = dept[0].DepartementCode;
            ViewBag.Deptname = dept[0].DepartementName;
            ViewBag.Code = dept[0].CodeName;
            ViewBag.active = new SelectList(ddl.ActiveStateToCombo().AsEnumerable());
            return View();
        }
        [HttpPost]
        public ActionResult EditDepartement(Departement dpt, string IsActive)
        {
            bool active;
            if (IsActive == "Active")
            {
                active = true;
            }
            else
                active = false;
            DeptMeodel depts = new DeptMeodel();
            depts.editDept(dpt.departementCode, dpt.departementName, dpt.CodeName, active, "arie");
            return RedirectToAction("EditDepartement", "Departement", new {value = dpt.departementCode });
        }
        public ActionResult AddDepartement(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege(id);

                if (result[0].CanInsert == true)
                {
                ViewBag.active = new SelectList(ddl.ActiveStateToCombo().AsEnumerable());
                ViewBag.menuId = id;
                return View();
                }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult AddDepartement(Departement dept, string IsActive)
        {
            bool active;
            if (IsActive == "Active")
            {
                active = true;
            }
            else
                active = false;
            DeptMeodel depts = new DeptMeodel();
            depts.insertDept(dept.departementCode, dept.departementName, dept.CodeName, active, "arie");
            return RedirectToAction("AddDepartement","Departement");
        }
	}
}