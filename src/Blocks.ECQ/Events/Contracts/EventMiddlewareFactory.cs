namespace Blocks.ECQ.Events
{
    public interface IEventMiddlewareFactory
    {
        IEnumerable<IEventMiddleware<TEvent>> Build<TEvent>()
            where TEvent : IEvent;
    }
}
