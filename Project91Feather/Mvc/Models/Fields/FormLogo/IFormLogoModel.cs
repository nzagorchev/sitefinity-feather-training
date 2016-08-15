using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields;

namespace SitefinityWebApp.Mvc.Models.Fields.FormLogo
{
    public interface IFormLogoModel : IFormElementModel
    {
        string ImageUrl { get; set; }

        string AltText { get; set; }
    }
}