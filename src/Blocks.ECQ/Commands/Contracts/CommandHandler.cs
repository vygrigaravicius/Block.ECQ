namespace Blocks.ECQ.Commands
{
    public interface ICommandHandler<in TCommand, TResult>
        where TCommand: ICommand<TResult>
    {

    }

    public interface ICommandHandler
    {

    }
}
