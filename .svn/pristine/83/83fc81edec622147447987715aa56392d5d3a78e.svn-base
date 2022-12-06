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


namespace USOFT.Controllers
{
    public class ITMasterController : Controller
    {
        PopulatedDdl pop = new PopulatedDdl();
        MainITModel itmod = new MainITModel();
        ITMainModel it = new ITMainModel();
        //
        // GET: /ITMaster/
        public void isActive()
        {
           ViewBag.IsActive = new SelectList( pop.ActiveStateToCombo()).AsEnumerable();
        }
        public ActionResult Index()
        {
            return View();
        }
        public void populatedItemType()
        {
            ViewBag.menu = new SelectList(pop.getMenu("116901", "").AsEnumerable(), "ParamField", "ParamName");
        }
        public void populatedProblemType()
        {
            ViewBag.menu = new SelectList(pop.getMenu("116902", "").AsEnumerable(), "ParamField", "ParamName");
        }
        public void populatedSupplierType()
        {
            ViewBag.menu = new SelectList(pop.getMenu("116903", "").AsEnumerable(), "ParamField", "ParamName");
        }
        public void populatedConditionType()
        {
            ViewBag.menu = new SelectList(pop.getMenu("116904", "").AsEnumerable(), "ParamField", "ParamName");
        }
        public ActionResult ItemType()
        {
            populatedItemType();
            return View();
        }
        public ActionResult ProblemType()
        {
            populatedProblemType();
            return View();
        }
        public ActionResult SupplierList()
        {
            populatedSupplierType();
            return View();
        }
        public ActionResult ITCondition()
        {
            populatedConditionType();
            return View();
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
        public ActionResult AddITITtemType()
        {
            isActive();
            return View();
        }
        [HttpPost]
        public ActionResult AddITITtemType(string pivchItemTypeCode, string pivchItemTypeName, string piibitIsActive)
        {
            itmod.addItemType(pivchItemTypeCode, pivchItemTypeName, activ(piibitIsActive));
            return RedirectToAction("AddITITtemType", "ITMaster");
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
        public ActionResult AddITProblemType()
        {
            isActive();
            return View();
        }
        [HttpPost]
        public ActionResult AddITProblemType(string pivchProblemTypeCode, string pivchProblemTypeName,string piibitIsActive)
        {
            itmod.addProblemType(pivchProblemTypeCode, pivchProblemTypeName, activ(piibitIsActive));
            return RedirectToAction("AddITProblemType", "ITMaster");
        }
        public ActionResult AddITCondition()
        {
            isActive();
            return View();
        }
        [HttpPost]
        public ActionResult AddITCondition(int piintConditionCode, string pivchConditionName, string pibitIsActive)
        {
            itmod.addITCondition(piintConditionCode, pivchConditionName, activ(pibitIsActive));
            return RedirectToAction("AddITCondition", "ITMaster");
        }
        public ActionResult AddITSupplier()
        {
            isActive();
            return View();
        }
        [HttpPost]
        public ActionResult AddITSupplier(string pivchSupplierName,string pivchAddress,string pivchCity,string pivchZipCode,string pivchPhone,string pivchNPWP,string pivchState,string pibitIsActive)
        {
            string supplierCode = it.addITSupplier(pivchSupplierName, pivchAddress, pivchCity, pivchZipCode, pivchPhone, pivchNPWP, "IT", activ(pibitIsActive));
            return RedirectToAction("AddITSupplier", "ITMaster");
        }
	}
}
	

