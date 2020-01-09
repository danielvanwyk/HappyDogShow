using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.Commands
{
    public class ResultsCommands
    {
        public static CompositeCommand ShowBreedResultsCommand = new CompositeCommand();
        public static CompositeCommand SaveBreedResultsCommand = new CompositeCommand();

        public static CompositeCommand ShowBreedGroupResultsCommand = new CompositeCommand();
        public static CompositeCommand SaveBreedGroupResultsCommand = new CompositeCommand();

        public static CompositeCommand ShowInShowResultsCommand = new CompositeCommand();
        public static CompositeCommand SaveInShowResultsCommand = new CompositeCommand();

        public static CompositeCommand ShowHandlerResultsCommand = new CompositeCommand();
        public static CompositeCommand SaveHandlerResultsCommand = new CompositeCommand();

        public static CompositeCommand PrintCertificatesForDogRelatedChallengeResults = new CompositeCommand();
    }
}
