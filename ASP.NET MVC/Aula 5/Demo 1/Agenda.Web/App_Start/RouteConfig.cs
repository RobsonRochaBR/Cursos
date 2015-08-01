using System.Web.Mvc;
using System.Web.Routing;

namespace Agenda.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "AlunosPorEMail",
            //    url:  "Alunos/{email}",
            //    defaults: new { controller = "Alunos", action = "EditarPorEMail" },
            //    constraints: new { email = @"[\w._%+-]+\@[\w.-]+\.[a-zA-Z]{2,4}" }
            //);

            //routes.Add(
            //    name:  "AlunosPorEMail", 
            //    item: new Route( 
            //        url: "Alunos/{email}",
            //        defaults: new RouteValueDictionary {
            //            { "controller", "Alunos"},
            //            { "action", "EditarPorEmail" }
            //        },
            //        constraints: new RouteValueDictionary {
            //            { "email", @"[\w._%+-]+\@[\w.-]+\.[a-zA-Z]{2,4}"}
            //        },
            //        dataTokens: new RouteValueDictionary {
            //            { "lorem", "ipsum"}
            //        },
            //        routeHandler: new MvcRouteHandler()
            //    )
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
