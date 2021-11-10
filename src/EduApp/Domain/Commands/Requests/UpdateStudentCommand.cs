using Domain.Commands.Contracts;

namespace Domain.Commands.Requests
{
    public class UpdateStudentCommand : Command<UpdateStudentCommand>
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }

        public UpdateStudentCommand(long id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;

            Contract = new UpdateStudentCommandContract(this);
        }
    }
}
