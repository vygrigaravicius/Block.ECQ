namespace Blocks.ECQ.Commands
{
    public sealed record CommandId(Guid Value)
    {
        internal CommandId() :
            this(Guid.NewGuid())
        {

        }
    }
}
