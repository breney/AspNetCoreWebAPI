﻿using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.DbContexts;
using SmartSchool.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get() => _db.Student.ToList();


        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id) => _db.Student.FirstOrDefault(x => x.Id == id);


        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student value)
        {
            _db.Student.Add(value);
            _db.SaveChanges();
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student value)
        {
            _db.Student.Update(value);
            _db.SaveChanges();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _db.Student.FirstOrDefault(x => x.Id == id);

            if (student == null) return;

            _db.Student.Remove(student);
            _db.SaveChanges();
        }
    }
}
