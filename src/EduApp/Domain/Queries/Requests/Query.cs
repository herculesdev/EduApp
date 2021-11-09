using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Commands.Requests
{
    public class Query<TQuery> : Notifiable<Notification>
    {
        protected Contract<TQuery> Contract { get; set; } = new Contract<TQuery>();
        public new bool IsValid => Validate();

        private bool Validate()
        {
            Clear();
            AddNotifications(Contract);
            return base.IsValid;
        }
    }
}
