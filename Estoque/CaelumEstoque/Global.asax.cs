using System.Web.Mvc;
using System.Web.Routing;
using CaelumEstoque.App_Start;

namespace CaelumEstoque
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilders(GlobalFilters.Filters);
        }
    }
}
