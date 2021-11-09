using Domain.Commands.Responses;
using Domain.Queries.Requests;

namespace Domain.Interfaces.QueryHandlers
{
    public interface IStudentQueryHandler : IQueryHandler<GetStudentByIdQuery, StudentResponse>, IQueryHandler<GetAllStudentQuery, IList<StudentResponse>>
    {

    }
}
