using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;

namespace HappyDogShow.SharedModels
{
    public class BreedDetail : ValidatableBindableBase, IBreedEntity
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }


    }
}
