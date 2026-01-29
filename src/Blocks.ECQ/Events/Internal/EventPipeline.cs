namespace Blocks.ECQ.Events
{
    // TODO: Format the exception(s) to provide more information.
    internal sealed class EventPipeline<TEvent> :
        IEventPipeline
            where TEvent : IEvent
    {
        public async Task Handle(IEventEnvelope @event, 
            CancellationToken cancellationToken)
        {
            if (@event is IEventEnvelope<TEvent> typed)
                throw new NotImplementedException();
            else throw new InvalidCastException();
        }
    }

    internal interface IEventPipeline
    {
        Task Handle(IEventEnvelope @event, 
            CancellationToken cancellationToken);
    }
}
