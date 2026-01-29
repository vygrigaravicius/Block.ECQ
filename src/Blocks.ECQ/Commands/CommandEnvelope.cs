namespace Blocks.ECQ.Commands
{
    public sealed record CommandEnvelope<TCommand, TResult>:
        ICommandEnvelope<TCommand>
            where TCommand : ICommand<TResult>
    {
        public required CommandId Id { get; init; }

        public required ICommandContext Context { get; init; }

        public required TCommand Payload { get; init; }
    }

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
