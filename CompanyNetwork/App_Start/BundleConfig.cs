using System.Web.Optimization;

namespace CompanyNetwork
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                         "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                         "~/Content/Css/site.css",
                        "~/Content/Css/Info.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/respond.js",
                      "~/Scripts/canvasjs.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Css/bootstrap.css",
                      "~/Content/Css/site.css"));

            bundles.Add(new ScriptBundle("~/Content/chart").Include(
                      "~/Scripts/jquery-1.8.3.js",
                      "~/Scripts/ChartBuilder.js",
                      "~/Scripts/Chart.js"));

            bundles.Add(new ScriptBundle("~/bundles/info").Include(
                       "~/Scripts/InfoScript.js"));
        }
    }
}
