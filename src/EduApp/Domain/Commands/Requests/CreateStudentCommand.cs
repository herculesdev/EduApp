using Domain.Commands.Contracts;

namespace Domain.Commands.Requests
{
    public class CreateStudentCommand : Command<CreateStudentCommand>
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string RA { get; init; }
        public string CPF { get; init; }

        public CreateStudentCommand(string name, string email, string ra, string cpf)
        {
            Name = name;
            Email = email;
            RA = ra;
            CPF = cpf;

            Contract = new CreateStudentCommandContract(this);
        }
    }
}
