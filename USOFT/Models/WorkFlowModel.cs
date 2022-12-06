using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USOFT.DataAccess;
namespace USOFT.Models
{
    public class WorkFlowModel
    {
        DataAccess.WorkFlow.WorkFlowModels wf = new DataAccess.WorkFlow.WorkFlowModels();
        public List<msWorkFlowGroup_Result> WFGroup(int? branchId,string privilegeId,string username)
        {
            List<msWorkFlowGroup_Result> row = new List<msWorkFlowGroup_Result>();
            return row = wf.WFGroup(branchId, privilegeId, username);
        }
        public List<MsWorkFlowSearch_Result> wfsearch(int branchId,string privilegeId,string username,string value)
        {
            return wf.WFSearch(branchId, privilegeId, username, value);
        }
        public void updateWorkApproval(int workflowid,string workflowapprovalstatus,string workflowupdateby,string workflowremark)
        {
            wf.workFlowUpdated(workflowid, workflowapprovalstatus, workflowupdateby, workflowremark);
        }
    }
}