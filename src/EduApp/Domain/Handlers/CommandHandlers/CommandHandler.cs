using Flunt.Notifications;

namespace Domain.Handlers.CommandHandlers
{
    public class CommandHandler : Notifiable<Notification>
    {
        public bool IsNotValid => !IsValid;
    }
}
