using HappyDogShow.Infrastructure;
using HappyDogShow.Infrastructure.WPF.Infrastructure;
using MahApps.Metro.Controls;
using Microsoft.Practices.Prism.Regions;
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

namespace HappyDogShow.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : MetroWindow, IShellView
    {
        IRegionManager _regionManager;

        public IViewViewModel ViewModel
        {
            get { return (IShellViewViewModel)DataContext; }
            set { DataContext = value; }
        }

        public ShellView(IRegionManager regionManager)
        {
            InitializeComponent();
            _regionManager = regionManager;
        }
    }
}
