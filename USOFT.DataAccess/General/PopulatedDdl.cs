﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USOFT.DataAccess.General
{
    public class PopulatedDdl
    {
        USOFTEntities db = new USOFTEntities();
        public List<GetBranchToCombo> brCombo()
        {
            List<GetBranchToCombo> branch = new List<GetBranchToCombo>();
            branch = db.spGetBranchToCombo("").ToList();
            return branch;
        }
        public List<GetDepartmentToCombo_Result> deptCombo()
        {
            List<GetDepartmentToCombo_Result> dept = new List<GetDepartmentToCombo_Result>();
            dept = db.spGetDepartementToCombo("").ToList();
            return dept;       
        }
        public List<GetPrevilegeToCombo> prevCombo()
        {
            List<GetPrevilegeToCombo> prev = new List<GetPrevilegeToCombo>();
            prev = db.spGetPrivilegeToCombo("").ToList();
            return prev;
        }
        public List<GetMenuResult> getMenu(string id, string state)
        {
            List<GetMenuResult> getMenu = new List<GetMenuResult>();
            getMenu = db.spGetParamFieldToCombo(id, state).ToList();
            
            return getMenu;
        }
        public List<string> ActiveStateToCombo()
        {
            List<string> getActiveState = new List<string>();
            getActiveState.Add("Active");
            getActiveState.Add("Non Active");
            return getActiveState;
        }
        public List<string> canChangePassToCombo()
        {
            List<string> canChangePassCombo = new List<string>();
            canChangePassCombo.Add("Yes");
            canChangePassCombo.Add("No");
            return canChangePassCombo;
        }
        public List<string> canSendEmail()
        {
            List<string> canSendMail = new List<string>();
            canSendMail.Add("Yes");
            canSendMail.Add("No");
            return canSendMail;
        }

        public List<string> branchType()
        {
            List<string> branchTyp = new List<string>();
            
            branchTyp.Add("STANDBY POINT");
            branchTyp.Add("BRANCH");
            return branchTyp;
        }

        public List<GetITProblemTypeToCombo> problemType()
        {
            List<GetITProblemTypeToCombo> probtype = new List<GetITProblemTypeToCombo>();
            probtype = db.spGetITProblemTypeToCombo("").ToList();
            return probtype;
        }
        
        public List<GetITItemTypeToCombo> itemType()
        {
            List<GetITItemTypeToCombo> itType = new List<GetITItemTypeToCombo>();
            itType = db.spGetITItemTypeToCombo("").ToList();
            return itType;
        }

        public List<GetMappingUserToCombo> mapuser()
        {
            List<GetMappingUserToCombo> mpUser = new List<GetMappingUserToCombo>();
            mpUser = db.spGetMappingUsersToCombo("").ToList();
            return mpUser;
        }

        public List<string> priority()
        {
            List<string> prior = new List<string>();
            prior.Add("Low");
            prior.Add("Medium");
            prior.Add("High");
            return prior;
        }

        public List<string> status()
        {
            List<string> stat = new List<string>();
            stat.Add("Open");
            stat.Add("Assign");
            stat.Add("Closed");
            stat.Add("Solved");
            stat.Add("Done");
            return stat;
        }

        public List<GetBranchToCombo> currentLocCombo()
        {
            List<GetBranchToCombo> currentLoc = new List<GetBranchToCombo>();
            currentLoc = db.spGetBranchToCombo("").ToList();
            currentLoc.Add(new GetBranchToCombo{ BranchId = 0, BranchName = "Warehouse" });
            return currentLoc;
        }

       public List<string> ITitemInStatus()
        {
            List<string> itemInStat = new List<string>();
            itemInStat.Add("New");
            itemInStat.Add("Return");
            itemInStat.Add("Replace");
            return itemInStat;
        }
       public List<string> ITitemOutStatus()
       {
           List<string> itemOutStat = new List<string>();
           itemOutStat.Add("Repair");
           itemOutStat.Add("Dispose");
       
           return itemOutStat;
       }
       public List<spGetITConditionToCombo> ITItemCondition()
       {
           List<spGetITConditionToCombo> condition = new List<spGetITConditionToCombo>();
           condition = db.spGetITConditionToCombo("").ToList();
           return condition;
       }

       public List<string> ReceiveFrom()
       {
           List<string> receive = new List<string>();
           receive.Add("Branch");
           receive.Add("Vendor");
           return receive;
       }

        public List<spGetITSupplierToCombo_Result> supplierCombo()
       {
           List<spGetITSupplierToCombo_Result> supplier = new List<spGetITSupplierToCombo_Result>();
           supplier = db.spGetITSupplierToCombo("").ToList();
           return supplier;
       }
        public List<string> DocStatus()
        {
            List<string> status = new List<string>();
            status.Add("Draft");
            status.Add("RFA");
            status.Add("Approve");
            return status;
        }
        public List<string> AssignAction(string condition)
        {
            List<string> stats = new List<string>();
            stats.Add("Assign");
            if (condition == "1")
            {
                stats.Add("Solved");
            }
            stats.Add("Closed");
            return stats;
        }
        public List<string> intervalBy()
        {
            List<string> interval = new List<string>();
            interval.Add("Just Once");
            interval.Add("Day");
            interval.Add("Date");
            return interval;
        }

        public List<string> intervalMinute()
        {
            List<string> Minute = new List<string>();
            Minute.Add("00");
            Minute.Add("05");
            Minute.Add("10");
            Minute.Add("15");
            Minute.Add("20");
            Minute.Add("25");
            Minute.Add("30");
            Minute.Add("35");
            Minute.Add("40");
            Minute.Add("45");
            Minute.Add("50");
            Minute.Add("55");
            return Minute;
        }
        public List<string> intervalHour()
        {
            List<string> Hour = new List<string>();
            for (int i = 0; i < 24; i++)
            {
                Hour.Add(i.ToString());
            }
            return Hour;
        }
        public List<spGetHRPrivilegeToCombo_Result> populatedPrivilege()
        {
            List<spGetHRPrivilegeToCombo_Result> result = new List<spGetHRPrivilegeToCombo_Result>();
            result = db.spGetHRPrivilegeToCombo("").ToList();
            return result;
        }
        public List<string> hrStatus()
        {
            List<string> stat = new List<string>();
            stat.Add("Active");
            stat.Add("Resign");
            return stat;
        }
        public List<spGetJobTypeToCombo_Result> hrJobType()
        {
            List<spGetJobTypeToCombo_Result> result = new List<spGetJobTypeToCombo_Result>();
            result = db.spGetHRJobTypeToCombo("").ToList();
            return result;
        }
        public List<spGetHRPrivilegeToCombo_Result> privCombo(string id)
        {
            List<spGetHRPrivilegeToCombo_Result> result = new List<spGetHRPrivilegeToCombo_Result>();
            result = db.spGetHRPrivilegeToCombo("a.BranchId =" + id).ToList();
            return result;
        }
        public List<spGetHRPrivilegeToCombo_Result> privDept(string id,string value)
        {
            List<spGetHRPrivilegeToCombo_Result> result = new List<spGetHRPrivilegeToCombo_Result>();
            result = db.spGetHRPrivilegeToCombo("a.BranchId =" + id + "and a.DepartementCode =" + value).ToList();
            return result;
        }
        public List<string> populatedFinBank()
        {
            List<string> name = new List<string>();
            name.Add("BCA");
            name.Add("BTMU");
            return name;
        }
        public List<string> AccessStatus()
        {
            List<string> result = new List<string>();
            result.Add("Draft");
            result.Add("Approved");
            result.Add("Requested");
            result.Add("Rejected");
            return result;
        }
        public List<string>ProcessStatus()
        {
            List<string> result = new List<string>();
            result.Add("In Progress");
            result.Add("Done");
            result.Add("Cancel");
            result.Add("Pending");
            return result;
        } 
        public List<spGetHRMsApplicationToCombo_Result> getMsAppCombo()
        {
            List<spGetHRMsApplicationToCombo_Result> result = new List<spGetHRMsApplicationToCombo_Result>();
            result = db.spGetHRMsApplicationToCombo().ToList();
            return result;
        }
        public List<spGetHRMsLocationToCombo_Result> getMsLocation()
        {
            List<spGetHRMsLocationToCombo_Result> result = new List<spGetHRMsLocationToCombo_Result>();
            result = db.spGetHRMsLocationToCombo().ToList();
            return result;
        }
        public List<string> getReasonDelete()
        {
            List<string> result = new List<string>();
            result.Add("Resign");
            result.Add("Mutation");
            result.Add("Rotation");
            result.Add("Back From Dual Job");
            result.Add("Demotion");
            result.Add("Cancel Join");
            result.Add("Other");

            return result;
        }


    
}
}
