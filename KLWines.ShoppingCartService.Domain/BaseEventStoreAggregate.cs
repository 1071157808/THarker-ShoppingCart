using Eveneum;
using KLWines.ShoppingCartService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KLWines.ShoppingCartService.Domain
{
    public abstract class BaseEventStoreAggregate
    {
        protected IEventStore EventStore { get; set; }
        protected string EventStoreKey { get; set; }
        protected ulong Version { get; set; }

        protected List<IEvent> NewEvents { get; set; }

        public async Task InitEventStore(IEventStore eventStore, string eventStoreKey)
        {
            EventStore = eventStore;
            EventStoreKey = eventStoreKey;
        }


        protected async Task RaiseEvent(IEvent @event)
        {
            await ApplyEvent(@event);
            Version++;

            if(EventStore != null)
            {
                await EventStore.WriteToStream(EventStoreKey, new[]
                {
                    new EventData
                    {
                        Body = @event,
                        Version = Version,
                        Metadata = GetMetadata()
                    }
                }, Version);

                await EventStore.CreateSnapshot(EventStoreKey, Version, CreateSnapshot());
            }
        }

        protected abstract Task ApplyEvent(IEvent @event);
        protected abstract ISnapshot CreateSnapshot();
        protected virtual dynamic GetMetadata() => DateTime.UtcNow;
    }
}
