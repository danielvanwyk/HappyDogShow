using HappyDogShow.Infrastructure.WPF.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.WPF.ViewModels
{
    public abstract class NavigateableBindableViewModelBase : BindableViewModelBase, INavigationAware, IConfirmNavigationRequest
    {
        public NavigateableBindableViewModelBase(IView view)
            : base(view)
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            SaveStateBeforeNavigatingAway();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            GetValuesFromNavigationParameters(navigationContext);
            Prepare();
            RestoreStateAfterNavigatingTo();
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            if (IsBusy)
                continuationCallback(false);
            else
                continuationCallback(true);
            // to do for later:  plug in something here to check if something is dirty and then warn the user
        }

        public virtual void GetValuesFromNavigationParameters(NavigationContext navigationContext)
        {
        }

        public virtual void Prepare()
        {
        }

        public virtual void SaveStateBeforeNavigatingAway()
        {

        }

        public virtual void RestoreStateAfterNavigatingTo()
        {

        }
    }
}
