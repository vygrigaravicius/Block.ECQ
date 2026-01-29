using System.Collections.Concurrent;

namespace Blocks.ECQ.Events
{
    // TODO: Add Logging. 
    public sealed class EventRouter
    {
        private static readonly ConcurrentDictionary<Type, 
            IEventPipeline> _cache = [];

        public async Task Route(IEventEnvelope @event,
            CancellationToken cancellationToken)
        {
            IEventPipeline pipeline = _cache.GetOrAdd(@event.GetType(), 
                Resolve(@event.GetType()));

            await pipeline.Handle(@event, cancellationToken);
        }

        private IEventPipeline Resolve(Type typeOfEvent)
            => throw new NotImplementedException();
    }
}
