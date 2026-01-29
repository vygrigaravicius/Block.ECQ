namespace Blocks.ECQ.Queries
{
    public interface IQueryHandler<in TQuery, TResponse>:
        IQueryHandler
            where TQuery: IQuery<TResponse>
    {

    }

    public interface IQueryHandler
    {

    }
}
