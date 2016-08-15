using SitefinityWebApp.Mvc.Models;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    /// <summary>
    /// The Controller shows usage of the RelativeRoute and Route attributes
    /// If one of the attributes is added to an Action, all other Controller's Actions should also be decorated with an attribute.
    /// Relative route - relative to the page;
    /// Route - relative to the application path;
    /// </summary>
    [ControllerToolboxItem(Name = "WidgetRoutes", Title = "WidgetRoutes", SectionName = "MvcWidgets")]
    public class WidgetRoutesController : Controller
    {
        [RelativeRoute("")]
        [RelativeRoute("index")]
        public ActionResult Index()
        {
            var model = new WidgetRoutesModel();
            model.Message = "Hello, World!";

            return View("Default", model);
        }

        [RelativeRoute("index-second")]
        public ActionResult Index2()
        {
            var model = new WidgetRoutesModel();
            model.Message = "Hello, World 2!";

            return View("Default", model);
        }

        [Route("index-third")]
        [RelativeRoute("index-third")]
        public ActionResult Index3()
        {
            var model = new WidgetRoutesModel();
            model.Message = "Hello, World 3!";

            return View("Default", model);
        }
    }
}