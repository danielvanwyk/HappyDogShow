using HappyDogShow.Infrastructure.WPF.Infrastructure;
using HappyDogShow.Modules.Entries.Infrastructure;
using System.Windows.Controls;

namespace HappyDogShow.Modules.Entries.Views
{
    /// <summary>
    /// Interaction logic for ExploreEntriesByClassView.xaml
    /// </summary>
    public partial class ExploreEntriesByClassView : UserControl, IExploreEntriesByClassView
    {
        public ExploreEntriesByClassView()
        {
            InitializeComponent();
        }

        public IViewViewModel ViewModel
        {
            get
            {
                return (IExploreEntriesByClassViewViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}
