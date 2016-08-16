using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.TextField;
using Telerik.Sitefinity.Metadata.Model;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;

namespace SitefinityWebApp.Mvc.Model.Fields.TextField
{
    public class TextFieldModelCustom : TextFieldModel
    {
        public override bool IsValid(object value)
        {
            string valAsString = value as string;
            if (string.IsNullOrEmpty(valAsString))
            {
                // Custom Server Side Validation
            }

            return base.IsValid(value);
        }

        public override object GetViewModel(object value, IMetaField metaField)
        {
            return base.GetViewModel(value, metaField);
        }

        public override IMetaField GetMetaField(IFormFieldControl formFieldControl)
        {
            return base.GetMetaField(formFieldControl);
        }
    }
}