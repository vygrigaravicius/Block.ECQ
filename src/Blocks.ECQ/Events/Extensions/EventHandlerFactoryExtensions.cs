namespace Blocks.ECQ.Events
{
    // TODO: Config File Injection (Options) + behaviour when none or multiple handlers are defined.
    public static class EventHandlerFactoryExtensions
    {
        internal static EventPipelineDelegate Aggregate<TEvent>(
            this IEventHandlerFactory factory, 
            IEventEnvelope<TEvent> @event, 
            CancellationToken cancellationToken)
                where TEvent : IEvent
        {
            IEnumerable<IEventHandler<TEvent>> handlers = 
                factory.Build<TEvent>();

            switch (handlers.Count())
            {
                case 0:
                    throw new NotImplementedException();
                case 1:
                    return new EventPipelineDelegate(
                        () => handlers.First().Handle(@event, cancellationToken));
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
