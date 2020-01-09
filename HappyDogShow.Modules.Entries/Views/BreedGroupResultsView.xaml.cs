using HappyDogShow.Infrastructure.WPF.Infrastructure;
using HappyDogShow.Modules.Entries.Infrastructure;
using System.Windows.Controls;

namespace HappyDogShow.Modules.Entries.Views
{
    /// <summary>
    /// Interaction logic for BreedGroupResultsView.xaml
    /// </summary>
    public partial class BreedGroupResultsView : UserControl, IBreedGroupResultsView
    {
        public BreedGroupResultsView()
        {
            InitializeComponent();
        }

        public IViewViewModel ViewModel
        {
            get
            {
                return (IBreedGroupResultsViewViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}