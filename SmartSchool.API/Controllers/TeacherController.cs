using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.DbContexts;
using SmartSchool.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        ApplicationDbContext _db;

        public TeacherController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Teacher> Get() => _db.Teacher.ToList();


        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Teacher Get(int id) => _db.Teacher.FirstOrDefault(x => x.Id == id);


        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Teacher value)
        {
            _db.Teacher.Add(value);
            _db.SaveChanges();
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Teacher value)
        {
            _db.Teacher.Update(value);
            _db.SaveChanges();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var teacher = _db.Teacher.FirstOrDefault(x => x.Id == id);

            if (teacher == null) return;

            _db.Teacher.Remove(teacher);
            _db.SaveChanges();
        }
    }
}
