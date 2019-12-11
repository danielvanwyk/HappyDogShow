using HappyDogShow.Infrastructure.ViewModels;

namespace HappyDogShow.Infrastructure.Extensions
{
    public static class BusyAwareViewModelExtensions
    {
        public static void MarkAsBusy(this IBusyAwareViewModel vm)
        {
            vm.IsBusy = true;
        }

        public static void MarkAsNotBusy(this IBusyAwareViewModel vm)
        {
            vm.IsBusy = false;
        }
    }
}
