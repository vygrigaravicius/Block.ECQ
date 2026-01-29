namespace Blocks.ECQ.Events
{
    public interface IEventHandler<in TEvent>:
        IEventHandler
            where TEvent: IEvent
    {
        Task Handle(IEventEnvelope<TEvent> @event, 
            CancellationToken cancellationToken);
    }

    public interface IEventHandler
    {

    }
}
