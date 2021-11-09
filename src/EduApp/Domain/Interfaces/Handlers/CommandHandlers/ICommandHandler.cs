namespace Domain.Interfaces.Handlers.CommandHandlers
{
    public interface ICommandHandler<TCommand, TResponse>
    {
        public TResponse Handle(TCommand command);
    }
}
