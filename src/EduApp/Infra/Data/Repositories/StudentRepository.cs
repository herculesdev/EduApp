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
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
                return;

            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public Student Get(long id)
        {
            return _context.Students.SingleOrDefault(s => s.Id == id) ?? new Student(0, "", "", "", "");
        }

        public IList<Student> GetAll()
        {
            return _context.Students.ToList();
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
