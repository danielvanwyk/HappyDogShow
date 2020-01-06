using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IMultipleBreedEntryClassEntry : IEntityWithID
    {
        ObservableCollection<IBreedEntryClassEntry> BreedClassEntries { get; set; }
    }
}
