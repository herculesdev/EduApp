﻿using Domain.Commands.Responses;
using Domain.Interfaces.QueryHandlers;
using Domain.Interfaces.Repositories;
using Domain.Queries.Requests;

namespace Domain.QueryHandlers
{
    public class StudentQueryHandler : QueryHandler, IStudentQueryHandler
    {
        private readonly IStudentRepository _studentRepository;

        public StudentQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentResponse Handle(GetStudentByIdQuery query)
        {
            AddNotifications(query);

            var student = _studentRepository.Get(query.Id);

            if (student == null || student.Id <= 0)
                AddNotification("Id", "Student does not exist");

            if (IsNotValid)
                return new StudentResponse(0, "", "", "", "");

            return new StudentResponse(student.Id, student.Name, student.Email, student.RA, student.CPF);
        }

        public IList<StudentResponse> Handle(GetAllStudentQuery query)
        {
            AddNotifications(query);

            if (IsNotValid)
                return new List<StudentResponse>();

            return _studentRepository.GetAll().Select(s => new StudentResponse(s.Id, s.Name, s.Email, s.RA, s.CPF)).ToList();
        }
    }
}
