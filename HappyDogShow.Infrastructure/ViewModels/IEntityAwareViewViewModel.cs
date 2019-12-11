using HappyDogShow.Infrastructure.Models;

namespace HappyDogShow.Infrastructure.ViewModels
{
    public interface IEntityAwareViewViewModel : IBusyAwareViewModel
    {
        ValidatableBindableBase CurrentEntity { get; set; }
    }
}
