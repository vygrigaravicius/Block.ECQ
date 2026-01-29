namespace Blocks.ECQ.Queries
{
    public interface IQueryMiddleware<in TQuery>:
        IQueryMiddleware
            where TQuery: IQuery
    {

    }

    public interface IQueryMiddleware
    {

    }
}
