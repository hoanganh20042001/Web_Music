using System.Web.Mvc;

namespace Web_Music.Areas.thi
{
    public class thiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "thi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "thi_default",
                "thi/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}