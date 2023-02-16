using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Models.Dto;

namespace SmartSchool.WebAPI.Repository.IRepository
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<TeacherDto>> Get();

        Task<TeacherDto> GetById(int id);

        Teacher Post(Teacher teacher);

        Teacher Put(Teacher teacher);

        bool Delete(int id);
    }
}
