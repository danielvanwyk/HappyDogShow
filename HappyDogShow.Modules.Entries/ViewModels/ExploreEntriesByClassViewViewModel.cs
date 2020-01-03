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
    public class ExploreEntriesByClassViewViewModel : ListViewViewModelBase<IBreedEntryClassEntry>, IExploreEntriesByClassViewViewModel
    {
        private IBreedEntryService _service;

        public ExploreEntriesByClassViewViewModel(IExploreEntriesByClassView view, IBreedEntryService service)
            : base(view)
        {
            _service = service;
        }

        public async override void Prepare()
        {
            Items.Clear();

            List<IBreedEntryClassEntry> items = await _service.GetBreedEntryClassEntryListAsync<BreedEntryClassEntry>();

            items.ForEach(i => Items.Add(i));

        }
    }
}
