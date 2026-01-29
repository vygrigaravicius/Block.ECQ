namespace Blocks.ECQ.Commands
{
    public interface ICommandValidator<in TCommand>:
        ICommandValidator
            where TCommand: ICommand
    {
        Task<bool> Validate(TCommand command, 
            CancellationToken cancellationToken);
    }

    public interface ICommandValidator
    {

    }
}
