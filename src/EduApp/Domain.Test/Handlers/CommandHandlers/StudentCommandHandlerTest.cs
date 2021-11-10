using Domain.Commands.Requests;
using Domain.Handlers.CommandHandlers;
using Domain.Interfaces.Handlers.CommandHandlers;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Test.Handlers.CommandHandlers
{
    [TestClass]
    public class StudentCommandHandlerTest
    {
        private IList<Student> _students;
        private long _studentNextId = 1;
        private Mock<IStudentRepository> _studentRepositoryMock;
        private IStudentCommandHandler _commandHandler;

        public StudentCommandHandlerTest()
        {
            _students = new List<Student>();
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _commandHandler = new StudentCommandHandler(_studentRepositoryMock.Object);

            _studentRepositoryMock.Setup(x => x.Get(It.IsAny<long>())).Returns((long id) => _students.FirstOrDefault(s => s.Id == id, new Student(0, "", "", "", "")));
            _studentRepositoryMock.Setup(r => r.Add(It.IsAny<Student>())).Callback((Student student) =>
            {
                student.Id = _studentNextId;
                _students.Add(student);
                _studentNextId++;
            }).Returns(_students.LastOrDefault(new Student(0, "", "", "", "")));

            _studentRepositoryMock.Setup(r => r.Update(It.IsAny<Student>())).Callback((Student student) =>
            {
                var studentUpdate = _students.FirstOrDefault(s => s.Id == student.Id, new Student(0, "", "", "", ""));
                student.Id = studentUpdate.Id;
                _students.Remove(studentUpdate);
                _students.Add(student);
            }).Returns(_students.LastOrDefault(new Student(0, "", "", "", "")));

            _studentRepositoryMock.Setup(r => r.IdExists(It.IsAny<long>())).Returns((long id) => _students.Any(s => s.Id == id));
            _studentRepositoryMock.Setup(r => r.CpfExists(It.IsAny<string>())).Returns((string cpf) => _students.Any(s => s.CPF == cpf));
            _studentRepositoryMock.Setup(r => r.RAExists(It.IsAny<string>())).Returns((string ra) => _students.Any(s => s.RA == ra));

            _students.Add(new Student(1, "Hércules Moreira", "herculesmoreira22@gmail.com", "RA00001", "48511001085"));
            _students.Add(new Student(2, "Jef Bezos Moreira", "joao@hotmail.com", "RA00002", "48511001085"));
            _students.Add(new Student(3, "Mark Zuckerberg", "mark@facebook.com", "RA00003", "58677795057"));
        }

        [TestMethod]
        public void HandleCreateStudentCommand_MustAddStudent()
        {
            _students.Clear();
            _commandHandler.Handle(new CreateStudentCommand("Hércules Moreira", "herculesmoreira@gmail.com", "RA00001", "48511001085"));
            Assert.IsTrue(_students.Any(s => s.RA == "RA00001"));

        }

        [TestMethod]
        public void HandleUpdateStudentCommand_MustAddStudent()
        {
            _students.Clear();
            _students.Add(new Student(_studentNextId++, "Hércules Moreira", "herculesmoreira@gmail.com", "RA00001", "48511001085"));
            _commandHandler.Handle(new UpdateStudentCommand(1, "Hércules Moreira Assis", "herculesmoreira@gmail.com"));
            Assert.IsTrue(_students.Any(s => s.Name == "Hércules Moreira Assis"));

        }

        [TestMethod]
        public void HandleUpdateStudentCommand_MustNotifyExistingRA()
        {
            _students.Clear();
            _students.Add(new Student(_studentNextId++, "George Soros", "george@soros.us", "RA00001", "71812079036"));
            _commandHandler.Handle(new CreateStudentCommand("Hércules Moreira", "herculesmoreira@gmail.com", "RA00001", "48511001085"));
            Assert.IsFalse(_commandHandler.IsValid);
            Assert.AreEqual(_commandHandler.Notifications.Count, 1);
            Assert.AreEqual(_commandHandler.Notifications.FirstOrDefault()?.Message, "RA already exists");
        }

        [TestMethod]
        public void HandleUpdateStudentCommand_MustNotifyExistingCPF()
        {
            _students.Clear();
            _students.Add(new Student(_studentNextId++, "George Soros", "george@soros.us", "RA00001", "71812079036"));
            _commandHandler.Handle(new CreateStudentCommand("Hércules Moreira", "herculesmoreira@gmail.com", "RA00002", "71812079036"));
            Assert.IsFalse(_commandHandler.IsValid);
            Assert.AreEqual(_commandHandler.Notifications.Count, 1);
            Assert.AreEqual(_commandHandler.Notifications.FirstOrDefault()?.Message, "CPF already exists");
        }
    }
}
