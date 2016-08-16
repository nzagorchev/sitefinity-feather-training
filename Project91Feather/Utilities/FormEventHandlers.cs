using System.Linq;
using Telerik.Sitefinity.Modules.Forms.Events;
using Telerik.Sitefinity.Services.Events;

namespace SitefinityWebApp.Utilities
{
    public class FormEventHandlers
    {
        internal static void FormSavingEvent(FormSavingEvent @event)
        {
            if (@event.FormTitle == "form1")
            {
                var formEntryControls = @event.Controls;
                // Specific field name
                // Can be found in Designer -> Advanced -> Model -> MetaField -> FieldName
                string fieldName = "FormDropdownController_0";
                var formDropdownField = formEntryControls
                    .Where(f => f.FieldName == fieldName)
                    .FirstOrDefault();

                if (formDropdownField != null)
                {
                    var value = formDropdownField.Value;

                    // Cancel the event if needed
                    // throw new CancelationException();
                }
            }
        }
    }
}