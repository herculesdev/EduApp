using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Commands.Requests
{
    public class Command<TCommand> : Notifiable<Notification>
    {
        private Contract<TCommand> _contract = new Contract<TCommand>();
        protected Contract<TCommand> Contract 
        { 
            get => _contract; 
            set 
            { 
                _contract = value;
                AddNotifications(_contract);
            } 
        }
        public new bool IsValid => Validate();

        private bool Validate()
        {
            Clear();
            AddNotifications(Contract);
            return base.IsValid;
        }
    }
}
