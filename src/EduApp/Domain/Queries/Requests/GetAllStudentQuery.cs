using Domain.Commands.Requests;
using Domain.Queries.Contracts;

namespace Domain.Queries.Requests
{
    public class GetAllStudentQuery : Query<GetAllStudentQuery>
    {
        public string Name { get; init; }

        public GetAllStudentQuery(string name)
        {
            Name = name;
        }
    }
}
