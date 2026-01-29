namespace Blocks.ECQ.Queries
{
    public interface IQueryHandler<in TQuery, TResult>:
        IQueryHandler
            where TQuery: IQuery<TResult>
    {

    }

    public interface IQueryHandler
    {

    }
}
