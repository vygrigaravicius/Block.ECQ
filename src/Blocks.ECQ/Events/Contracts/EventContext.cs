using Blocks.ECQ.Commands;

namespace Blocks.ECQ.Events
{
    public interface IEventContext
    {
        CommandId CorrelationId { get; }

        CommandId CausationId { get; }
    }
}
