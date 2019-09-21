using AppVendas.Infra.CrossCutting.Filters;
using System.Web;
using System.Web.Mvc;

namespace AppVendas.Ui
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}
