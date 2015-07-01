using System.Web;
using System.Web.Optimization;
using KDCLLC.Web;
using ChameleonForms;
using ChameleonForms.Templates.TwitterBootstrap3;


namespace KDCLLC.Web
{
    /// <summary>
    /// Provides away to compile Scripts
    /// </summary>
    public class ScriptBundleConfig
    {
        public static readonly string jquery = "~/bundles/jquery";
        public static readonly string modernizr = "~/bundles/modernizr";
        public static readonly string jqueryval = "~/bundles/jqueryval";
        public static readonly string bootstrap = "~/bundles/bootstrap";
        public static readonly string chameleonBootstrap = "~/bundles/chameleon-bootstrapjs";

        public static void RegisterBundles(BundleCollection bundles)
        {
          
            RegisterJQuery(bundles);

            RegisterJQueryValidation(bundles);


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle(modernizr).Include(
                        "~/Scripts/modernizr-*"));

            RegisterBoostrap(bundles);

            RegisterChameleon(bundles);

        }

        private static void RegisterJQuery(BundleCollection bundles)
        {
                bundles.Add(new ScriptBundle(jquery).Include(
              "~/Scripts/jquery-{version}.js"));
        }

        private static void RegisterJQueryValidation(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle(jqueryval).Include(
                        "~/Scripts/jquery.validate*"));
        }

        private static void RegisterBoostrap(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(bootstrap).Include(
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/respond.js"));
        }

        private static void RegisterChameleon(BundleCollection bundles)
        {
            FormTemplate.Default = new TwitterBootstrapFormTemplate();
            bundles.Add(new ScriptBundle(chameleonBootstrap).Include(
                "~/Scripts/jquery.validate.unobtrusive.twitterbootstrap.js"
            ));
        }
    }


}
//-- Extension of the T4MVC generation
namespace Links
{
    public static partial class Bundles
    {
        public static partial class Scripts
        {
            public static readonly string jquery = ScriptBundleConfig.jquery;
            public static readonly string jqueryval = ScriptBundleConfig.jqueryval;



            //public static readonly string jqueryui = "~/scripts/jqueryui";

            public static readonly string bootstrap = ScriptBundleConfig.bootstrap;
            public static readonly string chameleonBootstrap = ScriptBundleConfig.chameleonBootstrap;


            public static readonly string modernizr = ScriptBundleConfig.modernizr;
        }

    }
}