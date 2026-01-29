namespace Blocks.ECQ.Commands
{
    public interface ICommandEnvelope<out TCommand>:
        ICommandEnvelope
            where TCommand: ICommand
    {
        new TCommand Payload { get; }

        ICommand ICommandEnvelope.Payload 
            => Payload;
    }

    public interface ICommandEnvelope
    {
        CommandId Id { get; }

        ICommandContext Context { get; }

        ICommand Payload { get; }
    }
}
