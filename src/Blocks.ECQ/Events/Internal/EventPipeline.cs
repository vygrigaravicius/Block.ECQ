namespace Blocks.ECQ.Events
{
    internal sealed class EventPipeline<TEvent>() :
        IEventPipeline
            where TEvent : IEvent
    {
        public async Task Handle(IEventEnvelope @event,
            EventPipelineAssembler assembler,
            CancellationToken cancellationToken)
        {
            if (@event is IEventEnvelope<TEvent> typed)
                await assembler.Assemble(typed, cancellationToken)
                    .Invoke();
            else throw new InvalidCastException($"Cannot cast event of type " +
                $"'{@event.GetType().FullName}' to expected type " +
                $"'{typeof(IEventEnvelope<TEvent>).FullName}' in " +
                $"'{nameof(EventPipeline<>)}' Handle method.");
        }
    }

    internal interface IEventPipeline
    {
        Task Handle(IEventEnvelope @event, 
            EventPipelineAssembler assembler,
            CancellationToken cancellationToken);
    }
}
