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
using USOFT.Controllers;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Data.Common;



namespace USOFT.Areas.HR.Controllers
{
    public class MasterController : BaseController
    {   
        PopulatedDdl pop = new PopulatedDdl();
        HRMainModel hr = new HRMainModel();
        BranchModel brm = new BranchModel();
        DeptMeodel dptm = new DeptMeodel();

        //
        // GET: /HR/Master/
        public ActionResult Index()
        {
            return View();
        }
        public void populatedDdl(string id)
        {
            ViewBag.menuEmployee = new SelectList(pop.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
            ViewBag.br = new SelectList(pop.brCombo().AsEnumerable(), "BranchId", "BranchName");
            ViewBag.dpt = new SelectList(pop.deptCombo().AsEnumerable(), "DepartementCode", "DepartementName");
            ViewBag.pos = new SelectList(pop.populatedPrivilege().AsEnumerable(), "PrivilegeCode", "PrivilegeName");
            ViewBag.stat = new SelectList(pop.hrStatus()).AsEnumerable();
            ViewBag.HrJob = new SelectList(pop.hrJobType().AsEnumerable(), "JobTypeId", "JobTypeName");
        }
        public ActionResult Employee(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
                populatedDdl(id);
                return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        public JsonResult GetEmployeeList(string SearchValue, GetMenuResult ddl, int? piintBranchId, string pivchDepartementCode, string pivchPositionCode, string pivchStatus, int? page, int rows, string sidx, string sord)
        {
            bool resignStatus = false;
            if (pivchStatus == "Active")
            {
                resignStatus = false;
            }
            else
                if (pivchStatus == "Resign")
                {
                     resignStatus = true;
                }

            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = hr.GetHREmployeeList(SearchValue, ddl.ParamField, piintBranchId, pivchDepartementCode, pivchPositionCode, resignStatus, page, pageSize);
            var result = (List<spHREmployeeList_Result>)obj[0];
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

        public ActionResult Position(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
                populatedDdl(id);
                return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        public JsonResult GetPrivilegeList(string SearchValue, GetMenuResult ddl, int? piintBranchId, string pivchDepartementCode, int? page, int rows, string sidx, string sord)
        {
           

            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = hr.GetHRPrivilegeList(SearchValue, ddl.ParamField, piintBranchId, pivchDepartementCode, page, pageSize);
            var result = (List<spHRPrivilegeList_Result>)obj[0];
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
        public JsonResult GetHRPendingEmployee(string SearchValue, GetMenuResult ddl, int? piintBranchId, int? page, int rows, string sidx, string sord)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = hr.GetHRPendingEmployeeList(SearchValue, ddl.ParamField, piintBranchId, page, pageSize);
            var result = (List<spHRPendingEmployeeRegistList_Result>)obj[0];
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
        public JsonResult GetJobHistory(string NIK, int? piintBranchId, int? page, int rows, string sidx, string sord)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var result = hr.getJobHistory(NIK);
            var jsonData = new
            {
                page,
                
                rows = result
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAccountNumber(string NIK, int? piintBranchId, int? page, int rows, string sidx, string sord)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var result = hr.getAccountNumber(NIK);
            var jsonData = new
            {
                page,

                rows = result
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PendingEmployee(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
                populatedDdl(id);
                return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        public ActionResult AddHREmployee(string id)
        {
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege(id);

                if (result[0].CanInsert == true)
                {
                    ViewBag.menuId = id;
                    return View();
                }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
            return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult AddHREmployee(string pivchNIK,string pivchEmployeeName,string IdMenu)
        {
            hr.HREmployeeInsert(pivchNIK, pivchEmployeeName);
            return RedirectToAction("EmployeeDetail", "Master", new { value = pivchNIK ,id = IdMenu});
        }
        public ActionResult EmployeeDetail(string value)
        {
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege("117901");

                if (result[0].CanInsert == true)
                {
                    List<spHREmployeeView_Result> row = hr.GetEmployeeView(value);
                    ViewBag.NIK = row[0].NIK;
                    ViewBag.Name = row[0].EmployeeName;
                    ViewBag.branch = row[0].BranchName;
                    ViewBag.dpt = row[0].DepartementName;
                    ViewBag.stat = row[0].IsActive;
                    ViewBag.menuId = "117901";
                    
                    //using (var ctx = new USOFTEntities())
                    //{
                        var idParam = new SqlParameter{
                            ParameterName = "pivchLookupId",
                            Value = "001"
                        };
                        var sp = "spGetLookupInfo";

                        using (var ctx = new USOFTEntities())
                        {
                            using (var cmd = ctx.Database.Connection.CreateCommand())
                            {
                                ctx.Database.Connection.Open();
                                cmd.CommandText = "EXEC " + sp + " 001";
                                using (var reader = cmd.ExecuteReader())
                                {
                                    var model = Read(reader).ToList();

                                }
                            }
                        }
                        
                        //var courselist = ctx.Database.SqlQuery<spGetLookupInfo_Result>("exec " + sp + " @pivchLookupId", idParam);
                        //var Key = courselist.FirstOrDefault();
                    
                    return View();
                }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
            return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        public ActionResult AddJobDetail(string value,string id,string command)
        {
           
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege(id);

                if (result[0].CanInsert == true)
                {
                    List<spHREmployeeView_Result> row = hr.GetEmployeeView(value);
                    ViewBag.NIK = row[0].NIK;
                    ViewBag.Name = row[0].EmployeeName;
                    ViewBag.menuId = id;
                    ViewBag.from = row[0].BranchName + "-" + row[0].DepartementName + "-" + row[0].PrivilegeName;
                    populatedDdl(id);
                    return View();
                }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
            return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult AddJobDetail(string menuId,string NIK, string EmpName,string pivchPriority, int JobTypeId, string pivchfrom, int BranchId, string departementCode, DateTime pivchStartDate, DateTime pivchEndDate)
        {
             if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege(menuId);

                if (result[0].CanInsert == true)
                {
                    int? pivchBranchIdFrom = null;
                    string pivchDepartementFrom = null;
                    string pivchPrivilegeCodeFrom = null;
                    string povchNo;
                    if (pivchfrom != null)
                    {
                        List<spHREmployeeView_Result> row = hr.GetEmployeeView(NIK);
                        pivchBranchIdFrom = row[0].BranchId;
                        pivchDepartementFrom = row[0].DepartementCode;
                       pivchPrivilegeCodeFrom = row[0].PrivilegeCode;
                    }
                    povchNo = hr.insertHRJobDetail(NIK, JobTypeId, BranchId, departementCode, pivchPriority, pivchStartDate, pivchEndDate, pivchBranchIdFrom, pivchDepartementFrom, pivchPrivilegeCodeFrom);
                    return RedirectToAction("EmployeeJobDetailDraft", "Master", new { id = menuId, value = povchNo });
                }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
             return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        public ActionResult PopulateDdl(int id,string value)
        {
            if (value != null)
            {
                ViewBag.result = new SelectList(pop.privDept(id.ToString(), value).AsEnumerable(), "PrivilegeCode", "PrivilegeName");
            }
            else
            {
                ViewBag.result = new SelectList(pop.privCombo(id.ToString()).AsEnumerable(), "PrivilegeCode","PrivilegeName");
            }
            
            return PartialView("_PartialDdlPrivilegeBranch", ViewBag.result);
        }
        public ActionResult EmployeeJobDetailDraft(string value,string id ,string name,string WorkFlowId,string canApproved,string WorkFlowType)
        {
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spHREmployeeDetailView_Result> row = new List<spHREmployeeDetailView_Result>();
                row = hr.GetEmployeeJobDetail(value);
                if (name != null)
                {
                    ViewBag.canApproved = canApproved;
                    ViewBag.WorkFlowId = WorkFlowId;
                    ViewBag.WorkFlowType = WorkFlowType;
                }
                ViewBag.value = value;
                ViewBag.NIK = row[0].NIK;
                ViewBag.Name = row[0].EmployeeName;
                ViewBag.jobtype = row[0].JobTypeName;
                ViewBag.branch = row[0].BranchName;
                ViewBag.departement = row[0].DepartementName;
                ViewBag.position = row[0].PrivilegeName;
                ViewBag.Date = row[0].EffectiveDateFrom.ToShortDateString() + " To " + row[0].EffectiveDateTo.Value.ToShortDateString();
                ViewBag.jobstatus = row[0].JobStatus;
                ViewBag.approval = row[0].ApprovalStatus;
                return View();
            }
            return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult EmployeeJobDetailDraft(string command,string JobId,string id)
        {
            if (command == "Request Approval")
            {
                return RedirectToAction("addWorkFlow", "Master", new {value = JobId,id = id });
            }
            else
                if (command == "Edit")
                {
                    return RedirectToAction("editEmployeeJobDetail", "Master", new {id = id });
                }

            return RedirectToAction("EmployeeJobDetailDraft", "Master", new { id = id });

        }
        public ActionResult addWorkFlow(string id,string value)
        {
            List<spHREmployeeDetailView_Result> row = new List<spHREmployeeDetailView_Result>();
            row = hr.GetEmployeeJobDetail(value);
            int? branchTipe = hr.getBranchType(row[0].BranchId);
            string departmentCode = row[0].DepartementCode != "" ? row[0].BranchId == 8675 ? row[0].DepartementCode : (branchTipe == 1 ? "99" : "98") : (branchTipe == 1 ? "99" : "98");
            string code = hr.getWFCode(row[0].BranchId, departmentCode, "HRJOBREGIS", row[0].PrivilegeCode);
            
            string description = "";
            description = "";
            description += "Job Register,<BR /><BR />";
            description += "NIK             : " + row[0].NIK + "<BR />";
            description += "Name            : " + row[0].EmployeeName + "<BR />";
            description += "Job type        : " + row[0].JobTypeName + "<BR />";
            description += "Branch          : " + row[0].BranchName + "<BR />";
            description += "Departement     : " + row[0].DepartementName + "<BR />";
            description += "Position        : " + row[0].PrivilegeName + "<BR />";
            description += "Start/End date  : " + row[0].EffectiveDateFrom + " To " + row[0].EffectiveDateTo + "<BR /><BR /><BR />";

            hr.addWorkFlow(code,row[0].BranchId,"JobEmployeeId",row[0].JobEmployeeId,"REQUESTED",description,Session["UserId"].ToString(),int.Parse(Session["BranchId"].ToString()),null,null);
            return RedirectToAction("EmployeeJobDetailDraft", "Master", new { id = id, value = value });

        }
        public ActionResult AddAccount(string nik,string id)
        {
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spHREmployeeView_Result> row = hr.GetEmployeeView(nik);
                ViewBag.NIK = nik;
                ViewBag.EmpName = row[0].EmployeeName;
                ViewBag.FinBank = new SelectList(pop.populatedFinBank().AsEnumerable());
                return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult AddAccount(string id,string pivchnik,string pivchFinBank,string pivchBankName,string pivchAccountNo,string pivchAccountName)
        {
            hr.addBankAccount(pivchnik, pivchFinBank, pivchBankName, pivchAccountNo, pivchAccountName, true, "REQUESTED");
            return RedirectToAction("AddAccountToWorkFlow", "Master", new {id = id,value = pivchnik });
        }
        public ActionResult AddPosition(string Id)
        {
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                populatedDdl(Id);
                return View();
            }
            else
            return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult AddPosition(string pivchPositionCode,string pivchPositionName,int piintBranchId,string pivchDepartementCode,string pivchOrgId )
        {
            hr.addHrPrivilege(pivchPositionCode, pivchPositionName, piintBranchId, pivchDepartementCode, pivchOrgId);
            return RedirectToAction("Position","Master",new{id = "117903" });
        }
        public ActionResult AddAccountToWorkFlow(string id,string value)
        {
            List<HRAccountNumberGet_Result> row = new List<HRAccountNumberGet_Result>();
            row = hr.getAccountInfo(value);
            int WorkFlowBranchCode = 8672;
            string  DepartementCode = "10";

            string description = "";
            description = "";
            description += "NIK             : " + row[0].NIK + "<br />";
            description += "Name            : " + row[0].AccountName + "<br />";
            description += "Bank Type       : " + row[0].BankFinCode + "<br />";
            description += "Bank Name       : " + row[0].BankName + "<br />";
            description += "Account No      : " + row[0].AccountNumber + "<br />";
            description += "Account Name      : " + row[0].AccountName + "<br />";

            string WorkFlowCode = "HRADDACC";
            string WorkFlowTableKey = "ID";
            string WorkFlowTableValue = Convert.ToString(row[0].ID);
            string WorkFlowApprovalStatus = "REQUESTED";
            string WorkFlowDescription = description;
            string WorkFlowCreatedBy = Session["UserId"].ToString();
            int? WorkFlowCreatedBranch = int.Parse(Session["BranchId"].ToString());
            hr.addWorkFlow(WorkFlowCode, WorkFlowBranchCode, WorkFlowTableKey, WorkFlowTableValue, WorkFlowApprovalStatus, description, WorkFlowCreatedBy, WorkFlowCreatedBranch, null, null);
            return RedirectToAction("EmployeeDetail", "Master", new { id = id, value = value });
        }
        private static IEnumerable<object[]> Read(DbDataReader reader)
        {
            while (reader.Read())
            {
                var values = new List<object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    values.Add(reader.GetValue(i));
                }
                yield return values.ToArray();
            }
        }
	}
}