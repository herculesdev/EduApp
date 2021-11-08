namespace Domain.Commands.Requests
{
    public class UpdateStudentCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public UpdateStudentCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
