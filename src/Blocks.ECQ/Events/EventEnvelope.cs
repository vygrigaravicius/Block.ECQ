namespace Blocks.ECQ.Events
{
    // TODO: Add Timestam(s) & Guards once the other libraries are in place. 
    public sealed record EventEnvelope<TEvent>:
        IEventEnvelope<TEvent>
            where TEvent: IEvent
    {
        public required EventId Id { get; init; }

        public required IEventContext Context { get; init; }

        public required TEvent Payload { get; init; }

        internal static EventEnvelope<TEvent> Wrap(
            TEvent payload, IEventContext context)
                => new()
                {
                    Id = new EventId(),
                    Context = context,
                    Payload = payload,
                };
    }

    public interface IEventEnvelope<out TEvent>:
        IEventEnvelope
            where TEvent: IEvent
    {
        new TEvent Payload { get; }

        IEvent IEventEnvelope.Payload 
            => Payload;
    }

    public interface IEventEnvelope
    {
        EventId Id { get; }

        IEventContext Context { get; }

        IEvent Payload { get; }
    }
}
