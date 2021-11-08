namespace Domain.Commands.Requests
{
    public class DeleteStudentCommand
    {
        public long Id { get; set; }

        public DeleteStudentCommand(long id)
        {
            Id = id;
        }
    }
}
