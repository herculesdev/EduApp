using Domain.Commands.Requests;
using Domain.Commands.Responses;

namespace Domain.Interfaces.Handlers.CommandHandlers
{
    public interface IStudentCommandHandler : ICommandHandler<CreateStudentCommand, StudentResponse>, ICommandHandler<UpdateStudentCommand, StudentResponse>, ICommandWithoutHandler<DeleteStudentCommand>, IHandler
    {

    }
}
