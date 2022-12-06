using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace USOFT.DataAccess.Measurement
{
    public class MeasurementModel
    {
        USOFTEntities db = new USOFTEntities();
        public List<Object> GetMeasurement(string searchvalue, string ddl,int page,int pageSize)
        {
            Users.UserLogOn log = new Users.UserLogOn();
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spMeasurementList_Result> rows = db.spMeasurementList(log.SearchText(ddl, searchvalue), page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(rows);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }

        public void editMeasurement(string measurementCode, string measurementName, bool IsActive, string inputId)
        {
            db.spMeasurementUpdate(measurementCode, measurementName, IsActive, inputId);
        }

        public void insertMeasurement(string measurementCode, string measurementName, bool IsActive, string inputId)
        {
            db.spMeasurementInsert(measurementCode, measurementName, IsActive, inputId);
        }

        public List<spMeasurementView_Result> getMeasurementResult(string value)
        {
            List<spMeasurementView_Result> rows = db.spMeasurementView(value).ToList();
            return rows;
        }
    }
}
