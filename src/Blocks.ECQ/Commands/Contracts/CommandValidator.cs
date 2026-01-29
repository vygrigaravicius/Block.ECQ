namespace Blocks.ECQ.Commands
{
    public interface ICommandValidator<in TCommand>:
        ICommandValidator
            where TCommand: ICommand
    {

    }

    public interface ICommandValidator
    {

    }
}
