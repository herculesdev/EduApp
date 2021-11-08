using Domain.Commands.Requests;
using Flunt.Extensions.Br.Validations;
using Flunt.Validations;

namespace Domain.Commands.Contracts
{
    internal class CreateStudentCommandContract : Contract<CreateStudentCommand>
    {
        private CreateStudentCommand _command;
        public CreateStudentCommandContract(CreateStudentCommand command)
        {
            _command = command;

            Requires()
                .IsNotNullOrEmpty(_command.Name, "Name", "name must not be empty")
                .IsEmail(_command.Email, "Email", "Email is invalid")
                .IsNotNullOrEmpty(_command.RA, "RA", "RA must not be empty")
                .IsCpf(_command.CPF, "CPF", "CPF is invalid");
        }
    }
}
