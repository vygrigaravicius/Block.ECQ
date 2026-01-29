namespace Blocks.ECQ.Queries
{
    public sealed record QueryEnvelope<TQuery>
        where TQuery : IQuery
    {

    }

    public interface IQueryEnvelope<out TQuery>:
        IQueryEnvelope
            where TQuery: IQuery
    {
        new TQuery Payload { get; }

        IQuery IQueryEnvelope.Payload 
            => Payload;
    }

    public interface IQueryEnvelope
    {
        QueryId Id { get; }

        IQueryContext Context { get; }

        IQuery Payload { get; }
    }
}
