using HappyDogShow.Infrastructure.WPF.Infrastructure;
using HappyDogShow.Modules.Dogs.Infrastructure;
using System.Windows.Controls;

namespace HappyDogShow.Modules.Dogs.Views
{
    /// <summary>
    /// Interaction logic for EditDogView.xaml
    /// </summary>
    public partial class EditDogView : UserControl, IEditDogView
    {
        public EditDogView()
        {
            InitializeComponent();
        }

        public IViewViewModel ViewModel
        {
            get
            {
                return (IEditDogViewViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}