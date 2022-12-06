using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using System.Web.UI;
using System.Web;

namespace USOFT.DataAccess.HR
{
   
    public class HRModel
    {
        Usoft.Common.CommonFunction.CommonFunction cf = new Usoft.Common.CommonFunction.CommonFunction();
        USOFTEntities db = new USOFTEntities();
        public List<Object> getEmployeeList(string SearchValue,string searchBy, int? branch, string departement, string position, bool status,int? page, int pageSize)
        {
            string WhereBy = cf.SearchText(searchBy, SearchValue);
            if (branch > 0)
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " a.BranchId = '" + branch + "'";
            }

            if (departement != "")
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " a.DepartementCode = '" + departement + "'";
            }

            if (position != "")
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " a.PrivilegeCode = '" + position + "'";
            }

            if (status != null)
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " a.IsResign = '" + status + "'";
            }
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));

            List<spHREmployeeList_Result> rows = db.spHREmployeeList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(rows);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;

        }
        public List<Object> GetHrCurrentJobEmployee(string SearchValue,string searchBy,int? page,int? pageSize)
        {
            string WhereBy = cf.SearchText(searchBy, SearchValue);
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));

            List<spGetHRCurrentJobEmployee> rows = db.spGetHRCurrentJobEmployee(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(rows);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;

        }
        public List<Object> GetDeleteUserRequestList(string SearchValue, string searchBy,int? branch,string departement,string RequestDate,string status,string process,int?page,int pageSize)
        {
            string WhereBy = cf.SearchText(searchBy, SearchValue);
            if (RequestDate != "")
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + "CONVERT(VARCHAR(8),a.AddRequestDate,112) = CONVERT(VARCHAR(8),CONVERT(DATETIME,'" + RequestDate + "'),112)";

            }
            if (branch > 0)
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " b.BranchId = " + branch;
            }
            if (departement != "")
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " b.DepartementCode = " + departement;
            }
            if (status != "")
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " a.Status = '" + status + "'";
            }
            if (process != "")
            {
                WhereBy += (process == "null") ? cf.SqlAndOr(WhereBy, true) + "a.ProcessStatus IS NULL" : cf.SqlAndOr(WhereBy, true) + "a.ProcessStatus = '" + process + "'";
            }
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spHRDeleteUserRequestList_Result> rows = db.spHRDeleteUserRequestList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(rows);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }
        public List<Object> GetPrivilegeList(string SearchValue, string searchBy, int? branch, string departement, int? page, int pageSize)
        {
            string WhereBy = cf.SearchText(searchBy, SearchValue);
            if (branch > 0)
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " a.BranchId = '" + branch + "'";
            }

            if (departement != "")
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " a.DepartementCode = '" + departement + "'";
            }

          
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));

            List<spHRPrivilegeList_Result> rows = db.spHRPrivilegeList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(rows);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;

        }
        public List<Object> GetPendingEmployeeList(string SearchValue, string searchBy, int? branch,int? page, int pageSize)
        {
            string WhereBy = cf.SearchText(searchBy, SearchValue);
            if (branch > 0)
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " a.BranchId = '" + branch + "'";
            }


            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));

            List<spHRPendingEmployeeRegistList_Result> rows = db.spHRPendingEmployeeRegisterList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(rows);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;

        }
        public void HREmployeeInsert(string pivchNIK,string pivchEmployeeName)
        {
            db.spHREmployeeInsert(pivchNIK, pivchEmployeeName, HttpContext.Current.Session["UserId"].ToString());
        }
        public List<spHREmployeeView_Result> GetEmployeeView(string pivchNIK)
        {
            List<spHREmployeeView_Result> result = new List<spHREmployeeView_Result>();
            result = db.spHREmployeeView(pivchNIK).ToList();
            return result;
        }
        public List<spHREmployeeDetailList_Result> getJobHistory(string pivchNIK)
        {
            List<spHREmployeeDetailList_Result> row = new List<spHREmployeeDetailList_Result>();
            row = db.spHREmployeeDetailList(pivchNIK).ToList();
            return row;
        }
        public List<HRAccountNumberGet_Result> getAccount(string pivchNIK)
        {
            List<HRAccountNumberGet_Result> row = new List<HRAccountNumberGet_Result>();
            row = db.HRAccountNumberGet(pivchNIK).ToList();
            return row;
        }
        public string insertHRJobDetail(string pivchNIK,int? piintJobType,int? piintBranchId,string pivchDepartementCode,string privilegeCode,DateTime? pidtmEffectiveDateFrom,DateTime? pidtmEffectiveDateTo,int? piintBranchIdFrom,string pivchDepartementCodeFrom,string pivchPrivilegeCodeFrom)
        {
            ObjectParameter EmployeeJobId = new ObjectParameter("povchJobEmployeeId", typeof(string));
            db.spHREmployeeDetailInsert(EmployeeJobId, pivchNIK, piintJobType, piintBranchId, pivchDepartementCode, privilegeCode, pidtmEffectiveDateFrom, pidtmEffectiveDateTo, piintBranchIdFrom, pivchDepartementCodeFrom, pivchPrivilegeCodeFrom, HttpContext.Current.Session["UserId"].ToString());
            string employejobid = (string)EmployeeJobId.Value;
            return employejobid;
        }
        public List<spHREmployeeDetailView_Result> getEmployeeJobDetail(string pivchEmployeeJobId)
        {
            List<spHREmployeeDetailView_Result> result = new List<spHREmployeeDetailView_Result>();
            result = db.spHREmployeeDetailView(pivchEmployeeJobId).ToList();
            return result;
        }
        public ObjectResult<int?> GetBranchType(int branchId)
        {
            ObjectResult<int?> branchTipeId;
            branchTipeId = db.spGetBranchTipe(branchId);
            return branchTipeId;
        }
        public ObjectResult<string> GetWorkFlowCode(int branchId,string deptCode,string workFlowType,string privilege)
        {
            ObjectResult<string> WFCode;
            WFCode = db.MsWorkFlowSourceGetWFCode(branchId, deptCode, workFlowType, privilege);
            return WFCode;
        }
        public void insertWorkFlow(string workflowcode,int? workflowbranchCode,string workflowtablekey,string workflowtablevalue,string workflowapprovalstatus,string workflowdescription,string workflowcreatedby,int? workflowcreatedbranch,string workflowupdateby,DateTime? workflowupdatedate)
        {
            db.MsWorkFlowInsert(workflowcode, workflowbranchCode, workflowtablekey, workflowtablevalue, workflowapprovalstatus, workflowdescription, workflowcreatedby, workflowcreatedbranch, workflowupdateby, workflowupdatedate);
        }
        public void insertEmpAccount(string nik,string bankfincode,string bankname,string accountnumber,string accountname,bool? isactive,string approvalstatus)
        {
            db.HRAccountNumberSet(nik, bankfincode, bankname, accountnumber, accountname, isactive, approvalstatus, HttpContext.Current.Session["UserId"].ToString());
        }
        public List<HRAccountNumberGet_Result> getAccountInfo (string nik)
        {
            List<HRAccountNumberGet_Result> row = new List<HRAccountNumberGet_Result>();
            row = db.HRAccountNumberGet(nik).ToList();
            return row;
        }
        public void addHrPrivilege(string pivchPrivilegeCode, string pivchPrivilegeName, int piintBranchId, string pivchDepartementCode, string pivchOrgId)
        {
            db.spHRPrivilegeInsert(pivchPrivilegeCode, pivchPrivilegeName, piintBranchId, pivchDepartementCode, pivchOrgId, HttpContext.Current.Session["UserId"].ToString());
        }
        public string addHRAddRequestUserInsert(DateTime pidtmAddRequestDate,string pivchJobEmployeeId ,string pivchReason)
        {
            ObjectParameter povchRequestID = new ObjectParameter("povchAddRequestID", typeof(string));
            db.spHRAddUserRequestInsert(povchRequestID, pidtmAddRequestDate, pivchJobEmployeeId, pivchReason,HttpContext.Current.Session["UserId"].ToString());
            string povchrequestID = (String)povchRequestID.Value;
            return povchrequestID;
        }
        public List<spHRAddUserRequestView_Result> GetUserRequestDetailView(string AccessID)
        {
            List<spHRAddUserRequestView_Result> view = new List<spHRAddUserRequestView_Result>();
            view = db.spHRAddUserRequestView(AccessID).ToList();
            return view;
        }
        public List<spHRAddUserRequestDetailList_Result> GetUserAccessRole(string AccessID)
        {
            List<spHRAddUserRequestDetailList_Result> result = new List<spHRAddUserRequestDetailList_Result>();
            result = db.spHRAddUserRequestDetailList(AccessID).ToList();
            return result;
        }
        public void addUserRequestAccessID(string pivchAddRequestID,string pivchAppcode,string pivchLocationCode,int? piintAutoDBId,string pivchInputID)
        {
            db.spHRAddUserRequestDetailInsert(pivchAddRequestID, pivchAppcode, pivchLocationCode, piintAutoDBId, pivchInputID);
        }
        public List<MsWorkFlowShowPath_Result> path(string RequestID)
        {
            List<MsWorkFlowShowPath_Result> result = new List<MsWorkFlowShowPath_Result>();
            result = db.MsWorkFlowShowPath(RequestID).ToList();
            return result;   
        }
        public List<MsWorkFlowHistoryGet_Result> WFHistory(string RequestID)
        {
            List<MsWorkFlowHistoryGet_Result> result = new List<MsWorkFlowHistoryGet_Result>();
            result = db.MsWorkFlowHistoryGet(RequestID).ToList();
            return result;
        }
        public void updateRequestDetail(string pivchAddRequestID, string pivchJobEmployeeId, string pivchReason)
        {
            db.spHRAddUserRequestUpdate(pivchAddRequestID, DateTime.Now, pivchJobEmployeeId, pivchReason, HttpContext.Current.Session["UserId"].ToString());
        }
        public void cancelRequest(string pivchFormState, string pivchAddRequestID, string pivchProcessStatus,string pivchCancelReason)
        {
            db.spHRAddUserRequestUpdateProcessStatus(pivchFormState, pivchAddRequestID, pivchProcessStatus, pivchCancelReason, HttpContext.Current.Session["UserId"].ToString());
        }
        public List<Object> GetUserRequestList(string SearchValue, string searchBy, int? branch, string departement, string RequestDate, string jobType, string status, string process, int? page, int pageSize)
        {
            string WhereBy = cf.SearchText(searchBy, SearchValue);
            if (RequestDate != "")
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + "CONVERT(VARCHAR(8),a.AddRequestDate,112) = CONVERT(VARCHAR(8),CONVERT(DATETIME,'" + RequestDate + "'),112)";

            }
            if (branch > 0)
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " b.BranchId = " + branch;
            }
            if (departement != "")
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " b.DepartementCode = " + departement;
            }
            if (jobType != "")
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " b.JobTypeId = " + jobType;
            }
            if (status != "")
            {
                WhereBy += cf.SqlAndOr(WhereBy, true) + " a.Status = '" + status + "'";
            }
            if (process != "")
            {
                WhereBy += (process == "null") ? cf.SqlAndOr(WhereBy, true) + "a.ProcessStatus IS NULL" : cf.SqlAndOr(WhereBy, true) + "a.ProcessStatus = '" + process + "'";
            }
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spAddUserRequestList_Result> rows = db.spHRAddUserRequestList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(rows);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }
        public string addHRDeleteRequestUserInsert(DateTime pidtmDeleteRequestDate, string pivchJobEmployeeId, int? piintReasonDelete, string pivchReasonDesc, DateTime? pidtmResignDate, DateTime? pidtmResignEffectiveDate)
        {
            ObjectParameter povchRequestID = new ObjectParameter("povchDeleteRequestID", typeof(string));
            db.spHRDeleteUserRequestInsert(povchRequestID, pidtmDeleteRequestDate, pivchJobEmployeeId, piintReasonDelete, pivchReasonDesc, pidtmResignDate, pidtmResignEffectiveDate, HttpContext.Current.Session["UserId"].ToString());
            string povchrequestID = (String)povchRequestID.Value;
            return povchrequestID;
        }
        public List<Object> GetHrDeleteCurrentJobEmployee(string SearchValue,string searchBy,string Whereby, int? page, int? pageSize)
        {
            string search;
            string Where = cf.SearchText(searchBy, SearchValue);
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            search = Whereby + (((Whereby != "") && (Where != "")) ? cf.SqlAndOr(Where, true) + " " : "") + Where;
            List<spGetHRCurrentJobEmployee> rows = db.spGetHRCurrentJobEmployee(search, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(rows);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;

        }
        public List<spHRDeleteUserRequestView_Result> GetDeleteRequestInfo(string No)
        {
            List<spHRDeleteUserRequestView_Result> result = new List<spHRDeleteUserRequestView_Result>();
            result = db.spHRDeleteUserRequestView(No).ToList();
            return result;
        }
        public void UpdateDeleteRequestUser(string pivchDeleteRequestID,string pivchJobEmployeeId,int? piintReasonDelete,string pivchReasonDesc,DateTime? pidtmResignDate,DateTime? pidtmResignEffectiveDate)
        {
            db.spHRDeleteUserRequestUpdate(pivchDeleteRequestID, DateTime.Now, pivchJobEmployeeId, piintReasonDelete, pivchReasonDesc, pidtmResignDate, pidtmResignEffectiveDate, HttpContext.Current.Session["UserId"].ToString());
        }

    }
}
