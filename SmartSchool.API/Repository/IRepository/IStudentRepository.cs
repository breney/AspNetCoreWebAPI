using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Repository.IRepository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> Get();

        Student GetById(int id);

        Student Post(Student student);

        Student Put(Student student);

        bool Delete(int id);
    }
}
