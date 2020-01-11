using System.Web;
using System.Web.Mvc;

namespace Konwerter_jednostek.Strona
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
