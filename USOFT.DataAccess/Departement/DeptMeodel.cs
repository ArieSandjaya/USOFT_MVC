using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace USOFT.DataAccess.Departement
{
    public class DeptMeodel
    {
        USOFTEntities db = new USOFTEntities();
        public List<Object> GetDept(string searchvalue,string ddl,int page,int pageSize)
        {
            Users.UserLogOn log = new Users.UserLogOn();
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spDeptList_Result> rows = db.spDepartementList(log.SearchText(ddl, searchvalue), page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(rows);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }

        public void editDept(string deptcode,string deptname,string codename,bool isactive,string inputId)
        {
            db.spDepartementUpdate(deptcode, deptname, codename, isactive, inputId);
        }

        public List<spDepartementView_Result> getDeptResult(string value)
        {
            List<spDepartementView_Result> row = db.spDepartementView(value).ToList();
            return row;
        }

        public void insertDept(string deptcode,string deptname,string codename,bool IsActive,string inputId)
        {
            db.spDepartementInsert(deptcode, deptname, codename, IsActive, inputId);
        }

       
    }
}
