using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.Events
{
    public struct EntityDeletedEventArgument
    {
        public int EntityId;

        public EntityDeletedEventArgument(int entityId)
        {
            EntityId = entityId;
        }
    }

    class EntityDeletedEvent<T> : PubSubEvent<EntityDeletedEventArgument> where T : IEntityWithID
    {
    }
}