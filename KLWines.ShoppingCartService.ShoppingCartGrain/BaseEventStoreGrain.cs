using Eveneum;
using KLWines.ShoppingCartService.Domain;
using KLWines.ShoppingCartService.Domain.Core;
using KLWines.ShoppingCartService.Domain.Interfaces;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLWines.ShoppingCartService.ShoppingCartGrain
{
    public abstract class BaseEventStoreGrain : Grain
    {
        protected IEventStore EventStore { get; set; }
        protected string EventStoreKey { get; set; }
        protected ulong Version { get; set; }
        protected List<IEvent> NewEvents { get; set; }

        public BaseEventStoreGrain()
        {
        }

        protected void Init(IEnumerable<IEvent> events = null, ISnapshot snapshot = null)
        {
            if(snapshot != null)
            {
                ApplySnapshot(snapshot);
            }
            if(events != null)
            {
                foreach(var @event in events)
                {
                    ApplyEvent(@event);
                }
            }
        }

        protected abstract void ApplySnapshot(ISnapshot snapshot);

        protected void ApplyEvents(IReadOnlyCollection<IEvent> events)
        {
            foreach(var @event in events)
            {
                ApplyEvent(@event);
                Version++;

            }
        }
        protected void ApplyEvent(IEvent @event)
        {
            dynamic me = this;
            me.Apply((dynamic)@event);
        }

        public IReadOnlyCollection<IEvent> PopNewEvents()
        {
            var newEvents = NewEvents.ToArray();
            NewEvents.Clear();
            return newEvents;
        }

        protected async Task Execute(Func<Task> function)
        {
            try
            {
                await function();
            }
            catch (Exception ex)
            {
                //if exception ocurs while executing the command, we want to rollback any events that may have been added where the action wasn't successful
                PopNewEvents();
                throw;
            }
            var newEvents = PopNewEvents();

            if (newEvents.Count > 0)
            {
                //store in event store
                ApplyEvents(newEvents);
                //create snapshot
            }
        }

        protected void RaiseEvent(IEvent @event)
        {
            NewEvents.Add(@event);
        }

        public override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();
            this.EventStoreKey = $"{this.GetType().Name}~{this.GetPrimaryKeyLong()}";

            var stream = await this.EventStore.ReadStream(this.EventStoreKey);

            if (stream.HasValue)
            {
                this.Version = stream.Value.Version;

                var events = stream.Value.Events.ToList().Select(e => e.Body as IEvent).ToList();
                var snapshot = stream.Value.Snapshot.Value.Data as ISnapshot;

                Init(events, snapshot);
            }
        }


    }
}
