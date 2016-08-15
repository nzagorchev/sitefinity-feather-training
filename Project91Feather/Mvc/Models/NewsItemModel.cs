using SitefinityWebApp.Utilities;
using System.Linq;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.News.Model;

namespace SitefinityWebApp.Mvc.Models
{
    public class NewsItemModel
    {
        public string ProviderName { get; set; }

        public string ModelMessage { get; set; }

        public System.Type ContentType
        {
            get 
            {
                return typeof(NewsItem);
            }
        }

        public IQueryable<NewsItem> GetNewsItems()
        {
            var manager = NewsManager.GetManager(ProviderName);

            var news = manager.GetNewsItems()
                .Where(QueryFilters<NewsItem>.liveAndVisibleFilter);

            return news;
        }
    }
}