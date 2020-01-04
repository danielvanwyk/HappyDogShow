using HappyDogShow.Infrastructure.WPF.Infrastructure;
using HappyDogShow.Modules.Handlers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HappyDogShow.Modules.Handlers.Views
{
    /// <summary>
    /// Interaction logic for ExploreHandlersView.xaml
    /// </summary>
    public partial class ExploreHandlersView : UserControl, IExploreHandlersView
    {
        public ExploreHandlersView()
        {
            InitializeComponent();
        }

        public IViewViewModel ViewModel
        {
            get
            {
                return (IExploreHandlersViewViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}
