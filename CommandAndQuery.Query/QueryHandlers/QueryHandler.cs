using CommandAndQuery.Query.Interfaces;

namespace CommandAndQuery.Query.QueryHandlers
{
    public abstract class QueryHandler<TQuery, TResponse>
        : IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        public abstract TResponse Handle(TQuery query);
    }
}