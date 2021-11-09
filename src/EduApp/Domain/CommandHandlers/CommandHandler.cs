using Flunt.Notifications;

namespace Domain.CommandHandlers
{
    public class CommandHandler : Notifiable<Notification>
    {
        public bool IsNotValid => !IsValid;
    }
}
