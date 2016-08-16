using System.Web;
using System.Web.Mvc;
using System.Linq;
using Telerik.Sitefinity.Forms.Model;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models;
using Telerik.Sitefinity.Modules.Forms;

namespace SitefinityWebApp.Mvc.Models
{
    public class FormModelCustom : FormModel
    {
        public override SubmitStatus TrySubmitForm(FormCollection collection, HttpFileCollectionBase files, string userHostAddress)
        {
            return base.TrySubmitForm(collection, files, userHostAddress);
        }

        public override string GetSubmitMessage(SubmitStatus submitedSuccessfully)
        {
            string formTitle = this.FormData.Title;
            if (formTitle == "form1")
            {
                if (submitedSuccessfully == SubmitStatus.Success)
                {
                    // TODO: Use Resource label
                    return "Thank you for submitting your feedback.";
                }
            }

            return base.GetSubmitMessage(submitedSuccessfully);
        }

        protected override bool IsValidForm(FormDescription form, FormCollection collection, HttpFileCollectionBase files, FormsManager manager)
        {
            // Validate files
            // Validate form field inputs

            if (form.Title == "form1")
            {
                // Use the FieldName if there are more controls of that type
                // Can be found in Designer -> Advanced -> Model -> MetaField -> FieldName
                string formDropdownFieldName = "FormDropdownController";
                // Get the first control with the name from the collection
                var key = collection.AllKeys.Where(f => f.StartsWith(formDropdownFieldName)).FirstOrDefault();
                if (!string.IsNullOrEmpty(key))
                {
                    string dropdownValue = collection[key];
                }
            }

            return base.IsValidForm(form, collection, files, manager);
        }

        protected override bool ValidateFormSubmissionRestrictions(FormsSubmitionHelper formsSubmition, FormEntryDTO formEntry)
        {
            // IP, Username or No Restiction by default
            return base.ValidateFormSubmissionRestrictions(formsSubmition, formEntry);
        }

        protected override bool RaiseFormSavingEvent(FormEntryDTO formEntry)
        {
            /// <seealso cref="SitefinityWebApp.Utilities.FormEventHandlers.FormSavingEvent"/>
            var formsData = formEntry.PostedData.FormsData;
            var files = formEntry.PostedData.Files;

            return base.RaiseFormSavingEvent(formEntry);
        }
    }
}