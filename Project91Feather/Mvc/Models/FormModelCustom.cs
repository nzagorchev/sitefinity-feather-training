using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models;

namespace SitefinityWebApp.Mvc.Models
{
    public class FormModelCustom : FormModel
    {
        public override SubmitStatus TrySubmitForm(System.Web.Mvc.FormCollection collection, HttpFileCollectionBase files, string userHostAddress)
        {
            return base.TrySubmitForm(collection, files, userHostAddress);
        }

        public override string GetSubmitMessage(SubmitStatus submitedSuccessfully)
        {
            return base.GetSubmitMessage(submitedSuccessfully);
        }

        protected override bool IsValidForm(Telerik.Sitefinity.Forms.Model.FormDescription form, System.Web.Mvc.FormCollection collection, HttpFileCollectionBase files, Telerik.Sitefinity.Modules.Forms.FormsManager manager)
        {
            return base.IsValidForm(form, collection, files, manager);
        }

        protected override bool ValidateFormSubmissionRestrictions(Telerik.Sitefinity.Modules.Forms.FormsSubmitionHelper formsSubmition, Telerik.Sitefinity.Modules.Forms.FormEntryDTO formEntry)
        {
            // IP, Username or No Restiction by default
            return base.ValidateFormSubmissionRestrictions(formsSubmition, formEntry);
        }

        protected override bool RaiseFormSavingEvent(Telerik.Sitefinity.Modules.Forms.FormEntryDTO formEntry)
        {
            return base.RaiseFormSavingEvent(formEntry);
        }
    }
}