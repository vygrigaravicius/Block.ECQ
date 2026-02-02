namespace Blocks.ECQ.Commands
{
    // TODO: Add Logging, Guards.
    public sealed class CommandRouter(CommandPipelineFactory Factory)
    {
        private readonly CommandPipelineFactory _factory = Factory;

        public async Task Route<TCommand, TResult>(
            CommandEnvelope<TCommand, TResult> command, 
            CancellationToken cancellationToken)
                where TCommand: ICommand<TResult>
        {
            CommandPipelineDelegate pipeline = _factory.Build(
                command, cancellationToken);

            await pipeline.Invoke();
        }
    }
}
