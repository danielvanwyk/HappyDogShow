using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.Commands
{
    public class DogShowReportCommands
    {
        public static CompositeCommand ShowBreedBreakdownReportCommand = new CompositeCommand();
        public static CompositeCommand ShowEntryNumberLabelsReportCommand = new CompositeCommand();
        public static CompositeCommand ShowBreedSplashReportCommand = new CompositeCommand();
    }
}
