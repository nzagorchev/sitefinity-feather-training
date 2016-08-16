namespace SitefinityWebApp.Mvc.Models
{
    public class WidgetWithDesignerModel : IWidgetWithDesignerModel
    {
        // Message is not part of the IWidgetWithDesignerModel
        // The Controller Model relies on the IWidgetWithDesignerModel interface -> this Message property cannot be set from the Designer OTB
        public string Message { get; set; }

        public string Summary
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Header
        {
            get;
            set;
        }
    }
}