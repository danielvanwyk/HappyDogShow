using HappyDogShow.Infrastructure.WPF.Infrastructure;
using HappyDogShow.Modules.Shows.Infrastructure;
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

namespace HappyDogShow.Modules.Shows.Views
{
    /// <summary>
    /// Interaction logic for MassUpdateHandlerNumbersView.xaml
    /// </summary>
    public partial class MassUpdateHandlerNumbersView : UserControl, IMassUpdateHandlerNumbersView
    {
        public MassUpdateHandlerNumbersView()
        {
            InitializeComponent();
        }

        public IViewViewModel ViewModel
        {
            get
            {
                return (IMassUpdateNumbersViewViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}