using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.DbContexts;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/teacher")]  
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var teachers = await _teacherRepository.Get();
            return Ok(teachers);
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var teacher = await _teacherRepository.GetById(id);
            return Ok(teacher);
        }

        [HttpPost]
        public void Post([FromBody] Teacher value) => _teacherRepository.Post(value);

        [HttpPut]
        public void Put([FromBody] Teacher value) => _teacherRepository.Put(value);

        [HttpDelete("{id}")]
        public void Delete(int id) => _teacherRepository.Delete(id);
    }
}
