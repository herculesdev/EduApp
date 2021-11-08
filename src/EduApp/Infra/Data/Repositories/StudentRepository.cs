using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public Student Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public bool CpfExists(string cpf)
        {
            return _context.Students.Any(s => s.CPF == cpf);
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool IdExists(long id)
        {
            return _context.Students.Any(s => s.Id == id);
        }

        public bool RAExists(string ra)
        {
            return _context.Students.Any(s => s.RA == ra);
        }

        public Student Update(Student student)
        {
            _context.Update(student);
            _context.SaveChanges();
            return student;
        }
    }
}
