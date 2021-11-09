using Domain.Commands.Requests;
using Domain.Queries.Contracts;

namespace Domain.Queries.Requests
{
    public class GetStudentByIdQuery : Query<GetStudentByIdQuery>
    {
        public long Id { get; init; }

        public GetStudentByIdQuery(long id)
        {
            Id = id;

            Contract = new GetStudentByIdQueryContract(this);
        }
    }
}
