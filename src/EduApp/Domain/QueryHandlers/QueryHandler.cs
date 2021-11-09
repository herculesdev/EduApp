using Flunt.Notifications;

namespace Domain.QueryHandlers
{
    public class QueryHandler : Notifiable<Notification>
    {
        public bool IsNotValid => !IsValid;
    }
}
