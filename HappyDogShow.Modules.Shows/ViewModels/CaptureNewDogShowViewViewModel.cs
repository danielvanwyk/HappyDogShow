﻿using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Shows.Infrastructure;
using HappyDogShow.Modules.Shows.Models;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.ViewModels
{
    public class CaptureNewDogShowViewViewModel : BindableViewModelBase, ICaptureNewDogShowViewViewModel, INavigationAware
    {
        private DogShowDetail currentEntity;
        public DogShowDetail CurrentEntity
        {
            get { return currentEntity; }
            set { SetProperty(ref currentEntity, value); }
        }

        public CaptureNewDogShowViewViewModel(ICaptureNewDogShowView view) : base(view)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            CurrentEntity = new DogShowDetail();
        }
    }
}
