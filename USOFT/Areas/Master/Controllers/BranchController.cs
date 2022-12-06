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
    public class BranchController : Controller
    {
        //
        // GET: /Master/Branch/
        Models.MainViewModels main = new Models.MainViewModels();
        PopulatedDdl ddl = new PopulatedDdl();
        USOFTEntities db = new USOFTEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Branch(string id)
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
                return RedirectToAction("Users");
          
        }
        [HttpPost]
        public JsonResult GetBranchData(GetMenuResult ddl, string searchvalue, string sidx, string sord, int rows, int page = 1)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = main.GetBranch(searchvalue, ddl.ParamField, page, pageSize);
            var result = (List<spBranchList_Result>)obj[0];
            int totalRecord = Convert.ToInt32(obj[2]);
            var totalPages = (int)Math.Ceiling((float)totalRecord / (float)pageSize);
            var jsonData = new
            {

                total = totalPages,
                page,
                records = totalRecord,
                rows = result.ToList()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditBranch(int value)
        {

            List<spBranchView_Result> branch = new List<spBranchView_Result>();
            BranchModel br = new BranchModel();
            branch = br.getBranchResult(value);
            ViewBag.brId = branch[0].BranchId;
            ViewBag.brName = branch[0].BranchName;
            ViewBag.brCode = branch[0].BranchCode;
            ViewBag.brAdd = branch[0].BranchAddress;
            ViewBag.brPhone = branch[0].BranchPhone;
            ViewBag.brType = new SelectList(ddl.branchType().AsEnumerable());
            ViewBag.brParent = new SelectList(ddl.brCombo().AsEnumerable(), "BranchId", "BranchName");
            ViewBag.active = new SelectList(ddl.ActiveStateToCombo().AsEnumerable());
            return View();
        }
        [HttpPost]
        public ActionResult editBranch(Branch br, string IsActive, string BranchType, int SearchValue,int? branchParent)
        {
            if (BranchType == "BRANCH")
            {
                branchParent = null;
            }
            bool active;
            if (IsActive == "Active")
            {
                active = true;
            }
            else
                active = false;
            int type;
            if (BranchType == "- SELECT ONE -")
            {
                type = 0;
            }
            else
                if (BranchType == "BRANCH")
                {
                    type = 1;
                }
                else
                    type = 2;
            BranchModel bra = new BranchModel();

            bra.editBranch(SearchValue, br.BranchCode, br.BranchName, type, branchParent, br.BranchAddress, br.BranchPhone, active, Session["UserId"].ToString());
            return RedirectToAction("EditBranch", "Branch", new {value = br.BranchId });
        }
        public ActionResult AddBranch(string id)
        {
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege(id);

                if (result[0].CanInsert == true)
                {
                    ViewBag.brType = new SelectList(ddl.branchType().AsEnumerable());
                    ViewBag.brParent = new SelectList(ddl.brCombo().AsEnumerable(), "BranchId", "BranchName");
                    ViewBag.active = new SelectList(ddl.ActiveStateToCombo().AsEnumerable());
                    ViewBag.menuId = id;
                    return View();
                }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
            return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult addBranch(Branch br, string IsActive, string BranchType, int SearchValue, int? branchParent)
        {
            if (BranchType == "BRANCH")
            {
                branchParent = null;
            }
            bool active;
            if (IsActive == "Active")
            {
                active = true;
            }
            else
                active = false;
            int type;
            if (BranchType == "- SELECT ONE -")
            {
                type = 0;
            }
            else
                if (BranchType == "BRANCH")
                {
                    type = 1;
                }
                else
                    type = 2;
            BranchModel model = new BranchModel();
            model.insertBranch(SearchValue, br.BranchCode, br.BranchName, type, branchParent, br.BranchAddress, br.BranchPhone, active, Session["UserId"].ToString());
            return RedirectToAction("AddBranch", "Branch");

        }
    }
}