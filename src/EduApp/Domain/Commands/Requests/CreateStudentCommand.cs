using Domain.Commands.Contracts;

namespace Domain.Commands.Requests
{
    public class CreateStudentCommand : Command<CreateStudentCommand>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string RA { get; set; }
        public string CPF { get; set; }

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
