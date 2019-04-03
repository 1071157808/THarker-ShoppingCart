using Eveneum;
using KLWines.ShoppingCartService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KLWines.ShoppingCartService.Domain.Core;
using System.Linq;

namespace KLWines.ShoppingCartService.Domain
{
    public abstract class BaseEventStoreAggregate
    {
        
        protected ulong Version { get; set; }

        protected List<IEvent> NewEvents { get; set; }

        public BaseEventStoreAggregate(List<IEvent> events)
        {
            if(events == null)
            {
                events = new List<IEvent>();
            }
            else
            {
                foreach(var @event in events)
                {
                    var task = ApplyEvent(@event).ConfigureAwait(false);
                }
            }
            NewEvents = new List<IEvent>();
        }

        protected async Task RaiseEvent(IEvent @event)
        {
            await ApplyEvent(@event);
            NewEvents.Add(@event);
            Version++;
        }

        protected abstract Task ApplyEvent(IEvent @event);

        public IEnumerable<IEvent> PopNewEvents()
        {
            var newEvents = NewEvents.Select(x => x);
            NewEvents.Clear();
            return newEvents;
        }
    }
}
