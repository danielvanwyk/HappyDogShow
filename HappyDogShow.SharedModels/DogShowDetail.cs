using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class DogShowDetail : ValidatableBindableBase, IDogShowEntity
    {
        public int Id { get; set; }

        private string dogShowName;
        [Required()]
        public string DogShowName
        {
            get { return dogShowName; }
            set { SetProperty(ref dogShowName, value); }
        }

        private DateTime showDate;
        [Required()]
        public DateTime ShowDate
        {
            get { return showDate; }
            set { SetProperty(ref showDate, value); }
        }

        private string venue;
        [Required()]
        public string Venue
        {
            get { return venue; }
            set { SetProperty(ref venue, value); }
        }

        public string ShowDateAsString
        {
            get { return ShowDate.ToString("yyyy-MM-dd"); }
        }

        public DogShowDetail()
        {
            ShowDate = DateTime.Now;
            MarkEntityAsClean();
        }
    }
}
