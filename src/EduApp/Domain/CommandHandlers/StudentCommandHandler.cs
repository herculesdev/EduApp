using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.CommandHandlers;

namespace Domain.CommandHandlers
{
    public class StudentCommandHandler : IStudentCommandHandler
    {
        public StudentResponse Handle(CreateStudentCommand command)
        {
            throw new NotImplementedException();
        }

        public StudentResponse Handle(UpdateStudentCommand command)
        {
            throw new NotImplementedException();
        }

        public void Handle(DeleteStudentCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
