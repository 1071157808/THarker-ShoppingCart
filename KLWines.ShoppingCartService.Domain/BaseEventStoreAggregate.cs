using Eveneum;
using KLWines.ShoppingCartService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KLWines.ShoppingCartService.Domain.Core;
namespace KLWines.ShoppingCartService.Domain
{
    public abstract class BaseEventStoreAggregate
    {
        protected ulong Version { get; set; }

        protected List<IEvent> NewEvents { get; set; }

        protected async Task RaiseEvent(IEvent @event)
        {
            await ApplyEvent(@event);
            NewEvents.Add(@event);
            Version++;
        }

        protected abstract Task ApplyEvent(IEvent @event);
    }
}
