using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.Models
{
    public class MultipleBreedEntry : ValidatableBindableBase, IMultipleBreedEntry
    {
        private ObservableCollection<IBreedEntryEntity> breedEntries;
        public ObservableCollection<IBreedEntryEntity> BreedEntries
        {
            get { return breedEntries; }
            set { SetProperty(ref breedEntries, value); }
        }

        public int Id { get; set; }

        public MultipleBreedEntry()
        {
            BreedEntries = new ObservableCollection<IBreedEntryEntity>();
        }

        internal void NotifyEntriesChanged()
        {
            OnPropertyChanged("BreedEntries");
        }
    }
}
