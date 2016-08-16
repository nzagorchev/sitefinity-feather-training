using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models
{
    public interface IWidgetWithDesignerModel
    {
        string Summary { get; set; }
        
        string Description { get; set; }
        
        string Header { get; set; }
    }
}