using SitefinityWebApp.Mvc.Models;
using System.ComponentModel;
using System.Web.Mvc;
using Telerik.Sitefinity.Events.Model;
using Telerik.Sitefinity.Frontend.Designers;
using Telerik.Sitefinity.Frontend.Events.Mvc.Controllers;
using Telerik.Sitefinity.Frontend.Events.Mvc.Models;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers.Events
{
    [EnhanceViewEnginesAttribute]
    [DesignerUrlAttribute("~/Telerik.Sitefinity.Frontend/Designer/Master/Event")] // needed to run the default designer
    [ControllerToolboxItem(Name = "EventsWidget", Title = "EventsWidget", SectionName = "MvcWidgets")]
    public class EventsWidgetController : EventController
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [Category("String Properties")]
        public string Message { get; set; }

        public ActionResult ShowMessage()
        {
            var model = new MyEventsWidgetModel();
            if (!string.IsNullOrEmpty(this.Message))
            {
                model.Message = this.Message;                
            }
            else
            {
                model.Message = "Hello from ShowMessage";
            }

            return View("Default.ShowMessage", model);
        }
    }
}