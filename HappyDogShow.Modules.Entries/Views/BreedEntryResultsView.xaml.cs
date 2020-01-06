using HappyDogShow.Infrastructure.WPF.Infrastructure;
using HappyDogShow.Modules.Entries.Infrastructure;
using System.Windows.Controls;

namespace HappyDogShow.Modules.Entries.Views
{
    /// <summary>
    /// Interaction logic for BreedEntryResultsView.xaml
    /// </summary>
    public partial class BreedEntryResultsView : UserControl, IBreedEntryResultsView
    {
        public BreedEntryResultsView()
        {
            InitializeComponent();
        }

        public IViewViewModel ViewModel
        {
            get
            {
                return (IBreedEntryResultsViewViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}