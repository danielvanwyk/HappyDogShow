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
        public static CompositeCommand ShowHandlerEntryNumberLabelsReportCommand = new CompositeCommand();
        public static CompositeCommand ShowRegisteredOwnerLabelsReportCommand = new CompositeCommand();
        public static CompositeCommand ShowBreedSplashReportCommand = new CompositeCommand();
        public static CompositeCommand ShowCatalogReportCommand = new CompositeCommand();

        public static CompositeCommand ShowBreedResultsStewardsSheetReportCommand = new CompositeCommand();
        public static CompositeCommand ShowBreedResultsJudgesSheetReportCommand = new CompositeCommand();

        public static CompositeCommand ShowBreedGroupResultsStewardsSheetReportCommand = new CompositeCommand();
        public static CompositeCommand ShowBreedGroupResultsJudgesSheetReportCommand = new CompositeCommand();

        public static CompositeCommand ShowInShowResultsStewardsSheetReportCommand = new CompositeCommand();
        public static CompositeCommand ShowInShowResultsJudgesSheetReportCommand = new CompositeCommand();

        public static CompositeCommand ShowHandlerResultsStewardsSheetReportCommand = new CompositeCommand();
        public static CompositeCommand ShowHandlerResultsJudgesSheetReportCommand = new CompositeCommand();
    }
}
