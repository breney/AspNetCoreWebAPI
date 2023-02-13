using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SmartSchool.WebAPI.DbContexts;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Models.Dto;
using SmartSchool.WebAPI.Repository.IRepository;


namespace SmartSchool.WebAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private ApplicationDbContext _db;

        private IQueryable<Student> _query;

        private IMapper _mapper;

        public StudentRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _query = _db.Student;
            _mapper = mapper;
        }

        public IEnumerable<StudentDto> Get()
        {
            var allStudents = _query.Include(student => student.DisciplineStudent)
                .ThenInclude(disciplineStudent => disciplineStudent.Discipline)
                .ThenInclude(discipline => discipline.Teacher).ToList();

            return _mapper.Map<IEnumerable<StudentDto>>(allStudents);

        }

        public StudentDto GetById(int id) 
        {
            var student = _query.AsNoTracking().Include(student => student.DisciplineStudent)
                .ThenInclude(disciplineStudent => disciplineStudent.Discipline)
                .ThenInclude(discipline => discipline.Teacher).Where(s => s.Id == id).FirstOrDefault();               

            return _mapper.Map<StudentDto>(student);
        } 

        public Student Post(Student student)
        {
            _db.Student.Add(student);
            _db.SaveChanges();

            return student;    
        }

        public Student Put(Student student)
        {
            bool checkStudent =  _db.Student.FirstOrDefault(x => x.Id == student.Id) != null ? true : false;
           
            if (checkStudent)
            {
                _db.Student.Update(student);
                _db.SaveChanges();
            } 
            
            return student;
        }

        public bool Delete(int id)
        {
            try
            {
                var student = _db.Student.FirstOrDefault(x => x.Id == id);

                if (student == null) return false;

                _db.Student.Remove(student);
                _db.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
