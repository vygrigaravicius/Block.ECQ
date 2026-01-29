namespace Blocks.ECQ.Queries
{
    public interface IQueryValidator<in TQuery>:
        IQueryValidator
            where TQuery: IQuery
    {

    }

    public interface IQueryValidator
    {

    }
}
