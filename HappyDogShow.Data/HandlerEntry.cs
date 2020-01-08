using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Data
{
    public class HandlerEntry
    {
        public int ID { get; set; }

        public DogShow Show { get; set; }

        public HandlerRegistration Handler { get; set; }

        public HandlerClass EnteredClass { get; set; }

        public DogRegistration Dog { get; set; }

        public string Number { get; set; }

        public ShowHandlerClassJudge ShowHandlerClassJudge { get; set; }
    }
}
