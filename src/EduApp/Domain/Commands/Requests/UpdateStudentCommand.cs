using Domain.Commands.Contracts;

namespace Domain.Commands.Requests
{
    public class UpdateStudentCommand : Command<UpdateStudentCommand>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UpdateStudentCommand(string name, string email)
        {
            Name = name;
            Email = email;

            Contract = new UpdateStudentCommandContract(this);
        }
    }
}
