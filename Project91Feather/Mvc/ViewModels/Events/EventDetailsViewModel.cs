using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Frontend.Mvc.Models;

namespace SitefinityWebApp.Mvc.ViewModels.Events
{
    public class EventDetailsViewModel : ContentDetailsViewModel
    {
        public DateTime CurrentTime { get; set; }
    }
}