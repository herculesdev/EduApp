using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.CommandHandlers;
using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Domain.CommandHandlers
{
    public class StudentCommandHandler : CommandHandler, IStudentCommandHandler
    {

        private readonly IStudentRepository _studentRepository;

        public StudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentResponse Handle(CreateStudentCommand command)
        {
            AddNotifications(command);

            if (_studentRepository.CpfExists(command.CPF))
                AddNotification("CPF", "CPF already exists");

            if (_studentRepository.RAExists(command.RA))
                AddNotification("RA", "RA already exists");

            if (IsNotValid)
                return new StudentResponse(0, "", "", "", "");

            var student = _studentRepository.Add(new Student(0, command.Name, command.Email, command.RA, command.CPF));
            return new StudentResponse(student.Id, student.Name, student.Email, student.RA, student.CPF);

        }

        public StudentResponse Handle(UpdateStudentCommand command)
        {
            AddNotifications(command);

            if (!_studentRepository.IdExists(command.Id))
                AddNotification("Id", "Student does not exist");

            if (IsNotValid)
                return new StudentResponse(0, "", "", "", "");

            var student = _studentRepository.Get(command.Id);
            student.Name = command.Name;
            student.Email = command.Email;

            _studentRepository.Update(student);

            return new StudentResponse(student.Id, student.Name, student.Email, student.RA, student.CPF);
        }

        public void Handle(DeleteStudentCommand command)
        {
            AddNotifications(command);

            if (!_studentRepository.IdExists(command.Id))
                AddNotification("Id", "Student does not exist");

            if (IsNotValid)
                return;

            _studentRepository.Delete(command.Id);
        }
    }
}
