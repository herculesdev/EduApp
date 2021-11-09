using Domain.Commands.Responses;
using Domain.Queries.Requests;

namespace Domain.Interfaces.Handlers.QueryHandlers
{
    public interface IStudentQueryHandler : IQueryHandler<GetStudentByIdQuery, StudentResponse>, IQueryHandler<GetAllStudentQuery, IList<StudentResponse>>, IHandler
    {

    }
}
