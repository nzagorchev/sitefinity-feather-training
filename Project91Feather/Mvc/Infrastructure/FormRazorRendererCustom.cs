using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using Telerik.Sitefinity.Frontend.Forms;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Helpers;

namespace SitefinityWebApp.Mvc.Infrastructure
{
    public class FormRazorRendererCustom : FormRazorRenderer
    {
        // The method implementation is copied from the default FormRazorRenderer. This code requires maintainance on Feather Upgrades
        public override void Render(System.IO.StreamWriter writer, Telerik.Sitefinity.Forms.Model.FormDescription form)
        {
            var formTitle = form.Title;
            var virtualPath = "~/Frontend-Assembly/Telerik.Sitefinity.Frontend.Forms/Mvc/Views/Form/Index.cshtml";

            // Start custom code
            if (formTitle == "form1")
            {
                virtualPath = "~/Frontend-Assembly/SitefinityWebApp/Mvc/Views/Form/MyIndex.cshtml";
            }
            // End custom code

            string formIndexView;
            using (StreamReader reader = new StreamReader(HostingEnvironment.VirtualPathProvider.GetFile(virtualPath).Open()))
            {
                formIndexView = reader.ReadToEnd();
            }

            var formControlsArray = form.Controls.ToArray();
            var isMultiPageForm = formControlsArray.Any(c => (c.GetControlType().ImplementsInterface(typeof(IFormPageBreak))));
            StringBuilder formControlsMarkup = new StringBuilder();
            formControlsMarkup.Append(this.GetFieldsMarkup("Body", formControlsArray));

            if (isMultiPageForm)
            {
                this.FormMultipageDecorator.WrapFormPage(formControlsMarkup);
            }

            formControlsMarkup.Insert(0, this.GetFieldsMarkup("Header", formControlsArray));
            formControlsMarkup.Append(this.GetFieldsMarkup("Footer", formControlsArray));

            var result = formIndexView.Replace("@* Fields Markup *@", formControlsMarkup.ToString());
            writer.Write(result);
        }
    }
}