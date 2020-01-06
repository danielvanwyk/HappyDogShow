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
    public class MassUpdateNumbersGenerateNumbersViewViewModel : MassUpdateNumbersBaseViewViewModel
    {
        public MassUpdateNumbersGenerateNumbersViewViewModel(IMassUpdateNumbersView view, IBreedEntryService service)
            : base(view, service)
        {
        }

        public override async Task GenerateNumbers()
        {
            int number = 0;
            foreach (IBreedEntryEntityWithAdditionalData entry in Items)
            {
                SelectedItem = entry;
                await Task.Delay(TimeSpan.FromMilliseconds(20));
                number++;
                entry.EntryNumber = number.ToString();
            }
        }
    }
}
