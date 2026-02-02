namespace Blocks.ECQ.Events
{
    public interface IEventPipelineFactory
    {
        IEnumerable<IEventHandler<TEvent>> ResolveHandlers<TEvent>()
            where TEvent : IEvent;

        IEnumerable<IEventMiddleware<TEvent>> ResolveMiddleware<TEvent>()
            where TEvent: IEvent;
    }
}
