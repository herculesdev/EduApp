namespace Domain.Interfaces.Handlers.CommandHandlers
{
    public interface ICommandWithoutHandler<TCommand>
    {
        public void Handle(TCommand command);
    }
}
