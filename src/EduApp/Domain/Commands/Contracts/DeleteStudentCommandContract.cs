using Domain.Commands.Requests;
using Flunt.Validations;

namespace Domain.Commands.Contracts
{
    internal class DeleteStudentCommandContract : Contract<DeleteStudentCommand>
    {
        private DeleteStudentCommand _command;
        public DeleteStudentCommandContract(DeleteStudentCommand command)
        {
            _command = command;

            Requires()
                .IsGreaterOrEqualsThan(_command.Id, 1, "Id", "ID is invalid");
        }
    }
}
