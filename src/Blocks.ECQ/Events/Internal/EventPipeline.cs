namespace Blocks.ECQ.Events
{
    // TODO: Format the exception(s) to provide more information.
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
            else throw new InvalidCastException();
        }
    }

    internal interface IEventPipeline
    {
        Task Handle(IEventEnvelope @event, 
            EventPipelineAssembler assembler,
            CancellationToken cancellationToken);
    }
}
