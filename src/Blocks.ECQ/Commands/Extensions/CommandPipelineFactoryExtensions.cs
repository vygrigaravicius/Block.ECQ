namespace Blocks.ECQ.Commands
{
    public static class CommandPipelineFactoryExtensions
    {
        internal static CommandPipelineDelegate AppendMiddleware<TCommand, TResult>(
            this ICommandPipelineFactory factory, 
            CommandPipelineDelegate pipeline,
            ICommandEnvelope<TCommand, TResult> command,
            CancellationToken cancellationToken)
                where TCommand : ICommand<TResult>
        {
            IEnumerable<ICommandMiddleware<TCommand, TResult>> middleware = 
                factory.ResolveMiddleware<TCommand, TResult>();

            if(middleware.Any())
            {
                pipeline = middleware.Aggregate(
                    pipeline,
                    (next, pipeline) => new CommandPipelineDelegate(
                        () => pipeline.Invoke(command, next, cancellationToken)));
            }

            return pipeline;
        }
    }
}
