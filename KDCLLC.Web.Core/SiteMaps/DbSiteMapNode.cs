using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvcSiteMapProvider;

namespace KDCLLC.Web.Core.SiteMaps
{
    public class DbSiteMapNode :  DynamicNodeProviderBase
    {
        /// <summary>
        /// Gets the dynamic node collection.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            return ReturnAll();
        }

        /// <summary>
        /// Returns all.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DynamicNode> ReturnAll()
        {
            //Todo: Load From Database
            var nodes = new[] {
            new DynamicNode
            {
               Title = "Home",
               ParentKey = "00000000-0000-0000-0000-000000000001",
               Key = "id1",
               Controller = "Home",
               Action = "Index"
              
            }
            ,
            new DynamicNode
            {
               Title = "Contact",
               ParentKey = "00000000-0000-0000-0000-000000000001",
               Key = "id2",
               Controller = "Home",
               Action = "Contact"
              
            },
            new DynamicNode
            {
               Title = "Base Page",
               ParentKey = "00000000-0000-0000-0000-000000000001",
               Key = "id3",
               Controller = "Page",
               Action = "Index",
               Url = "~/Page/Index",
               Attributes = new Dictionary<string, object>
                        {
                            {"Template", "~/Views/Shared/_LayoutBlue.cshtml"}
                        },
                        
            }
         };
            nodes[0].RouteValues.Add("id", 1);
            nodes[1].RouteValues.Add("id", 2);
            nodes[2].RouteValues.Add("id", 3);
            return nodes;
        }
    
    }
}
