namespace Blocks.ECQ.Commands
{
    public abstract class CommandPipelineFactory
    {
        internal CommandPipelineDelegate Build<TCommand, TResult>(
            ICommandEnvelope<TCommand, TResult> command,
            CancellationToken cancellationToken)
                where TCommand: ICommand<TResult>
        {
            CommandPipeline<TCommand, TResult> pipeline =
                new CommandPipeline<TCommand, TResult>()
                {
                    Handler = null
                };

            return pipeline;
        }
    }
}
