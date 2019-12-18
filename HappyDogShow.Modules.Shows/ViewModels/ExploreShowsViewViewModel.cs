using HappyDogShow.Data;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Shows.Infrastructure;
using HappyDogShow.Modules.Shows.Models;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.ViewModels
{
    public class ExploreShowsViewViewModel : ListViewViewModelBase<IDogShowEntity>, IExploreShowsViewViewModel
    {
        private IDogShowService _service;

        public ExploreShowsViewViewModel(IExploreShowsView view, IDogShowService service) 
            : base(view)
        {
            _service = service;
        }

        public async override void Prepare()
        {
            Items.Clear();

            List<IDogShowEntity> items = await _service.GetDogShowListAsync<DogShowDetail>();

            items.ForEach(i => Items.Add(i));

        }
    }
}
