using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyDogShow.SharedModels;

namespace HappyDogShow.Modules.Entries.ViewModels
{
    public class ExploreEntriesViewViewModel : ListViewViewModelBase<IBreedEntryEntityWithAdditionalData>, IExploreEntriesViewViewModel
    {
        private IBreedEntryService _service;

        public ExploreEntriesViewViewModel(IExploreEntriesView view, IBreedEntryService service) 
            : base(view)
        {
            _service = service;
        }

        public async override void Prepare()
        {
            Items.Clear();

            List<IBreedEntryEntityWithAdditionalData> items = await _service.GetBreedEntryListAsync<BreedEntryEntityWithAdditionalData>();

            items.ForEach(i => Items.Add(i));

        }
    }
}
