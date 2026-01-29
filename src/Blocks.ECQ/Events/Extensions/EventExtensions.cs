namespace Blocks.ECQ.Events
{
    public static class EventExtensions
    {
        public static IEventEnvelope Wrap(
            this IEvent payload, IEventContext context)
                => EventEnvelopeBuilder.Build(payload, context);
    }
}
