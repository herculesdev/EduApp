using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.CommandHandlers;
using Domain.Interfaces.QueryHandlers;
using Domain.Queries.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentCommandHandler _commandHandler;
        private readonly IStudentQueryHandler _queryHandler;

        public StudentController(IStudentCommandHandler commandHandler, IStudentQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet("{id}")]
        public StudentResponse Get(long id)
        {
            return _queryHandler.Handle(new GetStudentByIdQuery(id));
        }

        [HttpGet()]
        public IList<StudentResponse> Get()
        {
            return _queryHandler.Handle(new GetAllStudentQuery());
        }

        [HttpPost]
        public StudentResponse Create(CreateStudentCommand command)
        {
            return _commandHandler.Handle(command);
        }

        [HttpPut]
        public StudentResponse Update(UpdateStudentCommand command)
        {
            return _commandHandler.Handle(command);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _commandHandler.Handle(new DeleteStudentCommand(id));
        }
    }
}
