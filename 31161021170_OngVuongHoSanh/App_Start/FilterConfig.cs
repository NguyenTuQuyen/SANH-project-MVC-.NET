using System.Web;
using System.Web.Mvc;

namespace _31161021170_OngVuongHoSanh
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
