using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.DbContexts;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Models.Dto;
using SmartSchool.WebAPI.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_studentRepository.Get());

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_studentRepository.GetById(id));

        [HttpPost]
        public IActionResult Post([FromBody] StudentDto value) => Ok(_studentRepository.Post(value));

        [HttpPut]
        public IActionResult Put([FromBody] StudentDto value) => Ok(_studentRepository.Put(value));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(_studentRepository.Delete(id));
    }
}
