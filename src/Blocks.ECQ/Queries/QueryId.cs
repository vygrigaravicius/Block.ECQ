namespace Blocks.ECQ.Queries
{
    public sealed record QueryId(Guid Value):
        IQueryId
    {
        internal QueryId():
            this(Guid.NewGuid())
        {

        }
    }

    public interface IQueryId
    {

    }
}
