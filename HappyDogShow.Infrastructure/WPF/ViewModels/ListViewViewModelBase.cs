using HappyDogShow.Infrastructure.WPF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.WPF.ViewModels
{
    public abstract class ListViewViewModelBase<T> : NavigateableBindableViewModelBase
    {
        private ObservableCollection<T> items;
        public ObservableCollection<T> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        private T selectedItem;
        public T SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
        }

        public ListViewViewModelBase(IView view)
            : base(view)
        {
            Items = new ObservableCollection<T>();
        }

    }
}
