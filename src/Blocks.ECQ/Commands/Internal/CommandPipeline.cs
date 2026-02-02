namespace Blocks.ECQ.Commands
{
    // TODO: Guards, Exception Handling logic. 
    internal sealed class CommandPipeline<TCommand, TResult>()
        where TCommand : ICommand<TResult>
    {
        public required ICommandHandler<TCommand, TResult> Handler { get; init; }

        public async Task Handle(ICommandEnvelope<TCommand, TResult> command,
            CancellationToken cancellationToken)
        {

        }
    }
}
