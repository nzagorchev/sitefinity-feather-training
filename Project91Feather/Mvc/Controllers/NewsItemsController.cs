using SitefinityWebApp.Mvc.ActionFilters;
using SitefinityWebApp.Mvc.Models;
using SitefinityWebApp.Mvc.ViewModels.News;
using SitefinityWebApp.Utilities;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.ContentLocations;
using Telerik.Sitefinity.Data.Linq.Dynamic;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.News.Model;
using Telerik.Sitefinity.Taxonomies.Model;

namespace SitefinityWebApp.Mvc.Controllers
{
    [MyActionFilter]
    [ControllerToolboxItem(Name = "NewsItems", Title = "NewsItems", SectionName = "MvcWidgets")]
    public class NewsItemsController : Controller, IContentLocatableView
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [Category("String Properties")]
        public string Message { get; set; }

        public bool? DisableCanonicalUrlMetaTag
        {
            get;
            set;
        }

        private NewsItemModel model;

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public NewsItemModel Model
        {
            get
            {
                if (model == null)
                {
                    model = new NewsItemModel();
                }

                return model;
            }
            set { model = value; }
        }

        /// <summary>
        /// This is the default Action.
        /// </summary>
        public ActionResult Index(int? page)
        {
            var model = new NewsItemModel();
            var items = model.GetNewsItems().ToList();

            var viewModel = new ListViewModel();
            viewModel.Items = items;

            var pageUrl = this.GetCurrentPageUrl();

            ViewBag.PageUrl = pageUrl;

            return View("Default", viewModel);
        }

        public ActionResult Details(NewsItem item)
        {
            var viewModel = new DetailsViewModel();
            viewModel.Item = item;

            return View("Details", viewModel);
        }

        public ActionResult ListByTaxon(ITaxon taxonFilter, int? page)
        {
            var model = new NewsItemModel();
            var items = model.GetNewsItems();

            var filter = TaxaFilter.GetTaxaFilter(taxonFilter, this.Model.ContentType);
            if (!string.IsNullOrEmpty(filter))
            {
                items = items.Where(filter);
            }

            var viewModel = new ListViewModel();
            viewModel.Items = items;

            return View("Default", viewModel);
        }

        public ActionResult MyDetails(string itemUrl)
        {
            // Process the item Url (shows the advantage of the OTB Details action that maps the item)

            var viewModel = new DetailsViewModel();

            return View("Details", viewModel);
        }

        public System.Collections.Generic.IEnumerable<IContentLocationInfo> GetLocations()
        {
            var location = new ContentLocationInfo();
            location.ContentType = this.Model.ContentType;
            if (string.IsNullOrEmpty(this.Model.ProviderName))
            {
                location.ProviderName = "OpenAccessDataProvider";                
            }
            else
            {
                location.ProviderName = this.Model.ProviderName;
            }

            return new[] { location };
        }
    }
}