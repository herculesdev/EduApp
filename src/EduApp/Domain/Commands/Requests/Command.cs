using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Commands.Requests
{
    public class Command<TCommand> : Notifiable<Notification>
    {
        protected Contract<TCommand> Contract { get; set; } = new Contract<TCommand>();
        public new bool IsValid => Validate();

        private bool Validate()
        {
            Clear();
            AddNotifications(Contract);
            return base.IsValid;
        }
    }
}
