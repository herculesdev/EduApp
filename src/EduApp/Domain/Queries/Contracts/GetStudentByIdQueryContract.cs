using Domain.Commands.Requests;
using Domain.Queries.Requests;
using Flunt.Validations;

namespace Domain.Queries.Contracts
{
    internal class GetStudentByIdQueryContract : Contract<GetStudentByIdQuery>
    {
        private GetStudentByIdQuery _query;
        public GetStudentByIdQueryContract(GetStudentByIdQuery query)
        {
            _query = query;

            Requires()
                .IsGreaterOrEqualsThan(_query.Id, 1, "Id", "ID is invalid");
        }
    }
}
