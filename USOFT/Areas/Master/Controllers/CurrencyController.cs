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
    public class CurrencyController : Controller
    {
        //
        // GET: /Master/Currency/
        Models.MainViewModels main = new Models.MainViewModels();
        PopulatedDdl ddl = new PopulatedDdl();
        USOFTEntities db = new USOFTEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Currency(string id)
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
                ViewBag.br = new SelectList(dll.brCombo().AsEnumerable(), "BranchId", "BranchName");
                ViewBag.menu = new SelectList(dll.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
                return View();
            }
               
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });

        }
        [HttpPost]
        public JsonResult GetCurrData(GetMenuResult ddl, string searchvalue, string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = main.GetCurrency(searchvalue, ddl.ParamField, page, pageSize);
            var result = (List<spCurrencyList_Result>)obj[0];
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
        public ActionResult EditCurrency(string value)
        {
            List<spCurrencyView_Result> curr = new List<spCurrencyView_Result>();
            CurrencyModel cr = new CurrencyModel();
            curr = cr.getCurrencyResult(value);
            ViewBag.curCode = curr[0].CurrencyCode;
            ViewBag.curName = curr[0].CurrencyName;
            ViewBag.curSym = curr[0].CurrencySymbol;
            ViewBag.active = new SelectList(ddl.ActiveStateToCombo().AsEnumerable());
            return View();
        }
        [HttpPost]
        public ActionResult EditCurrency(Currency curr, string IsActive, string SearchValue)
        {
            bool active;
            if (IsActive == "Active")
            {
                active = true;
            }
            else
                active = false;

            CurrencyModel cur = new CurrencyModel();
            cur.editCurr(SearchValue, curr.currencyCode, curr.currencySymbol, active, Session["UserId"].ToString());
            return RedirectToAction("EditCurrency", "Currency", new {value = curr.currencyCode });
        }
        public ActionResult AddCurrency(string id)
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
        public ActionResult addCurrency(Currency curr, string IsActive, string SearchValue)
        {
            bool active;
            if (IsActive == "Active")
            {
                active = true;
            }
            else
                active = false;

            CurrencyModel cur = new CurrencyModel();
            cur.insertCurr(SearchValue, curr.currencyCode, curr.currencySymbol, active, Session["UserId"].ToString());
            return RedirectToAction("AddCurrency", "Currency" );
        }
	}
}