using Domain.Commands.Requests;
using Flunt.Extensions.Br.Validations;
using Flunt.Validations;

namespace Domain.Commands.Contracts
{
    internal class UpdateStudentCommandContract : Contract<UpdateStudentCommand>
    {
        private UpdateStudentCommand _command;
        public UpdateStudentCommandContract(UpdateStudentCommand command)
        {
            _command = command;

            Requires()
                .IsNotNullOrEmpty(_command.Name, "Name", "name must not be empty")
                .IsEmail(_command.Email, "Email", "Email is invalid");
        }
    }
}
