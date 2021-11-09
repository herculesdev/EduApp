using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.CommandHandlers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentCommandHandler _commandHandler;

        public StudentController(IStudentCommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
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

        [HttpDelete]
        public void Delete(DeleteStudentCommand command)
        {
            _commandHandler.Handle(command);
        }
    }
}
