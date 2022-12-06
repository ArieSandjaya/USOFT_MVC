using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
namespace USOFT.DataAccess.MappingApproval
{
    public class MappingModel
    {
        USOFTEntities db = new USOFTEntities();
        public List<spMappingApprovalList_Result> GetApprovval(string SearchValue, string ddl)
        {
            Users.UserLogOn log = new Users.UserLogOn();
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spMappingApprovalList_Result> rows = db.spMappingApprovalList(log.SearchText(ddl, SearchValue), 1, 20, pointTotalPage, pointTotalData).ToList();
            return rows;
        }

        public void editApproval(int approvalId,int menuId,string deptCode,string parentCode,string userIdApproval,bool IsBranch, int state,int toState,string stateDesc,bool IsActive,string InputId)
        {
            db.spMappingApprovalUpdate(approvalId, menuId, deptCode, parentCode, userIdApproval, IsBranch, state, toState, stateDesc, IsActive, InputId);
        }
        public void updateApproval(int approvalId, int menuId, string deptCode, string parentCode, string userIdApproval, bool IsBranch, int state, int toState, string stateDesc, bool IsActive, string InputId)
        {
            db.spMappingApprovalInsert(approvalId, deptCode, parentCode, userIdApproval, IsBranch, state, toState, stateDesc, IsActive, InputId);
        }
        public void delApproval(int searchvalue)
        {
            db.spMappingApprovalDelete(searchvalue);
        }
    }
}
