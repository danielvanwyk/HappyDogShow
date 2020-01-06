using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Shows.Commands;
using HappyDogShow.Modules.Shows.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.ViewModels
{
    public class MassUpdateNumbersRemoveNumbersViewViewModel : MassUpdateBreedEntryNumbersBaseViewViewModel
    {
        public MassUpdateNumbersRemoveNumbersViewViewModel(IMassUpdateNumbersView view, IBreedEntryService service)
            : base(view, service)
        {
        }

        public override async Task GenerateNumbers()
        {
            foreach (IBreedEntryEntityWithAdditionalData entry in Items)
            {
                SelectedItem = entry;
                await Task.Delay(TimeSpan.FromMilliseconds(20));
                entry.EntryNumber = "";
            }
        }

        public override void NavigateAway()
        {
            ShowListCommands.ShowShowListCommand.Execute(null);
        }
    }
}
