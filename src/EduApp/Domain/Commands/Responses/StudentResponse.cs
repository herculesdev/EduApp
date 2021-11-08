namespace Domain.Commands.Responses
{
    public class StudentResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RA { get; set; }
        public string CPF { get; set; }

        public StudentResponse(long id, string name, string email, string ra, string cpf)
        {
            Id = id;
            Name = name;
            Email = email;
            RA = ra;
            CPF = cpf;
        }
    }
}
