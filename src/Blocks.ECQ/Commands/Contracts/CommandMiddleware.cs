namespace Blocks.ECQ.Commands
{
    public interface ICommandMiddleware<in TCommand>
    {
        Task Invoke(object command, object next, 
            CancellationToken cancellationToken);
    }
}
