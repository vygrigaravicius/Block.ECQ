namespace Blocks.ECQ.Events
{
    public static class EventMiddlewareFactoryExtensions
    {
        internal static EventPipelineDelegate Aggregate<TEvent>(
            this IEventMiddlewareFactory factory,
            IEventEnvelope<TEvent> @event,
            EventPipelineDelegate pipeline,
            CancellationToken cancellationToken)
                where TEvent: IEvent
        {
            IEnumerable<IEventMiddleware<TEvent>> middleware = 
                factory.Build<TEvent>();

            if(middleware.Any())
            {
                pipeline = middleware.Aggregate(
                    pipeline,
                    (next, pipeline) => new EventPipelineDelegate(
                        () => pipeline.Invoke(@event, next, cancellationToken)));
            }

            return pipeline;
        }
    }
}
