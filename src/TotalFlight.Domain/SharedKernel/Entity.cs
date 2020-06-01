using MediatR;
using System.Collections.Generic;

namespace TotalFlight.Domain.SharedKernel
{
    /// <summary>
    /// Base class for all entities, contains domain event functionality.
    /// </summary>
    public abstract class Entity
    {
        private List<INotification> _domainEvents;
        public List<INotification> DomainEvents => _domainEvents;
        public void AddDomainEvent(INotification de)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(de);
        }
        public void RemoveDomainEvent(INotification de) => _domainEvents?.Remove(de);
    }
}