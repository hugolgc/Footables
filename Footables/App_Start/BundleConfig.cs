using System.Web;
using System.Web.Optimization;

namespace Footables
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/tailwind.min.css",
                "~/Content/swiper.min.css",
                "~/Content/genesis.css",
                "~/Content/master.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/jquery.min.js",
                "~/Scripts/swiper.min.js",
                "~/Scripts/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/chart").Include("~/Scripts/chart.min.js"));
        }
    }
}
