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
    public class MeasurementController : Controller
    {
        //
        // GET: /Master/Measurement/
        Models.MainViewModels main = new Models.MainViewModels();
        PopulatedDdl ddl = new PopulatedDdl();
        USOFTEntities db = new USOFTEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Measurement(string id)
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

            ViewBag.menu = new SelectList(dll.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
            return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public JsonResult GetMeasurement(GetMenuResult ddl, string searchvalue, string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = main.getMeasurement(searchvalue, ddl.ParamField, page, pageSize);
            var result = (List<spMeasurementList_Result>)obj[0];
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
        public ActionResult EditMeasurement(string value)
        {
            List<spMeasurementView_Result> meas = new List<spMeasurementView_Result>();
            MeasurementModel measurement = new MeasurementModel();
            ViewBag.active = new SelectList(ddl.ActiveStateToCombo().AsEnumerable());
            meas = measurement.getMeasurementResult(value);
            ViewBag.MeasurementCode = meas[0].MeasurementCode;
            ViewBag.MeasurementName = meas[0].MeasurementName;
            return View();
        }
        [HttpPost]
        public ActionResult EditMeasurement(Measurement meas,string IsActive,string SearchValue)
        {
            bool active;
            if (IsActive == "Active")
            {
                active = true;
            }
            else
                active = false;

            MeasurementModel measurement = new MeasurementModel();
            measurement.editMeasurement(SearchValue, meas.MeasurementName, active, "arie");
            return RedirectToAction("EditMeasurement","Measurement",new { value = meas.MeasurementCode});
        }
        public ActionResult AddMeasurement(string id)
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
        public ActionResult AddMeasurement(Measurement meas, string IsActive, string SearchValue)
        {
            bool active;
            if (IsActive == "Active")
            {
                active = true;
            }
            else
                active = false;

            MeasurementModel measurement = new MeasurementModel();
            measurement.insertMeasurement(SearchValue, meas.MeasurementName, active, Session["UserId"].ToString());
            return RedirectToAction("AddMeasurement", "Measurement");
        }
	}
}