using SitefinityWebApp.Mvc.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Web;
using Telerik.Sitefinity.Frontend.Events.Mvc.Models;
using Telerik.Sitefinity.Frontend.Mvc.Models;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Events.Model;

namespace SitefinityWebApp.Mvc.Models
{
    public class EventModelCustom : EventModel
    {
        protected override ContentDetailsViewModel CreateDetailsViewModelInstance()
        {
            return new EventDetailsViewModel();
        }

        public override ContentDetailsViewModel CreateDetailsViewModel(IDataItem item)
        {
            var @base = base.CreateDetailsViewModel(item);

            var vm = @base as EventDetailsViewModel;

            if (vm != null)
            {
                vm.CurrentTime = DateTime.Now;
            }

            return @base;
        }

        protected override IQueryable<IDataItem> UpdateExpression(IQueryable<IDataItem> query, int? skip, int? take, ref int? totalCount)
        {
            query = query
                .Cast<Event>()
                .Where(e=> e.GetValue<string>("AdditionalInfo") != null && e.GetValue<string>("AdditionalInfo") != "");

            return base.UpdateExpression(query, skip, take, ref totalCount);
        }
    }
}