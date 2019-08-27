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

namespace HappyDogShow.Infrastructure.UserControls
{
    /// <summary>
    /// Interaction logic for BasicContentLayout.xaml
    /// </summary>
    public partial class BasicContentLayout : UserControl
    {
        public string MainTitleText
        {
            get { return (string)GetValue(MainTitleTextProperty); }
            set { SetValue(MainTitleTextProperty, value); }
        }
        public static readonly DependencyProperty MainTitleTextProperty =
            DependencyProperty.Register("MainTitleText", typeof(string), typeof(BasicContentLayout),
              new PropertyMetadata(null));

        public object MainContent
        {
            get { return (object)GetValue(MainContentProperty); }
            set { SetValue(MainContentProperty, value); }
        }
        public static readonly DependencyProperty MainContentProperty =
            DependencyProperty.RegisterAttached(
            "MainContent",
            typeof(object),
            typeof(BasicContentLayout),
            new PropertyMetadata(null)
            );

        public BasicContentLayout()
        {
            InitializeComponent();
            MainTitleText = "Main Title Text";
        }
    }
}
