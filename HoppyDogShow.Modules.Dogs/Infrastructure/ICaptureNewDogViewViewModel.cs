﻿using HappyDogShow.Infrastructure.ViewModels;
using HappyDogShow.Infrastructure.WPF.Infrastructure;

namespace HappyDogShow.Modules.Dogs.Infrastructure
{
    public interface ICaptureNewDogViewViewModel : IViewViewModel, IEntityAwareViewViewModel
    {
        bool RememberRegisteredOwnerDetails { get; set; }
    }
}
