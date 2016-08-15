using SitefinityWebApp.Mvc.Models.Fields.FormLogo;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Controllers.Base;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    public class FormLogoController : FormElementControllerBase<IFormLogoModel>
    {
        public FormLogoController()
        {
            this.DisplayMode = Telerik.Sitefinity.Web.UI.Fields.Enums.FieldDisplayMode.Read;
            // this.ReadTemplateName = "Default";
        }

        public override ActionResult Read(object value)
        {
            // return base.Read(value);
            return this.View(value, "Read.Default");
        }

        public override ActionResult Write(object value)
        {
            return this.Read(value);
        }

        public override IFormLogoModel Model
        {
            get 
            {
                return new FormLogoModel();
            }
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Read(null).ExecuteResult(this.ControllerContext);
        }
    }
}