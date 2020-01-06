using HappyDogShow.Modules.Shows.Commands;
using HappyDogShow.Modules.Shows.Infrastructure;
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
    public class MassUpdateHandlerEntryNumbersViewViewModel : MassUpdateNumbersBaseViewViewModel<IHandlerEntryEntityWithAdditionalData>
    {
        private IHandlerEntryService _service;

        public IDogShowEntity SelectedDogShow;

        public MassUpdateHandlerEntryNumbersViewViewModel(IMassUpdateHandlerNumbersView view, IHandlerEntryService service)
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

            List<IHandlerEntryEntityWithAdditionalData> items = await _service.GetHandlerEntryListAsync<HandlerEntryEntityWithAdditionalData>(SelectedDogShow.Id);

            items.ForEach(i => Items.Add(i));
        }

        public override async Task UpdateEntries()
        {
            foreach (IHandlerEntryEntityWithAdditionalData entry in Items)
            {
                SelectedItem = entry;
                await Task.Delay(TimeSpan.FromMilliseconds(20));
                IHandlerEntryEntity actualentry = await _service.GetHandlerEntryAsync<HandlerEntry>(entry.Id);
                actualentry.Number = entry.EntryNumber;
                await _service.UpdateEntityAsync(actualentry);
            }
        }

        public override async Task GenerateNumbers()
        {
            foreach (IHandlerEntryEntityWithAdditionalData entry in Items.OrderBy(i => i.EnteredClassName))
            {
                SelectedItem = entry;
                await Task.Delay(TimeSpan.FromMilliseconds(20));

                SelectedItem.EntryNumber = "";
            }

            foreach (IHandlerEntryEntityWithAdditionalData entry in Items.OrderBy(i => i.EnteredClassName))
            {
                SelectedItem = entry;
                await Task.Delay(TimeSpan.FromMilliseconds(20));

                var entriesInSameClassWithNumbers = Items.Where(i => (i.EnteredClassName == SelectedItem.EnteredClassName && i.EntryNumber.Trim().Length > 0)).OrderBy(i => i.EntryNumber);

                if (entriesInSameClassWithNumbers.Count() == 0)
                {
                    SelectedItem.EntryNumber = string.Format("{0}1", SelectedItem.EnteredClassName[0]);
                }
                else
                {
                    IHandlerEntryEntityWithAdditionalData lastEntry = entriesInSameClassWithNumbers.Last();
                    string lastNumber = lastEntry.EntryNumber;
                    string actualNumber = lastNumber.Replace(lastEntry.EnteredClassName[0].ToString(), "");
                    int intValue = int.Parse(actualNumber);
                    int newValue = intValue + 1;
                    SelectedItem.EntryNumber = string.Format("{0}{1}", SelectedItem.EnteredClassName[0], newValue);
                }
            }
        }

        public override void NavigateAway()
        {
            ShowListCommands.ShowShowListCommand.Execute(null);
        }
    }
}
