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
            _query = db.Student;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> Get()
        {
            var allStudents = await _query.Include(student => student.DisciplineStudent)
                .ThenInclude(disciplineStudent => disciplineStudent.Discipline)
                .ThenInclude(discipline => discipline.Teacher).ToArrayAsync();

            return _mapper.Map<IEnumerable<StudentDto>>(allStudents);

        }

        public async Task<StudentDto> GetById(int id) 
        {
            var student = await _query.AsNoTracking().Include(student => student.DisciplineStudent)
                .ThenInclude(disciplineStudent => disciplineStudent.Discipline)
                .ThenInclude(discipline => discipline.Teacher).Where(s => s.Id == id).FirstOrDefaultAsync();               

            return _mapper.Map<StudentDto>(student);
        } 

        public StudentDto Post(StudentDto studentDto)
        {
            Student student = _mapper.Map<Student>(studentDto);

            _db.Student.Add(student);
            _db.SaveChanges();

            return _mapper.Map<StudentDto>(student);    
        }

        public StudentDto Put(StudentDto studentDto)
        {
            Student student = _mapper.Map<Student>(studentDto);

            bool checkStudent = GetById(studentDto.Id) != null ? true : false;
           
            if (checkStudent)
            {
                _db.Student.Update(student);
                _db.SaveChanges();
            }

            return _mapper.Map<StudentDto>(student);
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
