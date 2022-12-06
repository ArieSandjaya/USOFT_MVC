using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USOFT.DataAccess.Users
{
    public class UserInsert
    {
        USOFTEntities db = new USOFTEntities();
        public void insertUser(string UserId, string UserName,string NIK,int BranchId,string Email,string EmailB2B,string Pass,string canSendMail,string canChangePass,bool isActive,string inputId)
        {
            db.spUsersInsert(UserId, UserName, NIK, BranchId, Email, EmailB2B, Pass, canSendMail, canChangePass, isActive, inputId);
        }
    }
}
