using SitefinityWebApp.Mvc.Infrastructure;
using SitefinityWebApp.Mvc.Model.Fields.TextField;
using SitefinityWebApp.Mvc.Models;
using SitefinityWebApp.Utilities;
using System;
using System.Web.Mvc;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.Events.Mvc.Models;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.TextField;
using Telerik.Sitefinity.Frontend.Navigation.Mvc.Models;
using Telerik.Sitefinity.Modules.Forms.Events;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Initialized += Bootstrapper_Initialized;
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;

            ViewEngines.Engines.Add(new EventsWidgetViewsEngine());
        }

        protected void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
        {
            if (e.CommandName == "Bootstrapped")
            {
                // Classic MVC routing
                System.Web.Mvc.RouteCollectionExtensions.MapRoute(System.Web.Routing.RouteTable.Routes,
                 "Classic",
                 "classic-mvc/{controller}/{action}/{id}",
                 new { controller = "Feature", action = "Index", id = (string)null }); // or id = UrlParameter.Optional

                // Form Saving Event
                EventHub.Subscribe<FormSavingEvent>(FormEventHandlers.FormSavingEvent);
            }
        }

        protected void Bootstrapper_Bootstrapped(object sender, EventArgs e)
        {
            // Override the IControllerActionInvoker
            ObjectFactory.Container.RegisterType<IControllerActionInvoker, FeatherActionInvokerCustom>();
            // Resolve invoker
            var invoker = ObjectFactory.Container.Resolve<IControllerActionInvoker>();

            // Override Events Widget Model
            FrontendModule.Current.DependencyResolver.Rebind<IEventModel>().To<EventModelCustom>();

            // Override Navigation Widget Model
            FrontendModule.Current.DependencyResolver.Rebind<INavigationModel>().To<NavigationModelCustom>();

            // Override Text Field Model
            FrontendModule.Current.DependencyResolver.Rebind<ITextFieldModel>().To<TextFieldModelCustom>();

            // Override Text Field Model
            FrontendModule.Current.DependencyResolver.Rebind<IFormModel>().To<FormModelCustom>();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}