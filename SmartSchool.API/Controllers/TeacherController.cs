using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.DbContexts;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public IEnumerable<Teacher> Get() => _teacherRepository.Get();

        [HttpGet("{id}")]
        public Teacher Get(int id) => _teacherRepository.GetById(id);

        [HttpPost]
        public void Post([FromBody] Teacher value) => _teacherRepository.Post(value);

        [HttpPut]
        public void Put([FromBody] Teacher value) => _teacherRepository.Put(value);

        [HttpDelete("{id}")]
        public void Delete(int id) => _teacherRepository.Delete(id);
    }
}
