using SitefinityWebApp.Mvc.ViewModels.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Frontend.Navigation.Mvc.Models;

namespace SitefinityWebApp.Mvc.Models
{
    public class NavigationModelCustom : NavigationModel
    {
        public NavigationModelCustom()
            : base()
        {
        }

        public NavigationModelCustom(PageSelectionMode selectionMode, Guid selectedPageId, SelectedPageModel[] selectedPages, int? levelsToInclude, bool showParentPage, string cssClass, bool openExternalPageInNewTab)
            : base(selectionMode, selectedPageId, selectedPages, levelsToInclude, showParentPage, cssClass, openExternalPageInNewTab)
        {
        }

        protected override NodeViewModel InstantiateNodeViewModel(SiteMapNode node)
        {
            bool isSelectedPage = this.CurrentSiteMapNode != null && this.CurrentSiteMapNode.Key == node.Key;
            string url = this.ResolveUrl(node);
            string target = this.GetLinkTarget(node);
            var hasSelectedChild = this.CurrentSiteMapNode != null && this.CurrentSiteMapNode.IsDescendantOf(node);

            return new NodeViewModelCustom(node, url, target, isSelectedPage, hasSelectedChild);
        }

        protected override NodeViewModel InstantiateNodeViewModel(string url, string target)
        {
            return new NodeViewModelCustom(null, url, target, false, false);
        }
    }
}