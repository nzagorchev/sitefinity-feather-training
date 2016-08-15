using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields;

namespace SitefinityWebApp.Mvc.Models.Fields.FormLogo
{
    public class FormLogoModel : FormElementModel, IFormLogoModel
    {
        public string ImageUrl
        {
            get 
            {
                if (string.IsNullOrEmpty(imageUrl))
                {
                    // TODO: Resolve from images
                    imageUrl = "/progress-logo-reversed.svg";
                }
                return imageUrl; 
            }
            set { imageUrl = value; }
        }

        public string AltText
        {
            get 
            {
                if (string.IsNullOrEmpty(altText))
                {
                    altText = "Logo";
                }
                return altText;
            }
            set { altText = value; }
        }   

        public override object GetViewModel(object value)
        {
            var viewModel = new FormLogoViewModel();
            viewModel.ImageUrl = this.ImageUrl;
            viewModel.AltText = this.AltText;

            return viewModel;
        }

        private string imageUrl;
        private string altText;
    }
}