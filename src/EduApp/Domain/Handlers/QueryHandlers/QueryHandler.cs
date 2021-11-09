using Flunt.Notifications;

namespace Domain.Handlers.QueryHandlers
{
    public class QueryHandler : Notifiable<Notification>
    {
        public bool IsNotValid => !IsValid;
    }
}
