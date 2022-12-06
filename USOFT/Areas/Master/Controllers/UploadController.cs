using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USOFT.DataAccess;
using USOFT.DataAccess.Users;
using USOFT.Models;
using USOFT.DataAccess.General;
using USOFT.DataAccess.Departement;
using USOFT.DataAccess.Currency;
using USOFT.DataAccess.Branch;
using USOFT.DataAccess.Measurement;
using USOFT.DataAccess.Upload;
using System.Collections;
using PagedList;
using System.Data.Entity.Core.Objects;
using Newtonsoft;


namespace USOFT.Areas.Master.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Master/Upload/
        Models.MainViewModels main = new Models.MainViewModels();
        PopulatedDdl ddl = new PopulatedDdl();
        USOFTEntities db = new USOFTEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Upload(string id)
        {
             Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
                CekPriv cekpriv = new CekPriv();
                result = cekpriv.privilege(id);
                ViewData["Privilege"] = result;
                ViewBag.menuId = id;
            PopulatedDdl dll = new PopulatedDdl();

            ViewBag.menu = new SelectList(dll.getMenu(id, "").AsEnumerable(), "ParamField", "ParamName");
            return View();
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public JsonResult GetUploadData(GetMenuResult ddl, string searchvalue, string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            List<Object> obj = main.getUpload(searchvalue, ddl.ParamField, page, pageSize);
            var result = (List<spUploadList_Result>)obj[0];
            int totalRecord = Convert.ToInt32(obj[2]);
            var totalPages = (int)Math.Ceiling((float)totalRecord / (float)pageSize);
            var jsonData = new
            {

                total = totalPages,
                page,
                records = totalRecord,
                rows = result.ToList()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditUpload(int value)
        {
            List<spUploadView_Result> upload = new List<spUploadView_Result>();
            UploadModel ups = new UploadModel();
            upload = ups.getUploadRestult(value);
            ViewBag.upId = upload[0].UploadId;
            ViewBag.dir = upload[0].DirPath;
            ViewBag.ext = upload[0].FileExt;
            ViewBag.type = upload[0].FileType;
            ViewBag.size = upload[0].FileSize;
            return View();
        }
        [HttpPost]
        public ActionResult EditUpload(Upload up, int SearchValue)
        {
            UploadModel upload = new UploadModel();
            upload.editUpload(SearchValue, up.DirPath, up.FileSize, up.FileType, up.FileExt, Session["UserId"].ToString());
            return RedirectToAction("EditUpload", "Upload", new { value = up.UploadId });
        }
        public ActionResult AddUpload(string id)
        {
             Usoft.Common.CommonFunction.CekSession.validate();
            if (Usoft.Common.CommonFunction.CekSession.validate() == true)
            {
                CekPriv cekpriv = new CekPriv();
                var result = cekpriv.privilege(id);

                if (result[0].CanInsert == true)
                {
                    ViewBag.menuId = id;
                    return View();
                }
                return RedirectToAction("LogOut", "Account", new { area = "" });
            }
            else
                return RedirectToAction("LogOut", "Account", new { area = "" });
        }
        [HttpPost]
        public ActionResult AddUpload(Upload up, int SearchValue)
        {
            UploadModel upload = new UploadModel();
            upload.insertUpload(SearchValue, up.DirPath, up.FileSize, up.FileType, up.FileExt, Session["UserId"].ToString());
            return View();
        }
        public ActionResult deleteUpload(int value)
        {
            UploadModel upload = new UploadModel();
            upload.deleteUpload(value);
            return RedirectToAction("Upload","Upload");
        }
	}
}