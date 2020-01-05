using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using HappyDogShow.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.ViewModels
{
    public class ExploreHandlerEntriesViewViewModel : ListViewViewModelBase<IHandlerEntryEntityWithAdditionalData>, IExploreHandlerEntriesViewViewModel
    {
        private IHandlerEntryService _service;

        public ExploreHandlerEntriesViewViewModel(IExploreEntriesView view, IHandlerEntryService service)
            : base(view)
        {
            _service = service;
        }

        public async override void Prepare()
        {
            Items.Clear();

            List<IHandlerEntryEntityWithAdditionalData> items = await _service.GetHandlerEntryListAsync<HandlerEntryEntityWithAdditionalData>();

            items.ForEach(i => Items.Add(i));

        }
    }
}
