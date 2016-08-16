using SitefinityWebApp.Mvc.Models.Fields.FormDropdown;
using System.ComponentModel;
using Telerik.Sitefinity.Data.Metadata;
using Telerik.Sitefinity.Frontend.Forms;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Controllers.Base;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Pages.Web.Services;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "FormDropdown", Title = "FormDropdown", SectionName = "Common",
        Toolbox = FormsConstants.FormControlsToolboxName)]
    [DatabaseMapping(UserFriendlyDataType.LongText)]
    public class FormDropdownController : FormFieldControllerBase<IFormFieldModel>
    {
        public FormDropdownController()
        {
            this.DisplayMode = Telerik.Sitefinity.Web.UI.Fields.Enums.FieldDisplayMode.Write;
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ReflectInheritedProperties]
        public override IFormFieldModel Model
        {
            get
            {
                if (model == null)
                {
                    model = new FormDropdownModel();
                }
                return model;
            }
        }

        private IFormFieldModel model;
    }
}