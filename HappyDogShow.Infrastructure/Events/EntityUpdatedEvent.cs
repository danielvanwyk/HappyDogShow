using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.Events
{
    public struct EntityUpdatedEventArgument
    {
        public int EntityId;

        public EntityUpdatedEventArgument(int entityId)
        {
            EntityId = entityId;
        }
    }

    class EntityUpdatedEvent<T> : PubSubEvent<EntityUpdatedEventArgument> where T : IEntityWithID
    {
    }
}
