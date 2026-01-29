namespace Blocks.ECQ.Events
{
    // TODO: Add Timestam(s) & Guards once the other libraries are in place. 
    public sealed record EventEnvelope<TPayload>:
        IEventEnvelope
            where TPayload: IEvent
    {
        public required EventId Id { get; init; }

        public required IEventContext Context { get; init; }

        public required TPayload Payload { get; init; }

        IEvent IEventEnvelope.Payload => Payload;

        internal static EventEnvelope<TPayload> Wrap(
            TPayload payload, IEventContext context)
                => new()
                {
                    Id = new EventId(),
                    Context = context,
                    Payload = payload,
                };
    }

    public interface IEventEnvelope
    {
        EventId Id { get; }

        IEventContext Context { get; }

        IEvent Payload { get; }
    }
}
