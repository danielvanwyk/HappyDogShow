using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class BreedClassEntryEntityWithClassDetailForSelection : ValidatableBindableBase, IBreedClassEntryEntityWithClassDetailForSelection
    {
        public int ID { get; set; }
        public int BreedClassID { get; set; }
        public string BreedClassName { get; set; }
        public string BreedClassDescription { get; set; }
        public int MinAgeInMonths { get; set; }
        public int MaxAgeInMonths { get; set; }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set { SetProperty(ref isSelected, value); }
        }

        public bool IsOutOfAgeRange { get; set; }
    }
}
