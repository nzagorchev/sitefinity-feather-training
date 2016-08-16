using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Taxonomies.Model;

namespace SitefinityWebApp.Utilities
{
    public static class QueryFilters<T> where T : Content
    {
        public static Expression<Func<T, bool>> liveAndVisibleFilter
        {
            get
            {
                return im => im.Status == ContentLifecycleStatus.Live && im.Visible;
            }
        }
    }

    public static class QueryFiltersDynamicContent
    {
        public static Expression<Func<DynamicContent, bool>> liveAndVisibleFilterDynamicContent
        {
            get
            {
                return im => im.Status == ContentLifecycleStatus.Live && im.Visible;
            }
        }
    }

    public static class TaxaFilter
    {
        internal static string GetTaxaFieldName(Guid taxonomyId, Type contentType)
        {
            string taxonomyFieldName = string.Empty;

            var taxonomyPropertyDescriptor = FieldHelper.GetFields(contentType)
                                                        .OfType<TaxonomyPropertyDescriptor>()
                                                        .FirstOrDefault(t => t.TaxonomyId == taxonomyId);

            if (taxonomyPropertyDescriptor != null)
            {
                taxonomyFieldName = taxonomyPropertyDescriptor.Name;
            }

            return taxonomyFieldName;
        }

        public static string GetTaxaFilter(ITaxon taxon, Type contentType)
        {
            string filter = string.Empty;

            if (taxon != null)
            {
                var taxonomy = taxon.Taxonomy.RootTaxonomy ?? taxon.Taxonomy;

                string taxonomyField = TaxaFilter.GetTaxaFieldName(taxonomy.Id, contentType);

                if (!string.IsNullOrEmpty(taxonomyField))
                {
                    filter = string.Format(CultureInfo.InvariantCulture, "{0}.Contains({{{1}}})", taxonomyField, taxon.Id);
                }
            }

            return filter;
        }
    }
}