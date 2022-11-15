using System.Web;
using System.Web.Mvc;

namespace CA.Recipe.InterfacesAdapters
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
