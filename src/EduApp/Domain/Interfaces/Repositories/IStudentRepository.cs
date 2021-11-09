using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Student Add(Student student);
        bool CpfExists(string cpf);
        void Delete(long id);
        Student Get(long id);
        IList<Student> GetAll();
        bool IdExists(long id);
        bool RAExists(string ra);
        Student Update(Student student);
    }
}
