using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Modules.Pages;

namespace SitefinityWebApp
{
    public partial class QueryTemplatesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = PageManager.GetManager();

            var pureMvcTemplates = manager.GetTemplates()
                .Where(t => t.Framework == Telerik.Sitefinity.Pages.Model.PageTemplateFramework.Mvc)
                .ToList();

            var bootstrapTemplates = pureMvcTemplates
                .Where(t => t.Name.ToLowerInvariant().StartsWith("bootstrap."))
                .Select(t => t.Title)
                .ToList();
        }
    }
}