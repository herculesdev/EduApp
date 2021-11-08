namespace Domain.Interfaces.CommandHandlers
{
    public interface ICommandWithoutHandler<TCommand>
    {
        public void Handle(TCommand command);
    }
}
