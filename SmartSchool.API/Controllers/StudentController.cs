using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.DbContexts;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Models.Dto;
using SmartSchool.WebAPI.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// 

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentRepository"></param>
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Method to Return all Students
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Get() 
        { 
            var students = await _studentRepository.Get();
            return Ok(students);
        }

        /// <summary>
        /// Method to Return Student By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _studentRepository.GetById(id);
            return Ok(student);
        }

        /// <summary>
        /// Method to Create a Student
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post([FromBody] StudentDto value) => Ok(_studentRepository.Post(value));

        /// <summary>
        /// Method to Update a Student
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        [HttpPut]
        public IActionResult Put([FromBody] StudentDto value) => Ok(_studentRepository.Put(value));

        /// <summary>
        /// Method to Delete a Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(_studentRepository.Delete(id));
    }
}
