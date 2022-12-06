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
    public class MasterController : Controller
    {
        //
        // GET: /InformationTechnology/Master/
        PopulatedDdl pop = new PopulatedDdl();
        MainITModel itmod = new MainITModel();
        ITMainModel it = new ITMainModel();
        public void isActive()
        {
            ViewBag.IsActive = new SelectList(pop.ActiveStateToCombo()).AsEnumerable();
        }
        public ActionResult Index()
        {
            return View();
        }
        public void populatedItemType(string id)
        {
            ViewBag.menu = new SelectList(pop.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
        }
        public void populatedProblemType(string id)
        {
            ViewBag.menu = new SelectList(pop.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
        }
        public void populatedSupplierType(string id)
        {
            ViewBag.menu = new SelectList(pop.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
        }
        public void populatedConditionType(string id)
        {
            ViewBag.menu = new SelectList(pop.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
        }
        public ActionResult ItemType(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
            populatedItemType(id);
            return View();
                 }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        public ActionResult ProblemType(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
            populatedProblemType(id);
            return View();
                 }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        public ActionResult SupplierList(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
            populatedSupplierType(id);
            return View();
                 }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        public ActionResult ITCondition(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
                populatedConditionType(id);
                return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public JsonResult GetItemType(GetMenuResult ddl, string inputText, string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = itmod.GetItemTypeList(inputText, ddl.ParamField, page, pageSize);
            var result = (List<spITItemType_Result>)obj[0];
            //"a.daris", "vch|UserId", 0 , " ", " ",page)
            int totalRecord = Convert.ToInt32(obj[2]);
            int totalPages = (int)Math.Ceiling((float)totalRecord / (float)pageSize);
            if (sord.ToUpper() == "DESC")
            {
                result = result.OrderByDescending(s => s.ItemTypeCode).ToList();
                //result = result.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            else
            {
                result = result.OrderBy(s => s.ItemTypeCode).ToList();
                //result = result.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            var jsonData = new
            {

                total = totalPages,
                page,
                records = totalRecord,
                rows = result
            };


            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetProblemType(GetMenuResult ddl, string inputText, string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = itmod.GetProblemTypeList(inputText, ddl.ParamField, page, pageSize);
            var result = (List<spITProblemTypeList_Result>)obj[0];
            //"a.daris", "vch|UserId", 0 , " ", " ",page)
            int totalRecord = Convert.ToInt32(obj[2]);
            int totalPages = (int)Math.Ceiling((float)totalRecord / (float)pageSize);
            if (sord.ToUpper() == "DESC")
            {
                result = result.OrderByDescending(s => s.ProblemTypeCode).ToList();
                //result = result.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            else
            {
                result = result.OrderBy(s => s.ProblemTypeCode).ToList();
                //result = result.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            var jsonData = new
            {

                total = totalPages,
                page,
                records = totalRecord,
                rows = result
            };


            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetConditionType(GetMenuResult ddl, string inputText, string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = itmod.getITConditionList(inputText, ddl.ParamField, page, pageSize);
            var result = (List<spITConditionList_Result>)obj[0];
            //"a.daris", "vch|UserId", 0 , " ", " ",page)
            int totalRecord = Convert.ToInt32(obj[2]);
            int totalPages = (int)Math.Ceiling((float)totalRecord / (float)pageSize);
            if (sord.ToUpper() == "DESC")
            {
                result = result.OrderByDescending(s => s.ConditionCode).ToList();
                //result = result.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            else
            {
                result = result.OrderBy(s => s.ConditionCode).ToList();
                //result = result.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            var jsonData = new
            {

                total = totalPages,
                page,
                records = totalRecord,
                rows = result
            };


            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetSupplier(GetMenuResult ddl, string inputText, string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = itmod.getITSupplierList(inputText, ddl.ParamField, page, pageSize);
            var result = (List<spITSupplierList_Result>)obj[0];
            //"a.daris", "vch|UserId", 0 , " ", " ",page)
            int totalRecord = Convert.ToInt32(obj[2]);
            int totalPages = (int)Math.Ceiling((float)totalRecord / (float)pageSize);
            if (sord.ToUpper() == "DESC")
            {
                result = result.OrderByDescending(s => s.SupplierCode).ToList();
                //result = result.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            else
            {
                result = result.OrderBy(s => s.SupplierCode).ToList();
                //result = result.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            var jsonData = new
            {

                total = totalPages,
                page,
                records = totalRecord,
                rows = result
            };


            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddITITtemType(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege(id);

                if (result[0].CanInsert == true)
                {
                    ViewBag.menuId = id;
                    isActive();
                    return View();
                }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult AddITITtemType(string pivchItemTypeCode, string pivchItemTypeName, string piibitIsActive)
        {
            itmod.addItemType(pivchItemTypeCode, pivchItemTypeName, activ(piibitIsActive));
            return RedirectToAction("AddITITtemType", "Master");
        }

        public bool activ(string input)
        {
            if (input == "Active")
            {
                return true;
            }
            else
                if (input == "False")
                {
                    return false;
                }
            return false;

        }
        public ActionResult AddITProblemType(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege(id);

                if (result[0].CanInsert == true)
                {
                    ViewBag.menuId = id;
            isActive();
            return View();
                         }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult AddITProblemType(string pivchProblemTypeCode, string pivchProblemTypeName, string piibitIsActive)
        {
            
            itmod.addProblemType(pivchProblemTypeCode, pivchProblemTypeName, activ(piibitIsActive));
            return RedirectToAction("AddITProblemType", "Master");
        }
        public ActionResult AddITCondition(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege(id);

                if (result[0].CanInsert == true)
                {
                    ViewBag.menuId = id;
                        isActive();
                        return View();
                }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult AddITCondition(int piintConditionCode, string pivchConditionName, string pibitIsActive)
        {
            itmod.addITCondition(piintConditionCode, pivchConditionName, activ(pibitIsActive));
            return RedirectToAction("AddITCondition", "Master");
        }
        public ActionResult AddITSupplier(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege(id);

                if (result[0].CanInsert == true)
                {
                    ViewBag.menuId = id;
            isActive();
            return View();
                }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult AddITSupplier(string pivchSupplierName, string pivchAddress, string pivchCity, string pivchZipCode, string pivchPhone, string pivchNPWP, string pivchState, string pibitIsActive)
        {
            string supplierCode = it.addITSupplier(pivchSupplierName, pivchAddress, pivchCity, pivchZipCode, pivchPhone, pivchNPWP, "IT", activ(pibitIsActive));
            return RedirectToAction("AddITSupplier", "Master");
        }
        public ActionResult EditITItemType(string value)
        {
            List<spITItemTypeView_Result> row = new List<spITItemTypeView_Result>();
            row = it.getITitem(value);
            ViewBag.ItemCode = row[0].ItemTypeCode;
            ViewBag.ItemName = row[0].ItemTypeName;
            isActive();
            return View();
        }
          [HttpPost]
        public ActionResult EditITItemType(string pivchItemTypeCode, string pivchItemTypeName, string pibitIsActive)
        {
            bool active = false;
            if (pibitIsActive == "Active")
	        {
		        active = true;
	        }
            else
            {
                active = false;
            }
            it.updateITItemType(pivchItemTypeCode, pivchItemTypeName, active);
            return RedirectToAction("EditITitemType", "Master", new { value = pivchItemTypeCode });
        }
        public ActionResult EditITCondition(int value)
        {
            isActive();
            List<spITConditionView_Result> row = new List<spITConditionView_Result>();
            row = it.getITCondition(value);
            ViewBag.ConditionCode = row[0].ConditionCode;
            ViewBag.ConditionName = row[0].ConditionName;
            return View();
        }
        [HttpPost]
        public ActionResult EditITCondition(int? piintConditionCode, string pivchConditionName, string pibitIsActive)
        {
            bool active = false;
            if (pibitIsActive == "Active")
            {
                active = true;
            }
            else
            {
                active = false;
            }
            it.updateITCondition(piintConditionCode, pivchConditionName, active);
            return RedirectToAction("EditITCondition", "Master", new { value = piintConditionCode });
        }
        public ActionResult EditProblemType(string value)
        {
            isActive();
            List<spITProblemTypeView_Result> row = new List<spITProblemTypeView_Result>();
            row = it.getProbType(value);
            ViewBag.ProbCode = row[0].ProblemTypeCode;
            ViewBag.ProbName = row[0].ProblemTypeName;
            return View();
        }
        [HttpPost]
        public ActionResult EditProblemType(string pivchProblemTypeCode, string pivchProblemTypeName, string pibitIsActive)
        {
            bool active = false;
            if (pibitIsActive == "Active")
            {
                active = true;
            }
            else
            {
                active = false;
            }
            it.updateITProblemType(pivchProblemTypeCode, pivchProblemTypeName, active);
            return RedirectToAction("EditProblemType", "Master", new { value = pivchProblemTypeCode });
        }
        public ActionResult EditSupplier(string value)
        {
            isActive();
            List<spSupplierView_Result> row = new List<spSupplierView_Result>();
            row = it.getSup(value);
            ViewBag.supCode = value;
            ViewBag.supName = row[0].SupplierName;
            ViewBag.address = row[0].Address;
            ViewBag.city = row[0].City;
            ViewBag.zipCode = row[0].ZipCode;
            ViewBag.phone = row[0].Phone;
            ViewBag.npwp = row[0].NPWP;
            return View();
        }
        [HttpPost]
        public ActionResult EditSupplier(string pivchSupplierCode, string pivchSupplierName, string pivchAddress, string pivchCity, string pivchZipCode, string pivchPhone, string pivchNPWP, string pivchState, string pibitIsActive)
        {
            bool active = false;
            if (pibitIsActive == "Active")
            {
                active = true;
            }
            else
            {
                active = false;
            }
            it.updateITSupplier(pivchSupplierCode, pivchSupplierName, pivchAddress, pivchCity, pivchZipCode, pivchPhone, pivchNPWP, "IT", active);
            return RedirectToAction("EditSupplier", "Master", new {value = pivchSupplierCode });
        }

	}
}