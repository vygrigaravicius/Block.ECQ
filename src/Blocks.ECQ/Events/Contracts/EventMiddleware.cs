namespace Blocks.ECQ.Events
{
    public interface IEventMiddleware<in TEvent>
        where TEvent: IEvent
    {
        Task Invoke(IEventEnvelope<TEvent> @event, object next, 
            CancellationToken cancellationToken);
    }
}
