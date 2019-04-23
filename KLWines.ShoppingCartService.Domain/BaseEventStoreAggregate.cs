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

        protected readonly List<IEvent> NewEvents = new List<IEvent>();
        protected IProxyRepository ProxyRepository { get; private set; }

        public BaseEventStoreAggregate() { }
        public BaseEventStoreAggregate(IEnumerable<IEvent> events, ISnapshot snapshot)
        {
            Init(events, snapshot, null);
        }

        public void Init(IEnumerable<IEvent> events, ISnapshot snapshot, IProxyRepository proxyRepository)
        {
            this.ProxyRepository = proxyRepository;

            if (snapshot != null)
            {
                ApplySnapshot(snapshot);
            }
            if (events != null)
            {
                foreach (var @event in events)
                {
                    ApplyEvent(@event);
                }
            }
        }

        protected void RaiseEvent(IEvent @event)
        {
            NewEvents.Add(@event);
        }

        protected abstract void ApplyEvent(IEvent @event);
        protected abstract void ApplySnapshot(ISnapshot snapshot);

        public void ApplyEvents(IReadOnlyCollection<IEvent> events)
        {
            foreach(var @event in events)
            {
                ApplyEvent(@event);
                Version++;
            }
        }

        public IReadOnlyCollection<IEvent> PopNewEvents()
        {
            var newEvents = NewEvents.ToArray();
            NewEvents.Clear();
            return newEvents;
        }
    }
}
