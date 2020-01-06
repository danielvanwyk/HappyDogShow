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
    public class MultipleBreedEntryClassEntry : ValidatableBindableBase, IMultipleBreedEntryClassEntry
    {
        private ObservableCollection<IBreedEntryClassEntry> breedClassEntries;
        public ObservableCollection<IBreedEntryClassEntry> BreedClassEntries
        {
            get { return breedClassEntries; }
            set { SetProperty(ref breedClassEntries, value); }
        }

        public int Id { get; set; }

        public MultipleBreedEntryClassEntry()
        {
            BreedClassEntries = new ObservableCollection<IBreedEntryClassEntry>();
        }

        internal void NotifyEntriesChanged()
        {
            OnPropertyChanged("BreedClassEntries");
        }
    }
}
