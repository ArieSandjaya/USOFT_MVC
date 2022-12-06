using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
namespace USOFT.DataAccess.Parameter
{
    public class ParameterModel
    {
        USOFTEntities db = new USOFTEntities();
        public List<spParameterList_List> GetParameter(string searchvalue, string ddl)
        {
            Users.UserLogOn log = new Users.UserLogOn();
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spParameterList_List> rows = db.spParameterList(log.SearchText(ddl, searchvalue), 1, 20, pointTotalPage, pointTotalData).ToList();
            return rows;
        }

        public void updateParameter(string parameter_old_code,string parameter_old_code_cond,string parameter_code,string parameter_code_cond,string parameter_group_code,string value,bool IsActive,bool IsDelete,string parameter_name,string parameter_description,string id)
        {
            db.spParameterUpdate(parameter_old_code, parameter_old_code_cond, parameter_code, parameter_code_cond, parameter_group_code, parameter_name, parameter_description, value, IsActive, IsDelete, id);
        }

        public void insertParameter(string parameter_code,string parameter_code_cond,string parameter_group_code,string value,bool IsActive,bool IsDelete,string parameter_name,string parameter_description,string id)
        {
            db.spParameterInsert(parameter_code, parameter_code_cond, parameter_group_code, parameter_name, parameter_description, value, IsActive, IsDelete, id);
        }
    }
}
