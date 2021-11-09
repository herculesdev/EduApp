namespace Domain.Interfaces.QueryHandlers
{
    public interface IQueryHandler<TQuery, TResponse>
    {
        public TResponse Handle(TQuery query);
    }
}
