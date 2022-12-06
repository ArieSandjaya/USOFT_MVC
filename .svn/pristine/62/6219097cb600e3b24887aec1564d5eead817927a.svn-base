using System.Web.Mvc;

namespace USOFT.Areas.InformationTechnology
{
    public class InformationTechnologyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "InformationTechnology";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "InformationTechnology_default",
                "InformationTechnology/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}