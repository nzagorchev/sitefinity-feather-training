using System.Collections.Generic;
using Telerik.Sitefinity.News.Model;

namespace SitefinityWebApp.Mvc.ViewModels.News
{
    public class ListViewModel
    {
        public IEnumerable<NewsItem> Items { get; set; }
    }
}