using SitefinityWebApp.Mvc.Models;
using System.ComponentModel;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Mvc.ActionFilters;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "WidgetResults", Title = "WidgetResults", SectionName = "MvcWidgets")]
    public class WidgetResultsController : Controller
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [Category("String Properties")]
        public string Message { get; set; }

        public string MyName
        {
            get 
            {
                if (string.IsNullOrEmpty(myName))
                {
                    myName = defaultMyName;
                }
                return myName;
            }
            set { myName = value; }
        }
        
        /// <summary>
        /// This is the default Action.
        /// </summary>
        public ActionResult Index()
        {
            var model = new WidgetResultsModel();
            if (string.IsNullOrEmpty(this.Message))
            {
                model.Message = "Hello, World!";
            }
            else
            {
                model.Message = this.Message;
            }

            // Set the page title
            ViewBag.Title = model.Message;

            return View("Default", model);
        }

        [JsonResultFilterAttribute]
        public JsonResult GetJson()
        {
            var model = new WidgetResultsModel();
            model.Message = "Hello, World JSON!";

            // Allow GET requests
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [StandaloneResponseFilterAttribute]
        public PartialViewResult GetPartial()
        {
            var model = new WidgetResultsModel();
            model.Message = "Hello, World Partial!";

            return PartialView("Default", model);
        }

        public PartialViewResult GetPartialFull()
        {
            var model = new WidgetResultsModel();
            model.Message = "Hello, World Partial and Full page HTML!";

            return PartialView("Default", model);
        }

        [StandaloneResponseFilter]
        public string GetMyName()
        {
            return this.MyName;
        }

        public string GetName(string letter)
        {
            
            string result = string.Empty;

            if (!string.IsNullOrEmpty(letter))
                letter = letter.ToLowerInvariant();

            switch (letter)
            {
                case "n": result = "Nikola"; break;
                case "j": result = "John"; break;
                default: result = "Anonymous";
                    break;
            }

            return result;
        }

        protected static string defaultMyName = "Nikola";
        private string myName;
    }
}