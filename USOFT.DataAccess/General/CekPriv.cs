using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web;
namespace USOFT.DataAccess.General
{
    public class CekPriv
    {
        USOFTEntities db = new USOFTEntities();
        public List<spGetUserInfo_Result> privilege(string MenuId)
        {
            List<spGetUserInfo_Result> result = new List<spGetUserInfo_Result>();
            result = db.spGetUserInfo(HttpContext.Current.Session["UserId"].ToString(), int.Parse(MenuId)).ToList();
            return result;
        }
    }
}
