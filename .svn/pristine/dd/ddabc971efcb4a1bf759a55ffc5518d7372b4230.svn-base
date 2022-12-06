using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using System.Web.UI;
using System.Web;

namespace USOFT.DataAccess.WorkFlow
{
    
    public class WorkFlowModels
    {
        USOFTEntities db = new USOFTEntities();
        public List<msWorkFlowGroup_Result> WFGroup(int? branchId,string privilegeId,string userid)
        {
            List<msWorkFlowGroup_Result> result = new List<msWorkFlowGroup_Result>();
            result = db.msWorkFlowGroup(branchId,privilegeId,userid).ToList();
            return result;
        }

        public List<MsWorkFlowSearch_Result> WFSearch(int branchId,string privilegeCode,string username,string value)
        {
            List<MsWorkFlowSearch_Result> result = new List<MsWorkFlowSearch_Result>();
            result = db.MsWorkFlowSearch(branchId, privilegeCode, username, value).ToList();
            return result;
        }
        public void workFlowUpdated(int workflowid,string workflowapprovalstatus,string workflowupdateby,string workflowremark)
        {
            db.MsWorkFlowApproval(workflowid, workflowapprovalstatus, workflowupdateby, workflowremark);
        }
    }
}
