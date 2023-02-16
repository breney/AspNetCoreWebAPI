using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Models.Dto;

namespace SmartSchool.WebAPI.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDto>> Get();

        Task<StudentDto> GetById(int id);

        StudentDto Post(StudentDto studentDto);

        StudentDto Put(StudentDto studentDto);

        bool Delete(int id);
    }
}
