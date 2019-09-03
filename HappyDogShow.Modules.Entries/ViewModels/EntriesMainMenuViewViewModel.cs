using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Entries.Infrastructure;

namespace HappyDogShow.Modules.Entries.ViewModels
{
    class EntriesMainMenuViewViewModel : BindableViewModelBase, IEntriesMainMenuViewViewModel
    {
        public EntriesMainMenuViewViewModel(IEntriesMainMenuView view) : base(view)
        {
        }
    }
}
