using System.Web.Optimization;

namespace Agenda.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
            bundles.Add(new StyleBundle("~/bundles/css").Include("~/Content/Styles/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include("~/Content/Scripts/jquery*")
                                                        .Include("~/Content/Scripts/site.js"));
        }
    }
}