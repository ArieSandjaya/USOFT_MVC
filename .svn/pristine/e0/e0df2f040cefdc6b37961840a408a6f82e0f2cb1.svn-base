using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USOFT.DataAccess.Users
{
    public class PrivilageModel
    {
        USOFTEntities db = new USOFTEntities();
        public void updatePrev(string privilegeCode,string privilageName,string privilegeShortName,string departementCode,string oldCode,bool isActive,string inputId)
        {
            db.spPrivilegeUpdate(privilegeCode, privilageName, privilegeShortName, departementCode, oldCode, isActive, inputId);
        }

        public void createPrev(string privilegeCode,string privilageName,string privilegeShortName,string departementCode,string oldCode,bool isActive,string inputId)
        {
            db.spPrivilegeInsert(privilegeCode, privilageName, privilegeShortName, departementCode, oldCode, isActive, inputId);
        }

    }
}
