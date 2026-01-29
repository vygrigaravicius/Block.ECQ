namespace Blocks.ECQ.Events
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<TEvent>> Build<TEvent>()
            where TEvent : IEvent;
    }
}
