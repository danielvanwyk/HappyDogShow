﻿using HappyDogShow.Infrastructure.WPF.Infrastructure;
using HappyDogShow.Modules.Entries.Infrastructure;
using System.Windows.Controls;

namespace HappyDogShow.Modules.Entries.Views
{
    /// <summary>
    /// Interaction logic for BreedResultsView.xaml
    /// </summary>
    public partial class BreedResultsView : UserControl, IBreedResultsView
    {
        public BreedResultsView()
        {
            InitializeComponent();
        }

        public IViewViewModel ViewModel
        {
            get
            {
                return (IBreedResultsViewViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}