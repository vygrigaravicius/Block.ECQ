namespace Blocks.ECQ.Commands
{
    public interface ICommandMiddleware<in TCommand, TResult>:
        ICommandMiddleware
            where TCommand: ICommand<TResult>
    {
        Task Invoke(ICommandEnvelope<TCommand, TResult> command, 
            CommandPipelineDelegate next, 
            CancellationToken cancellationToken);
    }

    public interface ICommandMiddleware
    {

    }
}
