namespace Blocks.ECQ.Commands
{
    internal sealed class CommandPipeline<TCommand, TResult>
        where TCommand: ICommand<TResult>
    {

    }

    internal interface ICommandPipeline
    {

    }
}
