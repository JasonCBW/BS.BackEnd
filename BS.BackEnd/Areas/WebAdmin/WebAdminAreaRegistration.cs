using System.Web.Mvc;

namespace BS.BackEnd.Areas.WebAdmin
{
    public class WebAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WebAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "WebAdmin_default",
                "WebAdmin/{controller}/{action}/{id}",
                new { controller = "News", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "WebAdminPage_default",
                "WebAdmin/{controller}/{page}",
                new { controller = "News", action = "Index", page = UrlParameter.Optional }
            );
        }
    }
}