using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USOFT.DataAccess;
using System.Data.Entity.Core.Objects;
using System.Web.UI;
using System.Web;
namespace USOFT.DataAccess.IT
{
    public class ITMainModel
    {  Users.UserLogOn log = new Users.UserLogOn();
       USOFTEntities db = new USOFTEntities();
        public List<Object> getITActivityList(string status, int priority, string terminated, string pic, string item, string prob, int? br, string date, string SearchValue, string searchBy, int? page, int pageSize)
        {
            string WhereBy = log.SearchText(searchBy, SearchValue);

            if (date != "")
            {
                WhereBy += SqlAndOr(WhereBy, true) + " CONVERT(VARCHAR(8),a.ActivityDate,112) = CONVERT(VARCHAR(8),CONVERT(DATETIME,'" + date + "'),112)";
            }

            if (br > 0)
            {
                WhereBy += SqlAndOr(WhereBy, true) + " a.BranchId = " + br;
            }

            if (prob != "")
            {
                WhereBy += SqlAndOr(WhereBy, true) + " a.ProblemTypeCode = '" + prob + "'";
            }

            if (item != "")
            {
                WhereBy += SqlAndOr(WhereBy, true) + " a.ItemTypeCode = '" + item + "'";
            }

            if (priority >0 )
            {
                WhereBy += SqlAndOr(WhereBy, true) + " a.Priority = '" + priority + "'";
            }

            if (pic != "")
            {
                WhereBy += SqlAndOr(WhereBy, true) + " a.PIC = '" + pic + "'";
            }

            if (terminated != "")
            {
                WhereBy += SqlAndOr(WhereBy, true) + " a.TerminatedBy = '" + terminated + "'";
            }

            if (status != "")
            {
                WhereBy += SqlAndOr(WhereBy, true) + " a.Status = '" + status + "'";
            }

            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            
            List<spITActivityTaskList_Results> rows = db.spITActivityTaskList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(rows);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }
        public void updateITActivityTaskList(string pivchActivityNo,DateTime pidtmActivityDate,string pivchRequestBy,int piintBranchId,string pivchDepartementCode,int piintProblemTypeCode,string pivchItemTypeCode,string pivchDescription,string pivchPriority,string pivchInputID)
        {
            db.spITActivityTaskUpdate(pivchActivityNo, pidtmActivityDate, pivchRequestBy, piintBranchId, pivchDepartementCode, piintProblemTypeCode, pivchItemTypeCode, pivchDescription, pivchPriority, pivchInputID);
        }
        public string insertITActivityTaskList(DateTime pidtmActivityDate,string pivchRequestBy,int piintBranchId,string pivchDepartementCode,int piintProblemTypeCode,string pivchItemTypeCode,string pivchDescription,string pivchPriority,string pivchInputID)
        {
            ObjectParameter ActivityNo = new ObjectParameter("povchActivityNo", typeof(string));
            db.spITActivityTaskInsert(ActivityNo, pidtmActivityDate, pivchRequestBy, piintBranchId, pivchDepartementCode, piintProblemTypeCode, pivchItemTypeCode, pivchDescription, pivchPriority, pivchInputID);
            string activityNo = (string)ActivityNo.Value;
            return activityNo;

        }
        public List<spITActivityTaskView_Result> viewActivityTask(string value)
        {
            List<spITActivityTaskView_Result> result = new List<spITActivityTaskView_Result>();
            result = db.spITActivityTaskView(value).ToList();
            return result;
        }
        public List<Object> getITMailReminderList(string IsActive,string SearchValue, string searchBy, int? page, int pageSize)
        {
            string WhereBy = log.SearchText(searchBy, SearchValue);
            string active;
            if (IsActive == "Active")
            {
                active = "1";
                WhereBy += SqlAndOr(WhereBy, true) + " IsActive = " + active;
            }
            else
                if(IsActive == "Non Active")
                {
                    active = "0";
                    WhereBy += SqlAndOr(WhereBy, true) + " IsActive = " + active;
                }
           
           
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spITMailReminderList_Result> row = db.spITMailReminderList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(row);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }
        public List<Object> getITitemReceive(DateTime? date,string receive,int? br,string vendor,string userid,string DocStatus,string SearchValue, string searchBy, int? page, int pageSize)
        {
            string WhereBy = log.SearchText(searchBy, SearchValue);


            if (br > 0)
            {
                WhereBy += SqlAndOr(WhereBy, true) + " a.BranchId = '" + br + "'";
            }
            if (receive != null && receive != "")
            {
                WhereBy += SqlAndOr(WhereBy, true) + " CASE WHEN a.BranchId IS NOT NULL THEN 'Branch' WHEN a.SupplierCode IS NOT NULL THEN 'Vendor'  END = '" + receive + "'";
            }
            if (date != null)
            {
                WhereBy += SqlAndOr(WhereBy, true) + " a.Date = '" + date + "'";
            }
       
            if (vendor != null && vendor != "")
            {
                WhereBy += SqlAndOr(WhereBy, true) + " d.SupplierCode = '" + vendor + "'";
            }
            if (userid != null && userid != "")
            {
                WhereBy += SqlAndOr(WhereBy, true) + " a.created_by = '" + userid + "'";
            }
            if (DocStatus != null && DocStatus != "")
            {
                WhereBy += SqlAndOr(WhereBy, true) + " a.Status = '" + DocStatus + "'";
            }

            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spITItemReceive_Result> row = db.spITItemInList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList(); 
            List<Object> obj = new List<object>();
            obj.Add(row);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }
        public List<Object> getITItemList(string outStatus,string inStatus,int condition,string item,int br, string SearchValue, string searchBy, int? page, int pageSize)
        {
            string WhereBy = log.SearchText(searchBy, SearchValue);

            if (br > 0)
            {
                WhereBy += SqlAndOr(WhereBy, true) + " a.BranchId = '" + br + "'";
            }

            if (item != null && item != "")
            {
                WhereBy += SqlAndOr(WhereBy, true) + " a.ItemTypeCode = '" + item + "'";
            }
            if (condition > 0)
            {
                WhereBy += SqlAndOr(WhereBy, true) + " i.UserName = '" + condition + "'";
            }
            if (inStatus != null && inStatus != "")
            {
                WhereBy += SqlAndOr(WhereBy, true) + " j.UserName = '" + inStatus + "'";
            }
            if (outStatus != null && outStatus != "")
            {
                WhereBy += SqlAndOr(WhereBy, true) + " Priority = '" + outStatus + "'";
            }
         

            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spITItemList_Result> row = db.spITItemList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(row);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }
        public int insertMailReminder(string pivchSubject, string pivchBody, string pivchDescription, bool pibitIsActive, string pivchInputID)
        {
            ObjectParameter MailID = new ObjectParameter("pointReminderId", typeof(int));
            db.spITMailReminderInsert(MailID, pivchSubject, pivchBody, pivchDescription, pibitIsActive,HttpContext.Current.Session["UserId"].ToString());
            int id = (int)MailID.Value;
            return id;
        }
        public void updateMainReminder(int? piintReminderId,string pivchSubject, string pivchBody, string pivchDescription, bool pibitIsActive, string pivchInputID)
        {
            db.spITMailReminderUpdate(piintReminderId, pivchSubject, pivchBody, pivchDescription, pibitIsActive, HttpContext.Current.Session["UserId"].ToString());
        }
        public List<Object> getITItemType(string SearchValue, string searchBy, int? page, int pageSize)
        {
            string WhereBy = log.SearchText(searchBy, SearchValue);



            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spITItemType_Result> row = db.spITItemTypeList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(row);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }
        public List<Object> getITIProblemType(string SearchValue, string searchBy, int? page, int pageSize)
        {
            string WhereBy = log.SearchText(searchBy, SearchValue);



            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spITProblemTypeList_Result> row = db.spITProblemTypeList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(row);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }
        public List<Object> getITSupplierType(string SearchValue, string searchBy, int? page, int pageSize)
        {
            string WhereBy = log.SearchText(searchBy, SearchValue);



            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spITSupplierList_Result> row = db.spSupplierList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(row);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }
        public List<Object> getITConditionType(string SearchValue, string searchBy, int? page, int pageSize)
        {
            string WhereBy = log.SearchText(searchBy, SearchValue);



            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spITConditionList_Result> row = db.spITConditionList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(row);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }
        public List<Object> getLogResult(string dpt,int? br,string SearchValue, string searchBy, int? page, int pageSize)
        {
            string WhereBy = log.SearchText(searchBy, SearchValue);

            if (br > 0)
            {
                WhereBy += SqlAndOr(WhereBy, true) + " b.BranchId = " + br;
            }

            if (dpt != "" && dpt != null)
            {
                WhereBy += SqlAndOr(WhereBy, true) + " d.DepartementCode = " + dpt;
            }

            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spITLogList_Result> row = db.spUserLogsList(WhereBy, page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(row);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }
        public string SqlAndOr(string sqlText, bool state)
        {
            if ((sqlText != "") && (sqlText != null)) { sqlText = (state) ? " AND" : " OR"; }

            return sqlText;
        }
        public List<spGetAssignList_Result> getAssignList(string ActivityNo)
        {
            List<spGetAssignList_Result> getAssign = new List<spGetAssignList_Result>();
            getAssign = db.spITActivityAssignList(ActivityNo, " ").ToList();
            return getAssign;
        }
        public List<spITMailSchedulerList_Result> getMailScheduler(int? Val)
        {
            List<spITMailSchedulerList_Result> result = new List<spITMailSchedulerList_Result>();
            result = db.spITMailReminderScheduleDetailList(Val, "").ToList();
            return result;
        }
        public void InsertActivityAssignList(string pivchActivityNo,string pivchStatus,string pivchAssignTo,string pivchAssignDescription)
        {
            db.spITActivityAssignInsert(pivchActivityNo, pivchStatus, pivchAssignTo, pivchAssignDescription, HttpContext.Current.Session["UserId"].ToString());
        }
        public List<spITMailReminderView_Result> getMailReminderDetail(int value)
        {
            List<spITMailReminderView_Result> result = new List<spITMailReminderView_Result>();
            result = db.spITMailReminderView(value).ToList();
            return result;
        }
        public void addDetailMailReminder(int piintReminderId,string pivchMailTo,DateTime pidtmStartDate,DateTime pidtmEndDate,string pivchIntervalBy, int piintIntervalRange,string pivchIntervalHour,string pivchIntervalMinute,string pivchDescription)
        {
            db.spITMailReminderScheduleDetailInsert(piintReminderId, pivchMailTo, pidtmStartDate, pidtmEndDate, pivchIntervalBy, piintIntervalRange, pivchIntervalHour, pivchIntervalMinute, pivchDescription, HttpContext.Current.Session["UserId"].ToString());
        }
        public void addFileMail(int?piintReminderId,int? piintSequence,string pivchFileName,string pivchNewFileName,string pivchDescription)
        {
            db.spITMailReminderFileDetailInsert(piintReminderId, piintSequence, pivchFileName, pivchNewFileName, pivchDescription, HttpContext.Current.Session["UserId"].ToString());
        }
        public List<spITMailReminderFileDetail_Result> getFileEmailDetail(int? val)
        {
            List<spITMailReminderFileDetail_Result> result = new List<spITMailReminderFileDetail_Result>();
            result = db.spITMailReminderFileDetailList(val, "").ToList();
            return result;
        }
        public string addItemReceive(DateTime? pidtmDateIn,int? piintBranchFrom,string pivchSupplierCode)
        {
            ObjectParameter ItemInCode = new ObjectParameter("povchItemInCode", typeof(string));
            db.spITItemInInsert(ItemInCode, pidtmDateIn, piintBranchFrom, pivchSupplierCode, HttpContext.Current.Session["UserId"].ToString());
            string itemInCode = (string)ItemInCode.Value;
            return itemInCode;
        }
        public void addITItemType(string pivchItemCode,string pivchItemTypeName,bool? pibitIsActive)
        {
            db.spITItemTypeInsert(pivchItemCode, pivchItemTypeName, pibitIsActive, HttpContext.Current.Session["UserId"].ToString());
        }
        public void addITProblemType(string pivchProblemTypeCode,string pivchProblemTypeName,bool? pibitIsActive)
        {
            db.spITProblemTypeInsert(pivchProblemTypeCode, pivchProblemTypeName, pibitIsActive, HttpContext.Current.Session["UserId"].ToString());
        }
        public void addITCondition(int piintConditionCode,string pivchConditionName,bool? pibitIsActive)
        {
            db.spITConditionInsert(piintConditionCode, pivchConditionName, pibitIsActive, HttpContext.Current.Session["UserId"].ToString());
        }
        public string addITSupplier(string pivchSupplierName,string pivchAddress,string pivchCity,string pivchZipCode,string pivchPhone,string pivchNPWP,string pivchState,bool? pibitIsActive)
        {
            ObjectParameter supplierCode = new ObjectParameter("povchSupplierCode", typeof(string));
            db.spSupplierInsert(supplierCode, pivchSupplierName, pivchAddress, pivchCity, pivchZipCode, pivchPhone, pivchNPWP, pivchState, pibitIsActive, HttpContext.Current.Session["UserId"].ToString());
            string supCode = (string)supplierCode.Value;
            return supCode;
        }
        public void DeleteMailReminder(int piintRemindeId)
        {
            db.spITMailReminderDelete(piintRemindeId);
        }
        public void DeleteMailSchedule(int piintReminderId,int piintScheduleId)
        {
            db.spITMailReminderScheduleDetailDelete(piintReminderId, piintScheduleId);
        }
        public void SendScheduleMail(int piintScheduleId)
        {
            db.spITMailReminderScheduleDetailSending(piintScheduleId);
        }
        public void deleteFileMail(int piintFileId,int piintReminderId)
        {
            db.spITMailReminderFileDetailDelete(piintReminderId, piintFileId);
        }
        public List<spITMailReminderScheduleDetailView_Result> GetMailReminderScheduleView(int piintReminderId,int piintscheduleId )
        {
            List<spITMailReminderScheduleDetailView_Result> result = new List<spITMailReminderScheduleDetailView_Result>();
            result = db.spITMailReminderScheduleDetailView(piintscheduleId, piintReminderId).ToList();
            return result;
        }
        public void updateMailSchedule(int piintscheduleId,int piintReminderId,string pivchMailTo,DateTime pidtmStartDate,DateTime pidtmEndDate,string pivchIntervalBy, int piintIntervalRange,string pivchIntervalHour,string pivchIntervalMinute,string pivchDescription)
        {
            db.spITMailReminderScheduleDetailUpdate(piintscheduleId, piintReminderId, pivchMailTo, pidtmStartDate, pidtmEndDate, pivchIntervalBy, piintIntervalRange, pivchIntervalHour, pivchIntervalMinute, pivchDescription, HttpContext.Current.Session["UserId"].ToString());
        }
        public void updateITItemType(string pivchItemTypeCode,string pivchItemTypeName,bool? pibitIsActive)
        {
            db.spITItemTypeUpdate(pivchItemTypeCode, pivchItemTypeName, pibitIsActive, HttpContext.Current.Session["UserId"].ToString());
        }
        public void updateITCondition(int? piintConditionCode,string pivchConditionName,bool? pibitIsActive)
        {
            db.spITConditionUpdate(piintConditionCode, pivchConditionName, pibitIsActive, HttpContext.Current.Session["UserId"].ToString());
        }
        public void updateITProblemType(string pivchProblemTypeCode,string pivchProblemTypeName,bool? pibitIsActive)
        {
            db.spITProblemTypeUpdate(pivchProblemTypeCode, pivchProblemTypeName, pibitIsActive, HttpContext.Current.Session["UserId"].ToString());
        }
        public void updateITSupplier(string pivchSupplierCode,string pivchSupplierName,string pivchAddress,string pivchCity,string pivchZipCode,string pivchPhone,string pivchNPWP,string pivchState,bool? pibitIsActive)
        {
            db.spSupplierUpdate(pivchSupplierCode, pivchSupplierName, pivchAddress, pivchCity, pivchZipCode, pivchPhone, pivchNPWP, pivchState, pibitIsActive, HttpContext.Current.Session["UserId"].ToString());
        }
        public List<spITItemTypeView_Result> getITitem(string value)
        {
            List<spITItemTypeView_Result> result = db.spITItemTypeView(value).ToList();
            return result;
        }
        public List<spITProblemTypeView_Result> getProbType(string value)
        {
            List<spITProblemTypeView_Result> result = db.spITProblemTypeView(value).ToList();
            return result;
        }
        public List<spITConditionView_Result> getITCondition(int value)
        {
            List<spITConditionView_Result> result = db.spITConditionView(value).ToList();
            return result;
        }
        public List<spSupplierView_Result> getSup(string value)
        {
            List<spSupplierView_Result> result = db.spSupplierView(value).ToList();
            return result;
        }
        public List<spITMailReminderFileDetailView_Result> getFile(int? id,int? value)
        {
            List<spITMailReminderFileDetailView_Result> result = db.spITMailReminderFileDetailView(id, value).ToList();
            return result;
        }
        public List<spITActivityTaskView_Result> getTask(string value)
        {
            List<spITActivityTaskView_Result> result = db.spITActivityTaskView(value).ToList();
            return result;
        }

    }
}
