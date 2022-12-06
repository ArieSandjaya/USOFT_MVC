﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
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
using Usoft.Common.CommonFunction;
using System.Web.UI.WebControls;

namespace USOFT.Areas.Master.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Master/Users/
        Models.MainViewModels main = new Models.MainViewModels();
        PopulatedDdl ddl = new PopulatedDdl();
        USOFTEntities db = new USOFTEntities();
     
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Users(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
                List<spUsersList_Result> user = new List<spUsersList_Result>();
                populated(id);
                return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
            
        }
        public void populated(string id)
        {
            ViewBag.br = new SelectList(ddl.brCombo().AsEnumerable(), "BranchId", "BranchName");
            ViewBag.dpt = new SelectList(ddl.deptCombo().AsEnumerable(), "DepartementCode", "DepartementName");
            ViewBag.prev = new SelectList(ddl.prevCombo().AsEnumerable(), "PrivilegeCode", "PrivilegeName");
            ViewBag.menu = new SelectList(ddl.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
        }
        public void populatedForAdd()
        {
            ViewBag.br = new SelectList(ddl.brCombo().AsEnumerable(), "BranchId", "BranchName");
            ViewBag.activ = new SelectList(ddl.ActiveStateToCombo().AsEnumerable());
            ViewBag.canChangePass = new SelectList(ddl.canChangePassToCombo().AsEnumerable());
            ViewBag.canSendMail = new SelectList(ddl.canSendEmail().AsEnumerable());
        }
        [HttpPost]
        public JsonResult GetUserData(GetMenuResult ddl, string SearchValue, GetBranchToCombo br, GetDepartmentToCombo_Result dpt, GetPrevilegeToCombo prev, string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = main.GetUsers(SearchValue, ddl.ParamField, br.BranchId, dpt.DepartementCode, prev.PrivilegeCode, page, pageSize);
            var result = (List<spUsersList_Result>)obj[0];
            int totalRecord = Convert.ToInt32(obj[2]);
            int totalPages = (int)Math.Ceiling((float)totalRecord / (float)pageSize);
            if (sord.ToUpper() == "DESC")
            {
                result = result.OrderByDescending(s => s.UserId).ToList();
            }
            else
            {
                result = result.OrderBy(s => s.UserId).ToList();
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
        public ActionResult AddUsers(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            ViewBag.menuId = id;
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege(id);

                if (result[0].CanInsert == true)
                {
                    ViewBag.menuId = id;
                    populatedForAdd();
                    return View();
                }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult AddUsers(string id,User user, GetBranchToCombo br, string activeState, string canChangeMail, string canChangePass)
        public ActionResult AddUsers(User user)
        {
            bool state;
            if (user.isActive == true)
            {
                state = true;
            }
            else
                state = false;
            if (ModelState.IsValid)
            {
                db.spUsersInsert(user.pivchUserId, user.pivchUserName, user.pivchNIK, user.piintBranchId, user.pivchEmail, user.pivchEmailB2B, user.pivchPass, user.pivchCanSendEmail, user.pivchCanChangePass, state, Session["UserId"].ToString());
            }
            else
            {
 
            }
            return RedirectToAction("AddUsers", "Users");
        }
        public ActionResult EditUsers(string value)
        {
            List<spUsersView_Result> msuser = new List<spUsersView_Result>();
            msuser = db.spUsersView(value).ToList();
            ViewBag.UserId = msuser[0].UserId;
            ViewBag.UserName = msuser[0].UserName;
            ViewBag.NIK = msuser[0].NIK;
            ViewBag.Branch = msuser[0].BranchId;
            ViewBag.Email = msuser[0].Email;
            ViewBag.B2B = msuser[0].EmailB2B;
            ViewBag.br = new SelectList(ddl.brCombo(), "BranchId", "BranchName").AsEnumerable();
            ViewBag.active = new SelectList(ddl.ActiveStateToCombo().AsEnumerable());
            ViewBag.canChangePass = new SelectList(ddl.canChangePassToCombo().AsEnumerable());
            ViewBag.canChangeMail = new SelectList(ddl.canSendEmail().AsEnumerable());
            return View();
        }
        [HttpPost]
        public ActionResult EditUsers(string Password, spUsersView_Result user, int BranchName, string IsActive, string changePass, string changeMail)
        {
            UserUpdate us = new UserUpdate();
            bool act;
            if (IsActive == "Active")
            {
                act = true;
            }
            else
                act = false;
            us.updateUser(user.UserId, user.UserName, user.NIK, BranchName, user.Email, user.EmailB2B, Password, changeMail, changePass, act, Session["UserId"].ToString());
            return RedirectToAction("Users", "Users");
        }

	}
        
}