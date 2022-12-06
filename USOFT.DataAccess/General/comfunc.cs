using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USOFT.DataAccess.General
{
    public class comfunc
    {
        USOFTEntities db = new USOFTEntities();
        public string spGetParamValue(string parameter,string condition)
        {
            List<spGetParamValue_Result> result = new List<spGetParamValue_Result>();
            result = db.spGetParamValue(parameter, condition).ToList();
            return result[0].Value;

            
        }
    }
}
