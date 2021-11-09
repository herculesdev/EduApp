namespace Domain.Interfaces.Handlers.QueryHandlers
{
    public interface IQueryHandler<TQuery, TResponse>
    {
        public TResponse Handle(TQuery query);
    }
}
