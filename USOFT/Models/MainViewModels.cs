using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USOFT.DataAccess;
using USOFT.DataAccess.Users;
using USOFT.DataAccess.Departement;
using USOFT.DataAccess.Branch;
using USOFT.DataAccess.Currency;
using USOFT.DataAccess.Measurement;
using USOFT.DataAccess.Upload;
namespace USOFT.Models
{
    public class MainViewModels
    {
        UserLogOn userLogon = new UserLogOn();
        DeptMeodel dept = new DeptMeodel();
        BranchModel branch = new BranchModel();
        CurrencyModel curr = new CurrencyModel();
        MeasurementModel measurement = new MeasurementModel();
        UploadModel upload = new UploadModel();
        
        public List<Object> GetUsers(string searchvalue,string ddl,int br,string dpt,string prev,int? page, int pageSize)
        {
            return userLogon.GetLogon(searchvalue,ddl,br,dpt,prev,page,pageSize);
        }

        //internal List<spUsersList_Result> GetUsers(string ddl, string searchvalue)
        //{
        //    throw new NotImplementedException();
        //}

        //internal List<spUsersList_Result> GetUsers(string p, string searchvalue)
        //{
        //    throw new NotImplementedException();
        //}

        //internal List<spUsersList_Result> GetUsers(string p1, string searchvalue, int p2, string p3, string p4)
        //{
        //    throw new NotImplementedException();
        //}

        //internal List<spUsersList_Result> GetUsers(string p1, string searchvalue, int p2, string p3, string p4)
        //{
        //    throw new NotImplementedException();
        //}
        public List<Object> GetPrev(string searchvalue,string ddl,string dpt,int page,int pageSize)
        {
            return userLogon.getPrev(searchvalue, ddl, dpt, page,pageSize);
        }

        public List<Object> GetDept(string searchvalue,string ddl,int page,int pageSize)
        {
            return dept.GetDept(searchvalue,ddl,page,pageSize);
        }

        public List<Object> GetBranch(string searchvalue, string ddl,int page,int pageSize)
        {
            return branch.GetBranch(searchvalue, ddl, page,pageSize);
        }

        public List<Object> GetCurrency(string searchvalue, string ddl,int page,int pageSize)
        {
            return curr.GetCurr(searchvalue, ddl, page,pageSize);
        }

        public List<Object> getMeasurement(string searchvalue, string ddl,int page,int pageSize)
        {
            return measurement.GetMeasurement(searchvalue, ddl,page,pageSize);
        }

        public List<Object> getUpload(string searchvalue, string ddl,int page,int pageSize)
        {
            return upload.GetUpload(searchvalue, ddl, page,pageSize);
        }

        //internal List<spUsersList_Result> GetUsers(string searchvalue, string p1, int p2, string p3, string p4, int? paging)
        //{
        //    throw new NotImplementedException();
        //}
        public List<spPrivilegeMenuList_Result> getPrivMenu()
        {
            return userLogon.getPrivMenu();
        }
    }
}