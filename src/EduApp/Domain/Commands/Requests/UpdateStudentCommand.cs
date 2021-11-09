using Domain.Commands.Contracts;

namespace Domain.Commands.Requests
{
    public class UpdateStudentCommand : Command<UpdateStudentCommand>
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }

        public UpdateStudentCommand(string name, string email)
        {
            Name = name;
            Email = email;

            Contract = new UpdateStudentCommandContract(this);
        }
    }
}
