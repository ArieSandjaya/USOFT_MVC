using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USOFT.DataAccess;
using USOFT.DataAccess.WorkFlow;
using USOFT.DataAccess.HR;

namespace USOFT.Controllers
{
    public class WorkFlowController : Controller
    {
        WorkFlowModels wf = new WorkFlowModels();
        //
        // GET: /WorkFlow/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WorkFlowGroup()
        {
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<msWorkFlowGroup_Result> result = new List<msWorkFlowGroup_Result>();
                result = wf.WFGroup(int.Parse(Session["BranchId"].ToString()), Session["PrivilegeCode"].ToString(), Session["UserId"].ToString());
                ViewData["WFGroup"] = result;
                return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        public ActionResult WorkFlow(string value)
        {
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<MsWorkFlowSearch_Result> result = new List<MsWorkFlowSearch_Result>();
                result = wf.WFSearch(int.Parse(Session["BranchId"].ToString()), Session["PrivilegeCode"].ToString(), Session["UserId"].ToString(),value);
                ViewData["WFSearch"] = result;
                ViewBag.value = value;
                return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        public ActionResult WorkFlowCommand(string WorkFlowId, string WorkFlowType, string value, string name, string jobId, string workflowremark)
         {
            if (name == "Approve")
            {
                wf.workFlowUpdated(int.Parse(WorkFlowId), "APPROVED", Session["UserId"].ToString(),null);
                return RedirectToAction("WorkFlow", "WorkFlow", new { value = WorkFlowType });
            }
            else
                if (name == "View")
                {
                    string canApproved = "yes";
                    return RedirectToAction("Master/EmployeeJobDetailDraft", "HR", new { WorkFlowType = WorkFlowType, value = value,name = name,WorkFlowId =  WorkFlowId,canApproved = canApproved});
                }
                else
                    if (name == "Reject")
                    {
                        wf.workFlowUpdated(int.Parse(WorkFlowId), "REJCTED", Session["UserId"].ToString(),workflowremark);
                        return RedirectToAction("WorkFlow", "WorkFlow", new { value = WorkFlowType });
                    }
            return View();
        }
        public ActionResult ViewWorkFlow(string id,string value)
        {
            ViewBag.value = value;
            ViewBag.id = id;
            return View();
        }
        public ActionResult OpenPopup()
        {
            
            return View();
        }
        public ActionResult PartialRejectedReason()
        {
            return PartialView("_PartialReason");
        }
        public ActionResult PartialWorkFlowView(string value)
        {
            HRModel hr = new HRModel();
            List<spHREmployeeDetailView_Result> row = new List<spHREmployeeDetailView_Result>();
            row = hr.getEmployeeJobDetail(value);
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

            return PartialView("PartialWorkFlowJobRegis",row);
    
        }
    }
}