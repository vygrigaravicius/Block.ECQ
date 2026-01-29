namespace Blocks.ECQ.Events
{
    public sealed record EventId(Guid Value)
    {
        internal EventId():
            this(Guid.NewGuid())
        {

        }
    }
}
