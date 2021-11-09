using Domain.Commands.Contracts;

namespace Domain.Commands.Requests
{
    public class DeleteStudentCommand : Command<DeleteStudentCommand>
    {
        public long Id { get; init; }

        public DeleteStudentCommand(long id)
        {
            Id = id;

            Contract = new DeleteStudentCommandContract(this);
        }
    }
}
