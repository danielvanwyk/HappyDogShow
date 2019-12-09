using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Entries.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.ViewModels
{
    public class CaptureNewEntryViewViewModel : BindableViewModelBase, ICaptureNewEntryViewViewModel, INavigationAware
    {
        private List<string> testItems;
        public List<string> TestItems
        {
            get { return testItems; }
            set { SetProperty(ref testItems, value); }
        }
        public CaptureNewEntryViewViewModel(ICaptureNewEntryView view) : base(view)
        {
            TestItems = new List<string>();
            TestItems.Add("ZA010784B16");
            TestItems.Add("ZA010785B16");
            TestItems.Add("ZA010784B17");

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
}
