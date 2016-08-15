using System;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Frontend.Navigation.Mvc.Models;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.RelatedData;

namespace SitefinityWebApp.Mvc.ViewModels.Navigation
{
    public class NodeViewModelCustom : NodeViewModel
    {
        public NodeViewModelCustom(SiteMapNode node, string url, string target, bool isSelectedPage, bool hasSelectedChild)
            : base(node, url, target, isSelectedPage, hasSelectedChild)
        {
            var image = this.GetImage();
            if (image != null)
            {
                this.ImageTitle = image.Title;
                this.ImageUrl = image.ThumbnailUrl;
            }
        }

        protected virtual Image GetImage()
        {
            Image image = null;
            try
            {
                var id = new Guid(this.OriginalSiteMapNode.Key);
                var manager = PageManager.GetManager();
                var node = manager.GetPageNode(id);
                image = node.GetRelatedItems<Image>("Image").FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Write(ex, ConfigurationPolicy.ErrorLog);
            }

            return image;
        }

        public string ImageUrl { get; set; }

        public string ImageTitle { get; set; }
    }
}