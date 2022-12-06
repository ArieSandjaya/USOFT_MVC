using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
namespace USOFT.DataAccess.Currency
{
    public class CurrencyModel
    {
        USOFTEntities db = new USOFTEntities();
        public List<Object> GetCurr(string SearchValue, string ddl, int page,int pageSize)
        {
            
            Users.UserLogOn log = new Users.UserLogOn();
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
          
            List<spCurrencyList_Result> row = db.spCurrencyList(log.SearchText(ddl, SearchValue), page, pageSize, pointTotalPage, pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(row);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }
        public List<spCurrencyView_Result> getCurrencyResult(string value)
        {
            List<spCurrencyView_Result> row = db.spCurrencyView(value).ToList();
            return row;
        }
        public void editCurr(string CurrencyCode, string CurrencyName , string CurrencySymbol, bool isActive, string inputID)
        {
            db.spCurrencyUpdate(CurrencyCode,CurrencyName,CurrencySymbol,isActive,inputID);
        }
        public void insertCurr(string CurrencyCode, string CurrencyName, string CurrencySymbol, bool isActive, string inputID)
        {
            db.spCurrencyInsert(CurrencyCode, CurrencyName, CurrencySymbol, isActive, inputID);
        }
    }
}
