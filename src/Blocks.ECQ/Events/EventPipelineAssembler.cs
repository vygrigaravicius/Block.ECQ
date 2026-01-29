namespace Blocks.ECQ.Events
{
    // TODO: Make middleware-factory optional, based on Configuration.
    // TODO: Add Guards.
    public sealed class EventPipelineAssembler(
        IEventHandlerFactory HandlerFactory,
        IEventMiddlewareFactory MiddlewareFactory)
    {
        private readonly IEventHandlerFactory _handlerFactory = HandlerFactory;
        private readonly IEventMiddlewareFactory _middlewareFactory = MiddlewareFactory;

        internal EventPipelineDelegate Assemble<TEvent>(IEventEnvelope<TEvent> @event, 
            CancellationToken cancellationToken)
            where TEvent : IEvent
        {
            EventPipelineDelegate pipeline = _handlerFactory.Aggregate(
                @event, cancellationToken);

            pipeline = _middlewareFactory.Aggregate(
                @event, pipeline, cancellationToken);

            return pipeline;
        }
    }
}
