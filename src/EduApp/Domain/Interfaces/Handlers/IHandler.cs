using Flunt.Notifications;

namespace Domain.Interfaces.Handlers
{
    public interface IHandler
    {
        public bool IsValid { get; }
        IReadOnlyCollection<Notification> Notifications { get; }
    }
}
