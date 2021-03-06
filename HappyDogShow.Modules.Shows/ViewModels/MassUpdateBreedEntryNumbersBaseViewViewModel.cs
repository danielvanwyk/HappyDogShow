﻿using HappyDogShow.Modules.Shows.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using HappyDogShow.SharedModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.ViewModels
{
    public abstract class MassUpdateBreedEntryNumbersBaseViewViewModel : MassUpdateNumbersBaseViewViewModel<IBreedEntryEntityWithAdditionalData>
    {
        private IBreedEntryService _service;

        public IDogShowEntity SelectedDogShow;

        public MassUpdateBreedEntryNumbersBaseViewViewModel(IMassUpdateNumbersView view, IBreedEntryService service)
            : base(view)
        {
            _service = service;
        }

        public override void GetValuesFromNavigationParameters(NavigationContext navigationContext)
        {
            SelectedDogShow = navigationContext.Parameters["entity"] as IDogShowEntity;
        }

        public override async Task LoadData()
        {
            Items.Clear();

            List<IBreedEntryEntityWithAdditionalData> items = await _service.GetBreedEntryListAsync<BreedEntryEntityWithAdditionalData>(SelectedDogShow.Id);

            items.ForEach(i => Items.Add(i));
        }

        public override async Task UpdateEntries()
        {
            foreach (IBreedEntryEntityWithAdditionalData entry in Items)
            {
                SelectedItem = entry;
                await Task.Delay(TimeSpan.FromMilliseconds(20));
                IBreedEntryEntity actualentry = await _service.GetBreedEntryAsync<BreedEntry>(entry.Id);
                actualentry.Number = entry.EntryNumber;
                await _service.UpdateEntityAsync(actualentry);
            }
        }

    }
}
