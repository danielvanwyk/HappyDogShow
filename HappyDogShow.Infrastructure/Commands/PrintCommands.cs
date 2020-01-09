using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.Commands
{
    public class PrintCommands
    {
        public static CompositeCommand PrintCertificatesForDogRelatedChallengeResults = new CompositeCommand();
        public static CompositeCommand PrintCertificatesForHandlerRelatedChallengeResults = new CompositeCommand();
    }
}
