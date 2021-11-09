namespace Domain.Models
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RA { get; set; }
        public string CPF { get; set; }

        protected Student()
        {
            Id = 0;
            Name = "";
            Email = "";
            RA = "";
            CPF = "";
        }

        public Student(long id, string name, string email, string ra, string cpf)
        {
            Id = id;
            Name = name;
            Email = email;
            RA = ra;
            CPF = cpf;
        }
    }
}
