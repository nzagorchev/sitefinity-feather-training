using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Frontend;

namespace SitefinityWebApp
{
    public partial class RestoreDefaultTemplatesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Button1.Click += Button1_Click;
        }

        public virtual void Button1_Click(object sender, EventArgs e)
        {
            RestoreDefaultTemplates();
        }

        public void RestoreDefaultTemplates()
        {
            // Force upgrade
            var siteInitializer = SiteInitializer.GetInitializer();
            FrontendModule.Current.Upgrade(siteInitializer, new Version("1.2.280.2"));
        }
    }
}