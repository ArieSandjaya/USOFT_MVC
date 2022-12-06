using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
namespace USOFT.DataAccess.Upload
{
    public class UploadModel
    {
        USOFTEntities db = new USOFTEntities();
        public List<Object> GetUpload(string searchvalue, string ddl, int page , int pageSize)
        {

            Users.UserLogOn log = new Users.UserLogOn();
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spUploadList_Result> rows = db.spUploadList(log.SearchText(ddl, searchvalue), page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(rows);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }

        public void editUpload(int UploadId,string DirPath,int? FileSize,string FileType,string FileExt,string id)
        {
            db.spUploadUpdate(UploadId, DirPath, FileExt, FileType, FileSize, id);
        }

        public void insertUpload(int UploadId, string DirPath, int? FileSize, string FileType, string FileExt, string id)
        {
            db.spUploadInsert(UploadId, DirPath, FileExt, FileType, FileSize, id);
        }
        public List<spUploadView_Result> getUploadRestult(int value)
        {
            List<spUploadView_Result> rows = db.spUploadView(value).ToList();
            return rows;
        }

        public void editUpload(int SearchValue, string p1, float? nullable, string p2, string p3, string p4)
        {
            throw new NotImplementedException();
        }

        public void deleteUpload(int uploadId)
        {
            db.spUploadDelete(uploadId);
        }
    }
}
