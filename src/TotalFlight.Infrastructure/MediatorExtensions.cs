using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TotalFlight.Domain.SharedKernel;
using TotalFlight.Infrastructure.Data;

namespace TotalFlight.Infrastructure
{
    public static class MediatorExtensions
    {
        /// <summary>
        /// Applies all domain events added to Entities in this transaction.
        /// </summary>
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, ApplicationContext context)
        {
            var entities = context.ChangeTracker
                .Entries<Entity>()
                .Where(e => e.Entity.DomainEvents != null && e.Entity.DomainEvents.Count > 0);
            var events = entities.SelectMany(e => e.Entity.DomainEvents)
                .ToList();
            foreach (var e in events)
                await mediator.Publish(e);
        }
    }
}