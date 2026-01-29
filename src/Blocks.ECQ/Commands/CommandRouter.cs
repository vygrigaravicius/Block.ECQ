namespace Blocks.ECQ.Commands
{
    // TODO: Add Logging, Guards.
    public sealed class CommandRouter
    {
        public async Task Route<TCommand, TResult>(
            CommandEnvelope<TCommand, TResult> command, 
            CancellationToken cancellationToken)
                where TCommand: ICommand<TResult>
        {

        }
    }
}
