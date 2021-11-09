using Domain.Commands.Requests;
using Domain.Interfaces.Handlers.CommandHandlers;
using Domain.Interfaces.Handlers.QueryHandlers;
using Domain.Queries.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : CustomControllerBase
    {
        private readonly IStudentCommandHandler _commandHandler;
        private readonly IStudentQueryHandler _queryHandler;

        public StudentController(IStudentCommandHandler commandHandler, IStudentQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return GetResponse(_queryHandler.Handle(new GetStudentByIdQuery(id)), _queryHandler);
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return GetResponse(_queryHandler.Handle(new GetAllStudentQuery()), _queryHandler);
        }

        [HttpPost]
        public IActionResult Create(CreateStudentCommand command)
        {
            return GetResponse(_commandHandler.Handle(command), _commandHandler);
        }

        [HttpPut]
        public IActionResult Update(UpdateStudentCommand command)
        {
            return GetResponse(_commandHandler.Handle(command), _commandHandler);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _commandHandler.Handle(new DeleteStudentCommand(id));
            return GetResponse(_commandHandler);
        }
    }
}
