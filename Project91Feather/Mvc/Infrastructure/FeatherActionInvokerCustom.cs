using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Routing;

namespace SitefinityWebApp.Mvc.Infrastructure
{
    public class FeatherActionInvokerCustom : FeatherActionInvoker
    {
        protected override void InitializeRouteParameters(Telerik.Sitefinity.Mvc.Proxy.MvcProxyBase proxyControl)
        {
            base.InitializeRouteParameters(proxyControl);
        }

        protected override void RestoreHttpContext(string output, System.Web.HttpContext initialContext)
        {
            try
            {
                var context = System.Web.HttpContext.Current;

                var keys = context.Items.Keys.Cast<object>().ToArray();

                var headerKeys = keys.Where(k => k != null && k.ToString().StartsWith(headerItemPrefix)).ToList();

                foreach (var key in headerKeys)
                {
                    string stringKey = key.ToString();
                    var data = context.Items[stringKey];
                    if (data != null)
                    {
                        // Adds or updates the header
                        string actualHeader = stringKey.Substring(headerItemPrefix.Length, stringKey.Length - headerItemPrefix.Length);
                        initialContext.Response.Headers[actualHeader] = data.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, ConfigurationPolicy.ErrorLog);
            }

            base.RestoreHttpContext(output, initialContext);
        }

        public static readonly string headerItemPrefix = "Header-";
    }
}
