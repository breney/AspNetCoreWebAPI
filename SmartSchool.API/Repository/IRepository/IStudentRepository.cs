using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Models.Dto;

namespace SmartSchool.WebAPI.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task<PageList<Student>> Get();

        Task<Student> GetById(int id);

        StudentDto Post(StudentDto studentDto);

        StudentDto Put(StudentDto studentDto);

        bool Delete(int id);
    }
}
