namespace Blocks.ECQ.Events
{
    public interface IEventMiddleware<in TEvent>
        where TEvent: IEvent
    {
        Task Invoke(object @event, object next, 
            CancellationToken cancellationToken);
    }
}
