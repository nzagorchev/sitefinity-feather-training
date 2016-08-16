using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields;
using Telerik.Sitefinity.Metadata.Model;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;
using Telerik.Sitefinity.Utilities.TypeConverters;
using SitefinityWebApp.Utilities;
using Telerik.Sitefinity.Model;

namespace SitefinityWebApp.Mvc.Models.Fields.FormDropdown
{
    public class FormDropdownModel : FormFieldModel, IFormFieldModel
    {
        private string providerName;

        public string ProviderName
        {
            get { return providerName; }
            set { providerName = value; }
        }

        private string dynamicItemsType;

        public string DynamicItemsType
        {
            get
            {
                if (string.IsNullOrEmpty(dynamicItemsType))
                {
                    dynamicItemsType = conferencesType;
                }
                return dynamicItemsType;
            }
            set { dynamicItemsType = value; }
        }

        public override IMetaField GetMetaField(IFormFieldControl formFieldControl)
        {
            var metaField = base.GetMetaField(formFieldControl);
            return metaField;
        }

        public override object GetViewModel(object value, IMetaField metaField)
        {
            var viewModel = new FormDropdownViewModel();
            viewModel.Value = value;
            viewModel.Items = this.GetDropdownItems();
            viewModel.FieldName = this.MetaField.FieldName;
            viewModel.ValidationAttributes = "required='required'";
            viewModel.FieldTitle = this.MetaField.Title != null ? this.MetaField.Title : "Dropdown";

            return viewModel;
        }

        public virtual Dictionary<string, string> GetDropdownItems()
        {
            var items = this.GetDynamicContentItems();
            var dropdownItems = new Dictionary<string, string>();
            foreach (var item in items)
            {
                dropdownItems.Add(item.Id.ToString(), ((IHasTitle)item).GetTitle());
            }

            return dropdownItems;
        }

        internal IQueryable<DynamicContent> GetDynamicContentItems()
        {
            var manager = DynamicModuleManager.GetManager(this.ProviderName);
            Type conferenceType = TypeResolutionService.ResolveType(this.DynamicItemsType);
            var items = manager.GetDataItems(conferenceType)
                .Where(QueryFiltersDynamicContent.liveAndVisibleFilterDynamicContent);

            return items;
        }

        public override bool IsValid(object value)
        {
            // TODO: add validation
            return true;
        }

        protected static readonly string conferencesType = "Telerik.Sitefinity.DynamicTypes.Model.Conferences.Conference";
    }
}