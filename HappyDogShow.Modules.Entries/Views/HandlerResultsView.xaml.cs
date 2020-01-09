using HappyDogShow.Infrastructure.WPF.Infrastructure;
using HappyDogShow.Modules.Entries.Infrastructure;
using System.Windows.Controls;

namespace HappyDogShow.Modules.Entries.Views
{
    /// <summary>
    /// Interaction logic for HandlerResultsView.xaml
    /// </summary>
    public partial class HandlerResultsView : UserControl, IHandlerResultsView
    {
        public HandlerResultsView()
        {
            InitializeComponent();
        }

        public IViewViewModel ViewModel
        {
            get
            {
                return (IHandlerResultsViewViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}