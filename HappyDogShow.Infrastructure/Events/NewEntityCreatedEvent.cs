using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.Events
{
    public struct NewEntityCreatedEventArgument
    {
        public int NewEntityId;

        public NewEntityCreatedEventArgument(int newId)
        {
            NewEntityId = newId;
        }
    }

    class NewEntityCreatedEvent<T> : PubSubEvent<NewEntityCreatedEventArgument> where T : IEntityWithID
    {
    }
}
