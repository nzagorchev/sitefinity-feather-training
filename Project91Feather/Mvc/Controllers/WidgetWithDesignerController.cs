using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using SitefinityWebApp.Mvc.Models;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "WidgetWithDesigner", Title = "WidgetWithDesigner", SectionName = "MvcWidgets")]
    public class WidgetWithDesignerController : Controller
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [Category("String Properties")]
        public string Header { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public IWidgetWithDesignerModel Model
        {
            get
            {
                if (model == null)
                {
                    model = new WidgetWithDesignerModel();
                }

                return model;
            }
            set { model = value; }
        }

        /// <summary>
        /// This is the default Action.
        /// </summary>
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(this.Header))
            {
                this.Model.Header = "Hello, World!";
            }
            else
            {
                this.Model.Header = this.Header;
            }

            return View("Default", this.Model);
        }

        private IWidgetWithDesignerModel model;
    }
}