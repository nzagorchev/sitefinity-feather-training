using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitefinityWebApp.Mvc.Infrastructure
{
    public class EventsWidgetViewsEngine : RazorViewEngine
    {
        public EventsWidgetViewsEngine()
        {
            this.FileExtensions = new string[] { "cshtml" };
            this.AreaViewLocationFormats = EventsWidgetViewsEngine.baseLocationFormats;
            this.AreaMasterLocationFormats = EventsWidgetViewsEngine.baseLocationFormats;
            this.AreaPartialViewLocationFormats = EventsWidgetViewsEngine.baseLocationFormats;
            this.ViewLocationFormats = EventsWidgetViewsEngine.baseLocationFormats;
            this.MasterLocationFormats = EventsWidgetViewsEngine.baseLocationFormats;
            this.PartialViewLocationFormats = EventsWidgetViewsEngine.baseLocationFormats;
        }

        protected static readonly string[] baseLocationFormats = new string[] { "~/EventsWidgetViews/{0}.cshtml" };
        //protected static readonly string[] baseLocationFormats = new string[] { "~/EventsWidgetViews/{1}/{0}.cshtml" };
    }
}