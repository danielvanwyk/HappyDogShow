using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IMultipleBreedEntry : IEntityWithID
    {
        ObservableCollection<IBreedEntryEntity> BreedEntries { get; set; }
    }
}
