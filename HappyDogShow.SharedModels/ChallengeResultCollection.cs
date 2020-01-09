using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class ChallengeResultCollection<T> : ValidatableBindableBase, IChallengeResultCollection<T> where T : IChallengeResult
    {
        public ObservableCollection<T> Results { get; set; }

        public ChallengeResultCollection()
        {
            Results = new ObservableCollection<T>();
        }
    }
}
