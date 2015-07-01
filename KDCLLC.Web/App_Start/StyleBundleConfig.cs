using System.Web.Optimization;
using KDCLLC.Web;

namespace KDCLLC.Web
{
    public class StyleBundleConfig
    {
        public static readonly string css = "~/Content/css";
        public static readonly string chameleonBootstrap = "~/bundles/chameleon-bootstrapcss";

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle(css).Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css"));



            //Chameleon Forms
            bundles.Add(new StyleBundle(chameleonBootstrap).Include(
              "~/Content/chameleonforms-twitterbootstrap.css"
          ));
        }

        
    }
}

//-- Extension of the T4MVC generation
namespace Links
{
    public static partial class Bundles
    {
        public static partial class Styles
        {
            public static readonly string css = StyleBundleConfig.css;
            public static readonly string chameleonBootstrap = StyleBundleConfig.chameleonBootstrap;

            
        }

    }
}