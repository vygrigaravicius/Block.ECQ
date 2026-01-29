using System.Collections.Concurrent;

namespace Blocks.ECQ.Events
{
    // TODO: Add Logging, inject Pipeline assembler.  
    // TODO: Add Guards.
    public sealed class EventRouter(EventPipelineAssembler Assembler)
    {
        private static readonly ConcurrentDictionary<Type, 
            IEventPipeline> _cache = [];

        private readonly EventPipelineAssembler _assembler 
            = Assembler;

        public async Task Route(IEventEnvelope @event,
            CancellationToken cancellationToken)
        {
            IEventPipeline pipeline = _cache.GetOrAdd(@event.GetType(), 
                Resolve(@event));

            await pipeline.Handle(@event, _assembler, cancellationToken);
        }

        // TODO: Logging.
        private IEventPipeline Resolve(IEventEnvelope @event)
        {
            IEventPipeline pipeline = EventPipelineBuilder.Build(
                @event.Payload);

            return pipeline;
        }
    }
}
