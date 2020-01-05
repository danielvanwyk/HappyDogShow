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
    public class MultipleHandlerEntry : ValidatableBindableBase, IMultipleHandlerEntry
    {
        private ObservableCollection<IHandlerEntryEntity> handlerEntries;
        public ObservableCollection<IHandlerEntryEntity> HandlerEntries
        {
            get { return handlerEntries; }
            set { SetProperty(ref handlerEntries, value); }
        }

        public int Id { get; set; }

        public MultipleHandlerEntry()
        {
            HandlerEntries = new ObservableCollection<IHandlerEntryEntity>();
        }

        internal void NotifyEntriesChanged()
        {
            OnPropertyChanged("HandlerEntries");
        }
    }
}
