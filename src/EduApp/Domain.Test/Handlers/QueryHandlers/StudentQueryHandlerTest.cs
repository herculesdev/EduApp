using Domain.Handlers.QueryHandlers;
using Domain.Interfaces.Handlers.QueryHandlers;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Queries.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Test.Handlers.QueryHandlers
{
    [TestClass]
    public class StudentQueryHandlerTest
    {
        private IList<Student> _students;
        private Mock<IStudentRepository> _studentRepositoryMock;
        private IStudentQueryHandler _queryHandler;

        public StudentQueryHandlerTest()
        {
            _students = new List<Student>();
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _queryHandler = new StudentQueryHandler(_studentRepositoryMock.Object);

            _studentRepositoryMock.Setup(x => x.Get(It.IsAny<long>())).Returns((long id) => _students.FirstOrDefault(s => s.Id == id, new Student(0, "", "", "", "")));
            _studentRepositoryMock.Setup(x => x.GetAll(It.IsAny<string>())).Returns((string name) => _students.Where(s => s.Name.ToUpper().Contains(name.ToUpper())).ToList());

            _students.Add(new Student(1, "Hércules Moreira", "herculesmoreira22@gmail.com", "RA00001", "48511001085"));
            _students.Add(new Student(2, "Jef Bezos Moreira", "joao@hotmail.com", "RA00002", "48511001085"));
            _students.Add(new Student(3, "Mark Zuckerberg", "mark@facebook.com", "RA00003", "58677795057"));
        }

        [TestMethod]
        public void HandleGetStudentById_MustReturnStudent()
        {          
            var student1 = _queryHandler.Handle(new GetStudentByIdQuery(1));
            Assert.AreEqual(student1.RA, "RA00001");

            var student2 = _queryHandler.Handle(new GetStudentByIdQuery(2));
            Assert.AreEqual(student2.RA, "RA00002");
        }

        [TestMethod]
        public void HandleGetAllStudent_MustReturnAllStudent()
        {
            var students = _queryHandler.Handle(new GetAllStudentQuery(""));
            Assert.AreEqual(students.Count, 3);
        }

        [TestMethod]
        public void HandleGetAllStudent_MustReturnAllStudentMatchName()
        {
            var searchedStudents = _queryHandler.Handle(new GetAllStudentQuery("Moreira"));
            Assert.AreEqual(searchedStudents.Count, 2);

            searchedStudents = _queryHandler.Handle(new GetAllStudentQuery("Mark"));
            Assert.AreEqual(searchedStudents.Count, 1);
        }
    }
}
