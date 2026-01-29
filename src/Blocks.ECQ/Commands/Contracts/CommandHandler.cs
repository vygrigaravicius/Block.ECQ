namespace Blocks.ECQ.Commands
{
    public interface ICommandHandler<in TCommand, TResult>
        where TCommand: ICommand<TResult>
    {
        Task<TResult> Handle(ICommandEnvelope<TCommand> command,
            CancellationToken cancellationToken);
    }

    public interface ICommandHandler
    {

    }
}
