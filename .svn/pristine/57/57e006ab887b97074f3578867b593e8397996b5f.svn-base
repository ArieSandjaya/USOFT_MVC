using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Collections;
namespace USOFT.Globaliztion
{
    public class CekSessions
    {
        private static Hashtable m_executingPages = new Hashtable();
        public CekSessions()
        { 
            
        }
        public static string getUserId()
        {
            return HttpContext.Current.Session["UserId"].ToString();
        }
        public static void ClearSession(Page myPage)
        {
            
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
