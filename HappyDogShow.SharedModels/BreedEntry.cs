using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class BreedEntry : ValidatableBindableBase, IBreedEntryEntity
    {
        public int Id { get; set; }

        private int showId;
        public int ShowId
        {
            get { return showId; }
            set { SetProperty(ref showId, value); }
        }

        private List<IBreedClassEntryEntityWithClassDetailForSelection> classes;
        public List<IBreedClassEntryEntityWithClassDetailForSelection> Classes
        {
            get { return classes; }
            set { SetProperty(ref classes, value); }
        }

        private IDogRegistration dog;
        public IDogRegistration Dog
        {
            get { return dog; }
            set { SetProperty(ref dog, value); }
        }

        private IDogShowEntity dogShow;
        public IDogShowEntity DogShow
        {
            get { return dogShow; }
            set { SetProperty(ref dogShow, value); }
        }

        public int DogAgeInMonthsAtTimeOfShow
        {
            get
            {
                return Dog.DateOfBirth.DiffMonths(DogShow.ShowDate);
            }
        }

    }
    public static class DateTimeExtensions
    {
        public static Int32 DiffMonths(this DateTime start, DateTime end)
        {
            Int32 months = 0;
            DateTime tmp = start.AddMonths(1);

            while (tmp < end)
            {
                months++;
                tmp = tmp.AddMonths(1);
            }

            return months;
        }
    }
}
