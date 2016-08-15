using SitefinityWebApp.Mvc.Infrastructure;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Routing;
using Telerik.Sitefinity.Model;

namespace SitefinityWebApp.Mvc.ActionFilters
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var @params = filterContext.ActionParameters;
            if (@params != null && @params.Count > 0)
            {
                if (@params.ContainsKey("item"))
                {
                    var item = @params["item"];
                    IHasTitle hasTitleItem = item as IHasTitle;
                    if (hasTitleItem != null)
                    {
                        string key = FeatherActionInvokerCustom.headerItemPrefix + "Item-Title";
                        filterContext.HttpContext.Items[key] = hasTitleItem.GetTitle();
                    }
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            string controllerName = filterContext.Controller.GetType().Name;
            string pageUrl = filterContext.Controller.ViewBag.PageUrl;
            string actionExecute = filterContext.ActionDescriptor.ActionName;

            string key = FeatherActionInvokerCustom.headerItemPrefix + "Action-Data";
            filterContext.HttpContext.Items[key] = string.Format("{0}, {1}, {2}", controllerName, pageUrl, actionExecute);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {

            base.OnResultExecuted(filterContext);
        }
    }
}