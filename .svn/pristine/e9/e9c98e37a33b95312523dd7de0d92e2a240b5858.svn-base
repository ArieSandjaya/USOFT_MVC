using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USOFT.DataAccess.HR;
using USOFT.DataAccess;
using System.Data.Entity.Core.Objects;
namespace USOFT.Models
{
    public class HRMainModel
    {
        HRModel hr = new HRModel();
        public List<Object> GetHREmployeeList(string SearchValue,string searchBy, int? branch, string departement, string position, bool status,int? page, int pageSize)
        {
            return hr.getEmployeeList(SearchValue, searchBy, branch, departement, position, status, page, pageSize);
        }
        public List<Object> GetHRPrivilegeList(string SearchValue, string searchBy, int? branch, string departement, int? page, int pageSize)
        {
            return hr.GetPrivilegeList(SearchValue, searchBy, branch, departement, page, pageSize);
        }
        public List<Object> GetUserAddRequestList(string SearchValue, string searchBy,int? branch,string departement,string RequestDate,string jobType,string status,string process,int?page,int pageSize)
        {
            return hr.GetUserRequestList(SearchValue, searchBy, branch, departement, RequestDate, jobType, status, process, page, pageSize);
        }
        public List<Object> GetDeleteUserRequestList(string SearchValue, string searchBy, int? branch, string departement, string RequestDate, string status, string process, int? page, int pageSize)
        {
            return hr.GetDeleteUserRequestList(SearchValue, searchBy, branch, departement, RequestDate, status, process, page, pageSize);
        }
        public List<Object> GetHRPendingEmployeeList(string SearchValue, string searchBy, int? branch, int? page, int pageSize)
        {
            return hr.GetPendingEmployeeList(SearchValue, searchBy, branch, page, pageSize);
        }
        public List<Object> GetHrCurrentJobEmployee(string SearchValue,string searchBy,int? page,int? pageSize)
        {
            return hr.GetHrCurrentJobEmployee(SearchValue, searchBy, page, pageSize);
        }
        public void HREmployeeInsert(string pivchNIK,string pivchEmployeeName)
        {
            hr.HREmployeeInsert(pivchNIK, pivchEmployeeName);
        }
        public List<spHREmployeeView_Result> GetEmployeeView(string pivchNIK)
        {
            return hr.GetEmployeeView(pivchNIK);
        }
        public List<spHREmployeeDetailList_Result> getJobHistory(string pivchNIK)
        {
            return hr.getJobHistory(pivchNIK);
        }
        public List<HRAccountNumberGet_Result> getAccountNumber(string pivchNIK)
        {
            return hr.getAccount(pivchNIK);
        }
        public string insertHRJobDetail(string pivchNIK, int? piintJobType, int? piintBranchId, string pivchDepartementCode, string privilegeCode, DateTime? pidtmEffectiveDateFrom, DateTime? pidtmEffectiveDateTo, int? piintBranchIdFrom, string pivchDepartementCodeFrom, string pivchPrivilegeCodeFrom)
        {
            return hr.insertHRJobDetail(pivchNIK,piintJobType,piintBranchId,pivchDepartementCode,privilegeCode,pidtmEffectiveDateFrom,pidtmEffectiveDateTo,piintBranchIdFrom,pivchDepartementCodeFrom,pivchPrivilegeCodeFrom);
        }
        public List<spHREmployeeDetailView_Result> GetEmployeeJobDetail(string pivchEmployeeJobId)
        {
            return hr.getEmployeeJobDetail(pivchEmployeeJobId);
        }
        public int? getBranchType(int piintBranchId)
        {
            return hr.GetBranchType(piintBranchId).FirstOrDefault();
        } 
        public string getWFCode(int branchId,string deptCode,string workFlowType,string privilege)
        {
            return hr.GetWorkFlowCode(branchId, deptCode, workFlowType, privilege).FirstOrDefault();
        }
        public void addWorkFlow(string workflowcode,int? workflowbranchCode,string workflowtablekey,string workflowtablevalue,string workflowapprovalstatus,string workflowdescription,string workflowcreatedby,int? workflowcreatedbranch,string workflowupdateby,DateTime? workflowupdatedate)
        {
             hr.insertWorkFlow(workflowcode, workflowbranchCode, workflowtablekey, workflowtablevalue, workflowapprovalstatus, workflowdescription, workflowcreatedby, workflowcreatedbranch, workflowupdateby, workflowupdatedate);
        }
        public void addBankAccount(string nik,string bankfincode,string bankname,string accountnumber,string accountname,bool? isactive,string approvalstatus)
        {
            hr.insertEmpAccount(nik, bankfincode, bankname, accountnumber, accountname, isactive, approvalstatus);
        }
        public List<HRAccountNumberGet_Result> getAccountInfo(string nik)
        {
            return hr.getAccountInfo(nik);
        }
        public void addHrPrivilege(string pivchPrivilegeCode, string pivchPrivilegeName, int piintBranchId, string pivchDepartementCode, string pivchOrgId)
        {
            hr.addHrPrivilege(pivchPrivilegeCode, pivchPrivilegeName, piintBranchId, pivchDepartementCode, pivchOrgId);
        }
        public string InsertUserAccessRequest(string pivchJobEmployeeId ,string pivchReason)
        {
           string AccessID = hr.addHRAddRequestUserInsert(DateTime.Now,pivchJobEmployeeId,pivchReason);
           return AccessID;
        }
        public List<spHRAddUserRequestView_Result> GetUserRequestView(string accessID)
        {
            List<spHRAddUserRequestView_Result> result = new List<spHRAddUserRequestView_Result>();
            result = hr.GetUserRequestDetailView(accessID);
            return result;
        }
        public List<spHRAddUserRequestDetailList_Result> GetUserAppRole(string accessID)
        {
            return hr.GetUserAccessRole(accessID);
        }
        public void AddUserRequestAccessID(string reqID, string appCode, string LocCOde, int? piintAutoDBId, string pivchInputID)
        {
            hr.addUserRequestAccessID(reqID, appCode, LocCOde, piintAutoDBId, pivchInputID);
        }
        public List<MsWorkFlowShowPath_Result> showWorkFlowPath(string RequestID)
        {
            return hr.path(RequestID);
        }
        public List<MsWorkFlowHistoryGet_Result> GetHistoryWF(string RequestID)
        {
            return hr.WFHistory(RequestID);
        }
        public void updateUserRequest(string pivchAddRequestID, string pivchJobEmployeeId, string pivchReason)
        {
            hr.updateRequestDetail(pivchAddRequestID, pivchJobEmployeeId, pivchReason);
        }
        public void cancelUserRequest(string pivchFormState, string pivchAddRequestID, string pivchProcessStatus,string pivchCancelReason)
        {
            hr.cancelRequest(pivchFormState, pivchAddRequestID, pivchProcessStatus, pivchCancelReason);
        }
         public List<Object> GetHrDeleteCurrentJobEmployee(string SearchValue,string Whereby, string searchBy, int? page, int? pageSize)
        {
            return hr.GetHrDeleteCurrentJobEmployee(SearchValue,Whereby, searchBy, page, pageSize);
         }
         public string HrDeleteUserRequestInsert(DateTime pidtmDeleteRequestDate, string pivchJobEmployeeId, int? piintReasonDelete, string pivchReasonDesc, DateTime? pidtmResignDate, DateTime? pidtmResignEffectiveDate)
         {
            string outputCode =  hr.addHRDeleteRequestUserInsert(pidtmDeleteRequestDate, pivchJobEmployeeId, piintReasonDelete, pivchReasonDesc, pidtmResignDate, pidtmResignEffectiveDate);
            return outputCode;
         }
        public List<spHRDeleteUserRequestView_Result> GetHRDeleteRequestInfo(string No)
         {
             return hr.GetDeleteRequestInfo(No);
         }
        public void UpdateDeleteRequestUser(string pivchDeleteRequestID,string pivchJobEmployeeId,int? piintReasonDelete,string pivchReasonDesc,DateTime? pidtmResignDate,DateTime? pidtmResignEffectiveDate)
        {
            hr.UpdateDeleteRequestUser(pivchDeleteRequestID, pivchJobEmployeeId, piintReasonDelete, pivchReasonDesc, pidtmResignDate, pidtmResignEffectiveDate);
        }
    }
}