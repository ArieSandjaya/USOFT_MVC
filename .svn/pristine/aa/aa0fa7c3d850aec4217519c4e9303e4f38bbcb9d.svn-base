using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USOFT.DataAccess.IT;
using USOFT.DataAccess;
namespace USOFT.Models
{
    
    public class MainITModel
    {
        ITMainModel it = new ITMainModel();
        public List<Object> GetITTask(string status, int priority, string terminated, string pic, string item, string prob, int? br, string date, string SearchValue, string searchBy, int? page, int pageSize)
        {
            return it.getITActivityList(status,priority,terminated,pic,item,prob,br,date, SearchValue, searchBy, page, pageSize);
        }
        public List<Object> GetMailTask(string IsActive,string SearchValue, string searchBy,int? page,int pageSize )
        {
            return it.getITMailReminderList(IsActive,SearchValue, searchBy, page, pageSize);
        }

        public List<Object> GetITItem(string outStatus,string inStatus,int condition,string item,int br, string SearchValue, string searchBy, int? page, int pageSize)
        {
            return it.getITItemList(outStatus, inStatus, condition, item, br, SearchValue, searchBy, page, pageSize);
        }

        public List<Object> GetReceiveItemData(DateTime? date,string receive,int? br,string vendor,string userid,string DocStatus,string SearchValue, string searchBy, int? page, int pageSize)
        {
            return it.getITitemReceive(date, receive, br, vendor, userid, DocStatus, SearchValue, searchBy, page, pageSize);
        }
        public List<Object> GetItemTypeList(string SearchValue,string searchBy,int? page,int pageSize)
        {
            return it.getITItemType(SearchValue, searchBy, page, pageSize);
        }
        public List<Object> GetProblemTypeList(string SearchValue, string searchBy, int? page, int pageSize)
        {
            return it.getITIProblemType(SearchValue, searchBy, page, pageSize);
        }
        public List<Object> getITSupplierList(string SearchValue, string searchBy, int? page, int pageSize)
        {
            return it.getITSupplierType(SearchValue, searchBy, page, pageSize);
        }
        public List<Object> getITConditionList(string SearchValue, string searchBy, int? page, int pageSize)
        {
            return it.getITConditionType(SearchValue, searchBy, page, pageSize);
        }
        public List<Object> getLogList(string dpt,int? br, string SearchValue,string searchBy,int? page, int pageSize)
        {
            return it.getLogResult(dpt, br, SearchValue, searchBy, page, pageSize);
        }
        public List<spGetAssignList_Result> getAssignList(string activityNo)
        {
            return it.getAssignList(activityNo);
        }
        public void insertAssign(string pivchActivityNo,string pivchStatus,string pivchAssignTo,string pivchAssignDescription)
        {
            it.InsertActivityAssignList(pivchActivityNo, pivchStatus, pivchAssignTo, pivchAssignDescription);
        }
        public List<spITMailReminderView_Result> itMailReminderDetail(int value)
        {
            return it.getMailReminderDetail(value);
            
        }
        public void updateMailReminder(int? piintReminderId,string pivchSubject, string pivchBody, string pivchDescription, bool pibitIsActive, string pivchInputID)
        {
            it.updateMainReminder(piintReminderId, pivchSubject, pivchBody, pivchDescription, pibitIsActive, pivchInputID);
        }
        public List<spITMailSchedulerList_Result> getMailSchedulerList(int? Val)
        {
            return it.getMailScheduler(Val);
        }
        public void addDetailMailReminder(int piintReminderId,string pivchMailTo,DateTime pidtmStartDate,DateTime pidtmEndDate,string pivchIntervalBy, int piintIntervalRange,string pivchIntervalHour,string pivchIntervalMinute,string pivchDescription)
        {
            it.addDetailMailReminder(piintReminderId, pivchMailTo, pidtmStartDate, pidtmEndDate, pivchIntervalBy, piintIntervalRange, pivchIntervalHour, pivchIntervalMinute, pivchDescription);
        }
        public void addDetailFileMail(int? piintReminderId, int? piintSequence, string pivchFileName, string pivchNewFileName, string pivchDescription)
        {
            it.addFileMail(piintReminderId, piintSequence, pivchFileName, pivchNewFileName, pivchDescription);
        }
        public List<spITMailReminderFileDetail_Result> getFileDetail(int? val)
        {
            return it.getFileEmailDetail(val);
            
        }
        public void addItemType(string pivchItemCode, string pivchItemTypeName, bool? pibitIsActive)
        {
             it.addITItemType(pivchItemCode, pivchItemTypeName, pibitIsActive);
        }
        public void addProblemType(string pivchProblemTypeCode,string pivchProblemTypeName,bool? pibitIsActive)
        {
            it.addITProblemType(pivchProblemTypeCode, pivchProblemTypeName, pibitIsActive);
        }
        public void addITCondition(int piintConditionCode, string pivchConditionName, bool? pibitIsActive)
        {
            it.addITCondition(piintConditionCode, pivchConditionName, pibitIsActive);
        }
        public string addITSupplier(string pivchSupplierName, string pivchAddress, string pivchCity, string pivchZipCode, string pivchPhone, string pivchNPWP, string pivchState, bool? pibitIsActive)
        {
          string supplierCode =   it.addITSupplier(pivchSupplierName,pivchAddress,pivchCity,pivchZipCode,pivchPhone,pivchNPWP,pivchState,pibitIsActive);
          return supplierCode;
        }
        public void DeleteMailReminder(int piintReminderId)
        {
            it.DeleteMailReminder(piintReminderId);
        }
        public void DeleteMailSchedule(int piintReminderId,int piintScheduleId)
        {
            it.DeleteMailSchedule(piintReminderId, piintScheduleId);
        }
        public void SendMailSchedule(int piintScheduleId)
        {
            it.SendScheduleMail(piintScheduleId);
        }
        public void DeleteMailFile(int piintReminderId,int piintFileId)
        {
            it.deleteFileMail(piintFileId, piintReminderId);
        }
        public List<spITMailReminderScheduleDetailView_Result> GetScheduleView(int piintReminderId,int piintScheduleId)
        {
            
            return it.GetMailReminderScheduleView(piintReminderId, piintScheduleId);
        }
        public void UpdateMailSchedule(int piintscheduleId,int piintReminderId,string pivchMailTo,DateTime pidtmStartDate,DateTime pidtmEndDate,string pivchIntervalBy, int piintIntervalRange,string pivchIntervalHour,string pivchIntervalMinute,string pivchDescription)
        {
            it.updateMailSchedule(piintscheduleId, piintReminderId, pivchMailTo, pidtmStartDate, pidtmEndDate, pivchIntervalBy, piintIntervalRange, pivchIntervalHour, pivchIntervalMinute, pivchDescription);

        }
        public void updateITCondition(int? piintConditionCode, string pivchConditionName, bool? pibitIsActive)
        {
            it.updateITCondition(piintConditionCode, pivchConditionName, pibitIsActive);
        }
        public void updateITItemType(string pivchItemTypeCode, string pivchItemTypeName, bool? pibitIsActive)
        {
            it.updateITItemType(pivchItemTypeCode, pivchItemTypeName, pibitIsActive);
        }
        public void updateITProblemType(string pivchProblemTypeCode, string pivchProblemTypeName, bool? pibitIsActive)
        {
            it.updateITProblemType(pivchProblemTypeCode, pivchProblemTypeName, pibitIsActive);
        }
        public void updateITSupplier(string pivchSupplierCode, string pivchSupplierName, string pivchAddress, string pivchCity, string pivchZipCode, string pivchPhone, string pivchNPWP, string pivchState, bool? pibitIsActive)
        {
            it.updateITSupplier(pivchSupplierCode, pivchSupplierName, pivchAddress, pivchCity, pivchZipCode, pivchPhone, pivchNPWP, pivchState, pibitIsActive);
        }
        public List<spITConditionView_Result> getConditionView(int value)
        {
            return it.getITCondition(value);
        }
        public List<spITItemTypeView_Result> getITItemType(string value)
        {
            return it.getITitem(value);
        }
        public List<spITProblemTypeView_Result> getProblemType(string value)
        {
            return it.getProbType(value);
        }
        public List<spSupplierView_Result> getSupplier(string value)
        {
            return it.getSup(value);
        }
        public List<spITMailReminderFileDetailView_Result> getUploadFile(int? id,int? value)
        {
            return it.getFile(id,value);
        }
        public List<spITActivityTaskView_Result> getTask(string value)
        {
            return it.getTask(value);
        }
        public void updateHeader(string pivchActivityNo, DateTime pidtmActivityDate, string pivchRequestBy, int piintBranchId, string pivchDepartementCode, int piintProblemTypeCode, string pivchItemTypeCode, string pivchDescription, string pivchPriority)
        {
            it.updateITActivityTaskList(pivchActivityNo, pidtmActivityDate, pivchRequestBy, piintBranchId, pivchDepartementCode, piintProblemTypeCode, pivchItemTypeCode, pivchDescription, pivchPriority, HttpContext.Current.Session["UserId"].ToString());
        }
    }
}