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
using Usoft.Common.CommonFunction;
using System.IO;

namespace USOFT.Areas.InformationTechnology.Controllers
{
    public class MailReminderController : Controller
    {
        //
        // GET: /InformationTechnology/MailReminder/
    
        PopulatedDdl ddl = new PopulatedDdl();
        MainITModel itmod = new MainITModel();
        ITMainModel mod = new ITMainModel();
        CommonFunction cf = new CommonFunction();
        public ActionResult Index()
        {
            return View();
        }
        public void populatedMail(string id)
        {
            ViewBag.menu = new SelectList(ddl.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
            ViewBag.activ = new SelectList(ddl.ActiveStateToCombo().AsEnumerable());
            ViewBag.isactive = new SelectList(ddl.ActiveStateToCombo().AsEnumerable());

        }
        public void populatedMailDetailInsert()
        {
            ViewBag.intervalBy = new SelectList(ddl.intervalBy().AsEnumerable());
            ViewBag.intervalHour = new SelectList(ddl.intervalHour().AsEnumerable());
            ViewBag.intervalMinute = new SelectList(ddl.intervalMinute().AsEnumerable());
        }
        public ActionResult MailReminder(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
            populatedMail(id);
            return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
            
        }
        [HttpPost]
        public JsonResult GetMailData(string IsActive, GetMenuResult ddl, string SearchValue, string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = itmod.GetMailTask(IsActive, SearchValue, ddl.ParamField, page, pageSize);
            var result = (List<spITMailReminderList_Result>)obj[0];
            int totalRecord = Convert.ToInt32(obj[2]);
            int totalPages = (int)Math.Ceiling((float)totalRecord / (float)pageSize);
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecord,
                rows = result
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddMailReminder(string id)
        {
            Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege(id);

                if (result[0].CanInsert == true)
                {
                    ViewBag.menuId = id;
                     populatedMail(id);
                    return View();
                }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult AddMailReminder(string id,string pivchSubject, string pivchBody, string pivchDescription, string IsActive, string input)
        {
            populatedMail(id);
            bool activ;
            if (IsActive == "Active")
            {
                activ = true;
            }
            else
            {
                activ = false;
            }
            int reminderId = mod.insertMailReminder(pivchSubject, pivchBody, pivchDescription, activ, input);
            return RedirectToAction("MainReminderDetail", "MailReminder", new { value = reminderId });
        }
        public ActionResult MainReminderDetail(int value)
        {
            List<spITMailReminderView_Result> result = new List<spITMailReminderView_Result>();
            result = itmod.itMailReminderDetail(value);
            ViewBag.Id = result[0].ReminderId;
            ViewBag.Subject = result[0].Subject;
            ViewBag.Body = result[0].Body;
            return View();
        }
        [HttpPost]
        public ActionResult MainReminderDetail(int val, string command)
        {
            if (command == "Edit Header")
            {
                return RedirectToAction("EditMailReminder", "MailReminder", new { value = val });
            }
            else
                if (command == "Add Detail")
                {
                    return RedirectToAction("AddDetailMailReminder", "MailReminder", new { value = val });
                }
                else
                    if (command == "Add File")
                    {
                        return RedirectToAction("AddMailFile", "MailReminder", new { value = val });
                    }
            return RedirectToAction("AddMailReminder", "MailReminder");
        }
        public ActionResult EditMailReminder(int value,string id)
        {
            List<spITMailReminderView_Result> result = new List<spITMailReminderView_Result>();
            result = itmod.itMailReminderDetail(value);
            ViewBag.Id = result[0].ReminderId;
            ViewBag.Subject = result[0].Subject;
            ViewBag.Body = result[0].Body;
            ViewBag.desc = result[0].Description;
            populatedMail(id);
            return View();
        }
        [HttpPost]
        public ActionResult EditMailReminder(int Val, string pivchSubject, string pivchBody, string pivchDescription, string IsActive, string input)
        {
            bool activ;
            if (IsActive == "Active")
            {
                activ = true;
            }
            else
            {
                activ = false;
            }
            itmod.updateMailReminder(Val, pivchSubject, pivchBody, pivchDescription, activ, "arie");
            return RedirectToAction("EditMailReminder", "MailReminder", new { value = Val });
        }

        public JsonResult GetSchedulerList(int value, int? page, string sidx, string sord, int rows = 1)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var result = itmod.getMailSchedulerList(value);
            var jsonData = new
            {

                page,

                rows = result
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddDetailMailReminder(int value)
        {
            List<spITMailReminderView_Result> result = new List<spITMailReminderView_Result>();
            result = itmod.itMailReminderDetail(value);
            ViewBag.Id = result[0].ReminderId;
            ViewBag.Subject = result[0].Subject;
            populatedMailDetailInsert();
            return View();
        }
        [HttpPost]
        public ActionResult AddDetailMailReminder(int piintReminderId, string pivchMailTo, DateTime pidtmStartDate, DateTime pidtmEndDate, string pivchIntervalBy, string pivchIntervalHour, string pivchIntervalMinute, string pivchDescription, int pivchIntervalRange = 0)
        {
            int range;
            if (pivchIntervalRange < 0)
            {
                range = 0;
            }
            else
            {
                range = pivchIntervalRange;
            }
            itmod.addDetailMailReminder(piintReminderId, pivchMailTo, pidtmStartDate, pidtmEndDate, pivchIntervalBy, range, pivchIntervalHour, pivchIntervalMinute, pivchDescription);
            return RedirectToAction("MainReminderDetail", "MailReminder", new { value = piintReminderId });
        }

        public ActionResult AddMailFile(int value,string id)
        {
            List<spITMailReminderView_Result> result = new List<spITMailReminderView_Result>();
            result = itmod.itMailReminderDetail(value);
            ViewBag.Id = result[0].ReminderId;
            ViewBag.Subject = result[0].Subject;
            return View();
        }
        [HttpPost]
        public ActionResult AddMailFile(int piintReminderId, int? piintSequence, string pivchNewFileName, string pivchDescription, HttpPostedFileBase pivchFileName)
        {
            if (prosesData(piintReminderId, piintSequence, pivchDescription, pivchFileName) == true)
            {
                return RedirectToAction("MainReminderDetail", "MailReminder", new { value = piintReminderId });
            }
            else
                return View();
        }
        public bool prosesData(int piintReminderId, int? piintSequence, string pivchDescription, HttpPostedFileBase upload)
        {
            if (upload.ContentLength > 0 && upload.ContentType == "image/jpeg")
            {
                Upload info = new Upload();
                UploadModel da = new UploadModel();
                USOFT.DataAccess.General.comfunc com = new USOFT.DataAccess.General.comfunc();
                info.UploadId = 8;
                var res = da.getUploadRestult(info.UploadId);
                string fileName = upload.FileName;
                string fileExt = VirtualPathUtility.GetExtension(upload.FileName);
                string filetype = upload.ContentType;
                Int64 FileSize = upload.ContentLength;
                string dirpath = com.spGetParamValue("UPLOAD_DIR", "GLOBAL_DIR") + "/" + res[0].DirPath;
                string newfileName = DateTime.Now.ToString("yyyyMMddhhmmss") + fileExt;
                string newFilePath = dirpath + "/" + newfileName;
                string[] allowFileExt = cf.ConvertStrToArrStr(res[0].FileExt, ",");
                string[] allowFileType = cf.ConvertStrToArrStr(res[0].FileType, ",");
                Int64 allowFileSize = Convert.ToInt64(res[0].FileSize);

                if (!cf.CheckStringContain(fileExt, allowFileExt))
                {
                    ViewBag.Msg = "Please Select an Image File to Import";
                    return false;
                }
                else
                    if (!cf.CheckStringContain(filetype, allowFileType))
                    {
                        ViewBag.Msg = "Invalid File Type";
                        return false;
                    }
                    else
                        if (FileSize > allowFileSize)
                        {
                            ViewBag.Msg = "Invalid File Size ! Must Lower than " + Convert.ToString(allowFileSize / 1024) + "KB";
                            return false;
                        }
                        else
                            if (System.IO.File.Exists(newFilePath))
                            {
                                ViewBag.Msg = "File Alredy Exist in Server!";
                                return false;
                            }
                            else
                                if (System.IO.Directory.Exists(dirpath))
                                {
                                    Directory.CreateDirectory(dirpath);
                                }
                upload.SaveAs(newFilePath);
                itmod.addDetailFileMail(piintReminderId, piintSequence, fileName, newfileName, pivchDescription);
                return true;
            }
            else
            {
                return false;
            }


        }
        public JsonResult GetMailFile(int value, int? page, string sidx, string sord, int rows = 1)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var result = itmod.getFileDetail(value);
            var jsonData = new
            {

                page,

                rows = result
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MailReminderDelete(int value)
        {
            itmod.DeleteMailReminder(value);
            return RedirectToAction("MailReminder", "MailReminder");
        }
        public ActionResult MailSchedulerDelete(int value, int id)
        {
            List<spITMailSchedulerList_Result> result = new List<spITMailSchedulerList_Result>();
            result = itmod.getMailSchedulerList(id).ToList();
            var scheduleId = result.Where(x => x.No == value).Select(x => x.ScheduleId).FirstOrDefault();
            itmod.DeleteMailSchedule(id, scheduleId);
            return RedirectToAction("MainReminderDetail", "MailReminder", new { value = id });
        }
        public ActionResult MailSchedulerSend(int value, int id)
        {
            List<spITMailSchedulerList_Result> result = new List<spITMailSchedulerList_Result>();
            result = itmod.getMailSchedulerList(id).ToList();
            var scheduleId = result.Where(x => x.No == value).Select(x => x.ScheduleId).FirstOrDefault();
            itmod.SendMailSchedule(scheduleId);
            return RedirectToAction("MainReminderDetail", "MailReminder", new { value = id });
        }
        public ActionResult MailFileDelete(int value, int id)
        {
            List<spITMailReminderFileDetail_Result> result = new List<spITMailReminderFileDetail_Result>();
            result = itmod.getFileDetail(id);
            var FileId = result.Where(x => x.No == value).Select(x => x.FileId).FirstOrDefault();
            itmod.DeleteMailFile(id, FileId);
            return RedirectToAction("MainReminderDetail", "ITMail", new { value = id });
        }
        public ActionResult EditMailReminderSchedule(int value, int id)
        {
            List<spITMailSchedulerList_Result> result = new List<spITMailSchedulerList_Result>();
            var scheduleView = itmod.GetScheduleView(id, value);
            var mailReminder = itmod.itMailReminderDetail(id);
            result = itmod.getMailSchedulerList(id).ToList();
            var scheduleId = result.Where(x => x.No == value).Select(x => x.ScheduleId).FirstOrDefault();
            var view = itmod.GetScheduleView(id, scheduleId);
            ViewBag.no = value;
            ViewBag.scheduleId = scheduleId;
            populatedMailDetailInsert();
            ViewBag.reminderId = view[0].ReminderId;
            ViewBag.subject = mailReminder[0].Subject;
            ViewBag.mailTo = view[0].MailTo;
            ViewBag.startDate = view[0].StartDate.ToShortDateString();
            ViewBag.endDate = view[0].EndDate.Value.ToShortDateString();
            ViewBag.Description = view[0].Description;
            return View();
        }
        [HttpPost]
        public ActionResult EditMailReminderSchedule(int No, int piintscheduleId, int piintReminderId, string pivchMailTo, DateTime pidtmStartDate, DateTime pidtmEndDate, string pivchIntervalBy, string pivchIntervalHour, string pivchIntervalMinute, string pivchDescription)
        {
            string interval = null;
            int range = 0;
            if (pivchIntervalBy == "Just Once")
            {
                interval = "0";
                range = 0;
            }
            else
                if (pivchIntervalBy == "Day")
                {
                    interval = "1";
                    range = 123;
                }
                else
                    if (pivchIntervalBy == "Date")
                    {
                        interval = "2";
                        range = 123;
                    }
            itmod.UpdateMailSchedule(piintscheduleId, piintReminderId, pivchMailTo, DateTime.Parse(pidtmStartDate.ToShortDateString()), DateTime.Parse(pidtmEndDate.ToShortDateString()), interval, range, pivchIntervalHour, pivchIntervalMinute, pivchDescription);
            return RedirectToAction("EditMailReminderSchedule", "MailReminder", new { value = No, Id = piintReminderId });
        }
        public ActionResult EditMailFile(int id,int? value)
        {
            List<spITMailReminderFileDetailView_Result> row = new List<spITMailReminderFileDetailView_Result>();
            List<spITMailReminderView_Result> reminder = new List<spITMailReminderView_Result>();
            reminder = itmod.itMailReminderDetail(id);
            row = itmod.getUploadFile(id,value);
            ViewBag.ID = value;
            ViewBag.Sub = reminder[0].Subject;
            ViewBag.Sequence = row[0].Sequence;
            ViewBag.Description = row[0].Description;
            return View();
        }

	}
}