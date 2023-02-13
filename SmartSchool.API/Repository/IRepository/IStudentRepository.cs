using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Models.Dto;

namespace SmartSchool.WebAPI.Repository.IRepository
{
    public interface IStudentRepository
    {
        IEnumerable<StudentDto> Get();

        StudentDto GetById(int id);

        Student Post(Student student);

        Student Put(Student student);

        bool Delete(int id);
    }
}
