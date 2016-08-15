using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Events.Model;
using Telerik.Sitefinity.Model;

namespace SitefinityWebApp.Mvc.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString GetEventTitle(this HtmlHelper helper, IDataItem item)
        {
            var eventItem = item as Event;
            string title = string.Empty;
            if (eventItem != null)
            {
                title = eventItem.Title;
            }

            return new MvcHtmlString("<div>event " + title + "</div>");
        }
    }
}