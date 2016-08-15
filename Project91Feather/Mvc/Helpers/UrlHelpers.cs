using System.Web.Mvc;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Web.DataResolving;

namespace SitefinityWebApp.Mvc.Helpers
{
    public static class UrlHelpers
    {
        public static string ConstructSamePageUrl(this UrlHelper helper, IDataItem item)
        {
            var appRelativeUrl = DataResolver.Resolve(item, "URL");
            var url = UrlPath.ResolveUrl(appRelativeUrl, true);

            return url;
        }

        public static string ConstructDefaultItemUrl(this UrlHelper helper, IDataItem item)
        {
            string url = "#";
            if (item != null)
            {
                var service = SystemManager.GetContentLocationService();
                var defaultLocation = service.GetItemDefaultLocation(item);
                if (defaultLocation != null)
                {
                    url = defaultLocation.ItemAbsoluteUrl;
                }
            }

            return url;
        }
    }
}