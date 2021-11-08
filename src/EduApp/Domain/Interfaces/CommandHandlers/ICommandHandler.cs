namespace Domain.Interfaces.CommandHandlers
{
    public interface ICommandHandler<TCommand, TResponse>
    {
        public TResponse Handle(TCommand command);
    }
}
