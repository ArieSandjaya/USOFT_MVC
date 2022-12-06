using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USOFT.DataAccess.General;
using USOFT.Models;
using USOFT.DataAccess;
using Usoft.Common.CommonFunction;

namespace USOFT.Areas.HR.Controllers
{
    public class AccessAndUserIDRequestController : Controller
    {
        PopulatedDdl pop = new PopulatedDdl();
        HRMainModel hr = new HRMainModel();
        CommonFunction cf = new CommonFunction();
        //
        // GET: /HR/AccessAndUserIDRequest/
        public ActionResult Index()
        {
            return View();
        }
        public void populatedDdl()
        {
            ViewBag.br = new SelectList(pop.brCombo().AsEnumerable(), "BranchId", "BranchName");
            ViewBag.dpt = new SelectList(pop.deptCombo().AsEnumerable(), "DepartementCode", "DepartementName");
            ViewBag.job = new SelectList(pop.hrJobType().AsEnumerable(), "JobTypeId", "JobTypeName");
            ViewBag.stat = new SelectList(pop.AccessStatus().AsEnumerable());
            ViewBag.process = new SelectList(pop.ProcessStatus().AsEnumerable());
        }
        public ActionResult AddUserRequest(string id)
        {
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {

                List<spGetUserInfo_Result> userInfo = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                userInfo = cekpriv.privilege(id);
                ViewData["Privilege"] = userInfo;
                populatedDdl();
                ViewBag.menuId = id;
                ViewBag.menu = new SelectList(pop.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
                return View();

            }
            return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        public JsonResult GetAddUserRequest(string SearchValue, GetMenuResult ddl, string DatePickerReady, int? BranchId, string DepartementCode, string JobType, string status, string process, int? page, int rows, string sidx, string sord)
        {


            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = hr.GetUserAddRequestList(SearchValue, ddl.ParamField, BranchId, DepartementCode, DatePickerReady, JobType, status, process, page, pageSize);
            var result = (List<spAddUserRequestList_Result>)obj[0];
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
        public JsonResult GetDeleteUserRequest(string SearchValue, GetMenuResult ddl, string DatePickerReady, int? BranchId, string DepartementCode, string status, string process, int? page, int rows, string sidx, string sord)
        {


            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = hr.GetDeleteUserRequestList(SearchValue, ddl.ParamField, BranchId, DepartementCode, DatePickerReady, status, process, page, pageSize);
            var result = (List<spHRDeleteUserRequestList_Result>)obj[0];
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
        public JsonResult GetHRCurrentJobEmployee(string SearchValue, GetMenuResult ddl, int? page, int? rows, string sidx, string sord)
        {

            int pageIndex = Convert.ToInt32(page) - 1;
            int? pageSize = rows;
            List<Object> obj = hr.GetHrCurrentJobEmployee(SearchValue, ddl.ParamField, page, pageSize);
            var result = (List<spGetHRCurrentJobEmployee>)obj[0];
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
        public ActionResult EditAccessUserIDRequest(string updateID, string value, string JobId)
        {
           TempData["upID"] = updateID;
           TempData["State"] = "Edit";
            return RedirectToAction("NewAccessUserIDRequest", "AccessAndUSerIDRequest", new { state = "Edit", value = value, JobId = JobId });
        }
        public ActionResult CancelAccessUserIDRequest(string updateID, string value, string JobId)
        {
            TempData["upID"] = updateID;
            TempData["State"] = "Cancel";
            return RedirectToAction("NewAccessUserIDRequest", "AccessAndUSerIDRequest", new { state = "Cancel", value = value, JobId = JobId });
        }
        public ActionResult NewAccessUserIDRequest(string value, string JobId, string state)
        {

            ViewBag.menuNIK = new SelectList(pop.getMenu("001", "1").AsEnumerable(), "ParamField", "ParamName");
            if (Session["UpID"] == null)
            {
                if (value == null && JobId == null)
                {
                    return View();
                }
                else
                {
                    List<spHREmployeeView_Result> result = new List<spHREmployeeView_Result>();
                    result = hr.GetEmployeeView(value);
                    ViewBag.menuNIK = new SelectList(pop.getMenu("001", "1").AsEnumerable(), "ParamField", "ParamName");
                    ViewBag.NIK = result[0].NIK;
                    ViewBag.Name = result[0].EmployeeName;
                    ViewBag.Branch = result[0].BranchName;
                    ViewBag.Dept = result[0].DepartementName;
                    ViewBag.post = result[0].PrivilegeName;
                    ViewBag.Job = JobId;
                    return View();
                }

            }
            else
                if (Session["State"].ToString() == "Edit")
                {
                    List<spHREmployeeView_Result> result = new List<spHREmployeeView_Result>();
                    result = hr.GetEmployeeView(value);
                    ViewBag.menuNIK = new SelectList(pop.getMenu("001", "1").AsEnumerable(), "ParamField", "ParamName");
                    ViewBag.NIK = result[0].NIK;
                    ViewBag.Name = result[0].EmployeeName;
                    ViewBag.Branch = result[0].BranchName;
                    ViewBag.Dept = result[0].DepartementName;
                    ViewBag.post = result[0].PrivilegeName;
                    ViewBag.idForm = Session["UpID"].ToString();
                    ViewBag.state = state;
                    ViewBag.Job = JobId;
                    return View();
                }
            if (Session["State"].ToString() == "Cancel")
            {
                List<spHREmployeeView_Result> result = new List<spHREmployeeView_Result>();
                result = hr.GetEmployeeView(value);
                ViewBag.menuNIK = new SelectList(pop.getMenu("001", "1").AsEnumerable(), "ParamField", "ParamName");
                ViewBag.NIK = result[0].NIK;
                ViewBag.Name = result[0].EmployeeName;
                ViewBag.Branch = result[0].BranchName;
                ViewBag.Dept = result[0].DepartementName;
                ViewBag.post = result[0].PrivilegeName;
                ViewBag.idForm = Session["UpID"].ToString();
                ViewBag.state = "Cancel";
                ViewBag.Job = JobId;

                return View();
            }
            return View();


        }
        [HttpPost]
        public ActionResult NewAccessUserIDRequest(string value, string pivchJobId, string pivchReason, string state, string updateID, string pivchCancelReason)
        {
            if (TempData["State"] == null )
            {
                TempData["State"] = "Insert";
            }
            if (TempData["State"]== "Edit")
            {
                hr.updateUserRequest(Session["UpID"].ToString(), pivchJobId, pivchReason);
                return RedirectToAction("AccessUserRequestDetail", "AccessAndUSerIDRequest", new { AccessID = Session["UpID"].ToString() });
            }
            else
                if (TempData["State"].ToString() == "Cancel" && pivchCancelReason != null)
                {
                    hr.cancelUserRequest(null, TempData["UpID"].ToString(), "Cancel", pivchCancelReason);
                }
                else 
                {
                    string AccessID = hr.InsertUserAccessRequest(pivchJobId, pivchReason);

                    return RedirectToAction("AccessUserDetail", "AccessAndUserIDRequest", new { AccessID = AccessID });
                }
            return RedirectToAction("AccessUserRequestDetail", "AccessAndUSerIDRequest", new { AccessID = TempData["UpID"].ToString() });
        }

        public ActionResult AccessUserRequestDetail(string AccessID)
        {
            List<spHRAddUserRequestView_Result> row = new List<spHRAddUserRequestView_Result>();
            row = hr.GetUserRequestView(AccessID);
            ViewData["AccessData"] = row;
            ViewBag.AppCombo = new SelectList(pop.getMsAppCombo().AsEnumerable(), "AppCode", "AppName");
            ViewBag.Loc = new SelectList(pop.getMsLocation().AsEnumerable(), "LocationCode", "LocationName");
            return View();
        }
        public void WorkFlow(string empNIK, string reqID)
        {
            List<spGetUserInfo_Result> userInfo = new List<spGetUserInfo_Result>();
            List<spHREmployeeView_Result> row = new List<spHREmployeeView_Result>();
            List<spHRAddUserRequestView_Result> result = new List<spHRAddUserRequestView_Result>();
            result = hr.GetUserRequestView(reqID);
            row = hr.GetEmployeeView(empNIK);
            CekPriv cekpriv = new CekPriv();
            userInfo = cekpriv.privilege("117201");
            string code = hr.getWFCode(int.Parse(userInfo[0].BranchId.ToString()), userInfo[0].DepartementCode, "ADDREQUSER", row[0].PrivilegeCode);
            string workflowCode = code;
            string description = "";
            description = "";
            description += "Form No : " + result[0].AddRequestId + "<br />";
            description += "Date : " + result[0].AddRequestDate + "<br />";
            description += "NIK : " + result[0].NIK + "<br />";
            description += "Name : " + result[0].EmployeeName + "<br />";
            description += "Branch : " + result[0].BranchName + "<br />";
            description += "Departement : " + result[0].DepartementName + "<br />";
            description += "Position : " + result[0].PrivilegeName + "<br />";
            description += "Reason : " + result[0].Reason + "<br />";
            hr.addWorkFlow(code, result[0].BranchId, "AddRequestId", reqID, "REQUESTED", description, Session["UserId"].ToString(), int.Parse(Session["BranchId"].ToString()), null, null);
        }

        public JsonResult GetHRAccessRole(string RequestID)
        {
            List<spHRAddUserRequestDetailList_Result> row = hr.GetUserAppRole(RequestID);
            var result = row;

            var jsonData = new
            {
                rows = result
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public void saveAccessRole(string pivchAddRequestID, string pivchAppcode, string pivchLocationCode, int? piintAutoDBId)
        {
            if (pivchAppcode != "00007")
            {
                pivchLocationCode = null;
            }
            hr.AddUserRequestAccessID(pivchAddRequestID, pivchAppcode, pivchLocationCode, piintAutoDBId, Session["UserId"].ToString());
            RedirectToAction("AccessUserRequestDetail", "AccessAndUserIDRequest", new { AccessID = pivchAddRequestID });
        }
        public JsonResult GetWFPath(string RequestID)
        {
            List<MsWorkFlowShowPath_Result> row = hr.showWorkFlowPath(RequestID);
            var result = row;

            var jsonData = new
            {
                rows = result
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetWFHistory(string RequestID)
        {
            List<MsWorkFlowHistoryGet_Result> row = hr.GetHistoryWF(RequestID);
            var result = row;

            var jsonData = new
            {
                rows = result
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteUserRequest(string id)
        {
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {

                List<spGetUserInfo_Result> userInfo = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                userInfo = cekpriv.privilege(id);
                ViewData["Privilege"] = userInfo;
                populatedDdl();
                ViewBag.menuId = id;
                ViewBag.menu = new SelectList(pop.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
                return View();

            }
            return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        public ActionResult NewDeleteUserRequest(string value, string JobId, string state,string Reason)
        {

            ViewBag.menuNIK = new SelectList(pop.getMenu("001", "1").AsEnumerable(), "ParamField", "ParamName");
            ViewBag.DelReason = new SelectList(pop.getReasonDelete().AsEnumerable());
            if (Session["UpID"] == null)
            {
                if (value == null && JobId == null)
                {
                    return View();
                }
                else
                {
                    List<spHREmployeeView_Result> result = new List<spHREmployeeView_Result>();
                    result = hr.GetEmployeeView(value);
                    ViewBag.menuNIK = new SelectList(pop.getMenu("001", "1").AsEnumerable(), "ParamField", "ParamName");
                    ViewBag.NIK = result[0].NIK;
                    ViewBag.Name = result[0].EmployeeName;
                    ViewBag.Branch = result[0].BranchName;
                    ViewBag.Dept = result[0].DepartementName;
                    ViewBag.post = result[0].PrivilegeName;
                    ViewBag.Job = JobId;
                    ViewBag.Reason = Reason;
                    return View();
                }

            }
            else
                if (TempData["State"].ToString() == "Edit")
                {
                    List<spHREmployeeView_Result> result = new List<spHREmployeeView_Result>();
                    result = hr.GetEmployeeView(value);
                    ViewBag.menuNIK = new SelectList(pop.getMenu("001", "1").AsEnumerable(), "ParamField", "ParamName");
                    ViewBag.NIK = result[0].NIK;
                    ViewBag.Name = result[0].EmployeeName;
                    ViewBag.Branch = result[0].BranchName;
                    ViewBag.Dept = result[0].DepartementName;
                    ViewBag.post = result[0].PrivilegeName;
                    ViewBag.idForm = Session["UpID"].ToString();
                    ViewBag.Reason = Reason;
                    ViewBag.state = state;
                    ViewBag.Job = JobId;
                    return View();
                }
            return View();
        }
        [HttpPost]
        public ActionResult NewDeleteUserRequest(string value, string pivchJobId, string pivchReason, string state, string updateID, string pivchCancelReason,string pivchReasonDesc,DateTime? pidtmResignDate,DateTime? pidtmResignEffectiveDate)
        {
            if (TempData["State"] == null)
            {
                TempData["State"] = "Insert";
            }
            int? ReasonCode = null;
            if (pivchReason == "Resign")
	        {
		        ReasonCode = 0;
	        }else
            if (pivchReason == "Mutation")
	        {
		        ReasonCode = 1;
	        }else
              if (pivchReason == "Rotation")
	        {
		        ReasonCode = 2;
	        }else
             if (pivchReason == "Back From Dual Job")
	        {
		        ReasonCode = 3;
	        }else
                 if (pivchReason == "Demotion")
	        {
		        ReasonCode = 4;
	        }else
                     if (pivchReason == "Cancel Join")
	        {
		        ReasonCode = 5;
	        }else
                         if (pivchReason == "Other")
	        {
		        ReasonCode = 6;
	        }
        
            if(TempData["State"].ToString() == "Edit")
            {
                hr.UpdateDeleteRequestUser(TempData["UpID"].ToString(), pivchJobId, ReasonCode, pivchReason, pidtmResignDate, pidtmResignEffectiveDate);
                return RedirectToAction("DeleteUserRequestDetail", "AccessAndUSerIDRequest", new { AccessID = TempData["UpID"].ToString() });
            }
            else
                if (TempData["State"].ToString() == "Cancel" && pivchCancelReason != null)
                {
                    hr.cancelUserRequest(null, TempData["UpID"].ToString(), "Cancel", pivchCancelReason);
                }
                else
                {
                    string AccessID = hr.HrDeleteUserRequestInsert(DateTime.Now, pivchJobId, ReasonCode, pivchReasonDesc, pidtmResignDate, pidtmResignEffectiveDate);

                    return RedirectToAction("AccessUserDetail", "AccessAndUserIDRequest", new { AccessID = AccessID });
                }
            return RedirectToAction("AccessUserRequestDetail", "AccessAndUSerIDRequest", new { AccessID = Session["UpID"].ToString() });
        }
        public JsonResult GetHRDeleteCurrentJobEmployee(string SearchValue,string pivchReason, GetMenuResult ddl, int? page, int? rows, string sidx, string sord)
        {
            string whereby = null;

            if (pivchReason == "Mutation" || pivchReason == "Rotation" || pivchReason == "Demotion")
            {
                whereby = "a.JobStatus = 0  AND b.IsResign = 0 AND a.IsDelete = 0 ";
            }
            else
                if (pivchReason == "Back From Dual Job" )
                {
                  whereby =  "a.JobStatus = 1 AND b.IsResign = 0 AND a.JobTypeId = 2";
                }
                else
                    {
                        whereby = "a.JobStatus = 1  AND b.IsResign = 0 ";
                    }

            int pageIndex = Convert.ToInt32(page) - 1;
            int? pageSize = rows;
            List<Object> obj = hr.GetHrDeleteCurrentJobEmployee(SearchValue,ddl.ParamField,whereby, page, pageSize);
            var result = (List<spGetHRCurrentJobEmployee>)obj[0];
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
        public ActionResult DeleteUserRequestDetail(string AccessID)
        {
            List<spHRDeleteUserRequestView_Result> row = new List<spHRDeleteUserRequestView_Result>();
            row = hr.GetHRDeleteRequestInfo(AccessID);
            ViewData["AccessData"] = row;
            ViewBag.AppCombo = new SelectList(pop.getMsAppCombo().AsEnumerable(), "AppCode", "AppName");
            ViewBag.Loc = new SelectList(pop.getMsLocation().AsEnumerable(), "LocationCode", "LocationName");
            return View();
        
        }
        public ActionResult EditDeleteUserIDRequest(string state,string updateID,string value,string JobId,string Reason)
        {
           TempData["upID"] = updateID;
           TempData["State"] = "Edit";
           return RedirectToAction("NewDeleteUserRequest", "AccessAndUSerIDRequest", new { state = "Edit", value = value, JobId = JobId,Reason = Reason });
        }
        public void WorkFlowDel(string empNIK, string reqID)
        {
            List<spGetUserInfo_Result> userInfo = new List<spGetUserInfo_Result>();
            List<spHREmployeeView_Result> row = new List<spHREmployeeView_Result>();
            List<spHRDeleteUserRequestView_Result> result = new List<spHRDeleteUserRequestView_Result>();
            result = hr.GetHRDeleteRequestInfo(reqID);
            row = hr.GetEmployeeView(empNIK);
            CekPriv cekpriv = new CekPriv();
            userInfo = cekpriv.privilege("117201");
            string code = "DELREQHRD";
            string workflowCode = code;
            string description = "";
            description = "";
            description += "Form No : " + result[0].DeleteRequestId + "<br />";
            description += "Date : " + result[0].DeleteRequestDate + "<br />";
            description += "NIK : " + result[0].NIK + "<br />";
            description += "Name : " + result[0].EmployeeName + "<br />";
            description += "Branch : " + result[0].BranchName + "<br />";
            description += "Departement : " + result[0].DepartementName + "<br />";
            description += "Position : " + result[0].PrivilegeName + "<br />";
            description += "Reason : " + result[0].ReasonText + "<br />";
            hr.addWorkFlow(code, result[0].BranchId, "DeleteRequestId", reqID, "REQUESTED", description, Session["UserId"].ToString(), int.Parse(Session["BranchId"].ToString()), null, null);
        }
    }
}