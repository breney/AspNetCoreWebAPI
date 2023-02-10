using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Repository.IRepository
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> Get();

        Teacher GetById(int id);

        Teacher Post(Teacher teacher);

        Teacher Put(Teacher teacher);

        bool Delete(int id);
    }
}
