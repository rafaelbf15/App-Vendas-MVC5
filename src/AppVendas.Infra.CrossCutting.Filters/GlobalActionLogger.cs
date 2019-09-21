using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppVendas.Infra.CrossCutting.Filters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //LOG...

            if (filterContext.Exception != null)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new HttpStatusCodeResult(500);
            }

            base.OnActionExecuted(filterContext);
        }


    }
}
