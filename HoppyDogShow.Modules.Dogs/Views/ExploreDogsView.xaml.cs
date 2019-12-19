using HappyDogShow.Infrastructure.WPF.Infrastructure;
using HappyDogShow.Modules.Dogs.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
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

namespace HappyDogShow.Modules.Dogs.Views
{
    /// <summary>
    /// Interaction logic for ExploreDogsView.xaml
    /// </summary>
    public partial class ExploreDogsView : UserControl, IExploreDogsView
    {
        public ExploreDogsView()
        {
            InitializeComponent();
        }

        public IViewViewModel ViewModel
        {
            get
            {
                return (IExploreDogsViewViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }

        public void PerformFiltering()
        {
            var c = this.FindResource("cvsItems");
            var defaultview = (c as CollectionViewSource).View;
            if (defaultview != null)
                defaultview.Refresh();
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            string filterCriteria = (ViewModel as IExploreDogsViewViewModel).RegistrationNumberFilterCriteria.ToLower().Trim();

            if (filterCriteria.Length == 0)
                e.Accepted = true;
            else
            {
                IDogRegistration t = e.Item as IDogRegistration;
                if (t != null)
                {
                    if (t.RegisrationNumber.ToLower().Contains(filterCriteria))
                        e.Accepted = true;
                    else
                        e.Accepted = false;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var c = this.FindResource("cvsItems");
            (c as CollectionViewSource).View.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PerformFiltering();
        }
    }
}
