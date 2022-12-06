using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Usoft.Common.CommonFunction
{
    public class CekSession
    {
        
        public static bool validate()
        {
            if (!SessionStatus())
            {
                return false;
            }
            return true;
        }
        public static bool SessionStatus()
        {
            if (HttpContext.Current.Session["UserId"] == null)
            {

                return false;
            }
            return true;
        }
    }
}
