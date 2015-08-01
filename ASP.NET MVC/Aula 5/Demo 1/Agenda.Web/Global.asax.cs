using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RobsonROX.Util.MVC.RouteDebug;

namespace Agenda.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
            ModelConfig.AssociateMetadata();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
