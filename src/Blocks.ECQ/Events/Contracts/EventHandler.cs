namespace Blocks.ECQ.Events
{
    public interface IEventHandler<in TEvent>:
        IEventHandler
            where TEvent: IEvent
    {

    }

    public interface IEventHandler
    {

    }
}
