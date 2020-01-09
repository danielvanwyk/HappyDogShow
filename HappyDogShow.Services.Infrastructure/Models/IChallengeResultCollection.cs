using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IChallengeResultCollection<T> : IEntityWithID
        where T : IChallengeResult
    {
        ObservableCollection<T> Results { get; set; }
    }
}
