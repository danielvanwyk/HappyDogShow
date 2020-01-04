using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Handlers.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using HappyDogShow.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Handlers.ViewModels
{
    public class ExploreHandlersViewViewModel : ListViewViewModelBase<IHandlerRegistration>, IExploreHandlersViewViewModel
    {
        private IHandlerRegistrationService _service;

        public IHandlerRegistration SelectedHandlerRegistration
        {
            get { return SelectedItem; }
        }

        public ExploreHandlersViewViewModel(IExploreHandlersView view, IHandlerRegistrationService service)
            : base(view)
        {
            _service = service;
        }

        public async override void Prepare()
        {
            Items.Clear();

            List<IHandlerRegistration> items = await _service.GetListAsync<HandlerRegistrationDetail>();

            items.ForEach(i => Items.Add(i));
        }
    }
}
