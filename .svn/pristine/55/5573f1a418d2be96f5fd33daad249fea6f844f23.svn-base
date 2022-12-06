using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USOFT.DataAccess.General;
using USOFT.DataAccess.Departement;
using USOFT.DataAccess.Currency;
using USOFT.DataAccess.Branch;
using USOFT.DataAccess.Measurement;
using USOFT.DataAccess.Upload;
using USOFT.DataAccess.IT;
using USOFT.Models;
using USOFT.DataAccess;
namespace USOFT.Areas.InformationTechnology.Controllers
{
    public class ITItemController : Controller
    {
        //
        // GET: /InformationTechnology/ITItem/

        PopulatedDdl pop = new PopulatedDdl();
        MainITModel itmod = new MainITModel();
        ITMainModel it = new ITMainModel();
        public void ITItemInPopulated()
        {
            ViewBag.menu = new SelectList(pop.getMenu("116102", "").AsEnumerable(), "ParamField", "ParamName");
            ViewBag.br = new SelectList(pop.brCombo().AsEnumerable(), "BranchId", "BranchName");
            ViewBag.Receive = new SelectList(pop.ReceiveFrom().AsEnumerable());
            ViewBag.sup = new SelectList(pop.supplierCombo().AsEnumerable(), "SupplierCode", "SupplierName");
            ViewBag.pic = new SelectList(pop.mapuser().AsEnumerable(), "UserId", "UserName");
            ViewBag.DocStatus = new SelectList(pop.DocStatus().AsEnumerable());

        }
        public void ITItemPopulated()
        {
            ViewBag.menu = new SelectList(pop.getMenu("116101", "").AsEnumerable(), "ParamField", "ParamName");
            ViewBag.CurrentLoc = new SelectList(pop.currentLocCombo().AsEnumerable(), "BranchId", "BranchName");
            ViewBag.item = new SelectList(pop.itemType().AsEnumerable(), "ItemTypeCode", "ItemTypeName");
            ViewBag.Condition = new SelectList(pop.ITItemCondition().AsEnumerable(), "ConditionCode", "ConditionName");
            ViewBag.itemIn = new SelectList(pop.ITitemInStatus().AsEnumerable());
            ViewBag.itemOut = new SelectList(pop.ITitemOutStatus().AsEnumerable());
            ViewBag.activ = new SelectList(pop.ActiveStateToCombo().AsEnumerable());
        }

        public ActionResult ITItemList(string id)
        {
             Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
            ITItemPopulated();
            return View();
                      }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
            
        }

        [HttpPost]
        public JsonResult GetItemData(string itemOut, string itemIn, string ItemType, int Condition, int CurrentLocation, GetMenuResult ddl, string SearchValue, string sidx, string sord, int? page, int rows)
        {


            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = itmod.GetITItem(itemOut, itemIn, Condition, ItemType, CurrentLocation, SearchValue, ddl.ParamField, page, pageSize);
            var result = (List<spITMailReminderList_Result>)obj[0];

            int totalRecord = Convert.ToInt32(obj[2]);
            int totalPages = (int)Math.Ceiling((float)totalRecord / (float)pageSize);
       
            var jsonData = new
            {

                total = totalPages,
                page,
                records = totalRecord,
                rows = result
            };


            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ItemIn(string id)
        {
             Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
                ITItemInPopulated();
                return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
            
        }
        [HttpPost]
        public JsonResult GetItemReceiveData(DateTime? datepicker, string receive, string Vendor, string pic, string DocStatus, int? BranchId, GetMenuResult ddl, string SearchValue, string sidx, string sord, int? page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = itmod.GetReceiveItemData(datepicker, receive, BranchId, Vendor, pic, DocStatus, SearchValue, ddl.ParamField, page, pageSize);
            var result = (List<spITItemReceive_Result>)obj[0];
            int totalRecord = Convert.ToInt32(obj[2]);
            int totalPages = (int)Math.Ceiling((float)totalRecord / (float)pageSize);
            var jsonData = new
            {

                total = totalPages,
                page,
                records = totalRecord,
                rows = result
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddITItemIn()
        {
            ITItemInPopulated();
            return View();

        }
        [HttpPost]
        public ActionResult AddITItemIn(string Receive,DateTime? datepicker, int? piintBranchFrom, string pivchSupplierCode)
        {
            string supCode;
            int? brFrom;
            if (Receive == "Branch")
            {
                brFrom = piintBranchFrom;
            }
            else
            {
                brFrom = null;
            }

            if (Receive == "Vendor")
            {
                supCode = pivchSupplierCode;
            }
            else
            {
                supCode = null;
            }
            string itItemInCode = it.addItemReceive(datepicker, brFrom, supCode);
            return RedirectToAction("AddITItemIn", "ITItem");
        }
	}
}