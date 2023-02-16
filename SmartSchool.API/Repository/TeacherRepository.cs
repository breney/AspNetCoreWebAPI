using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.DbContexts;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Models.Dto;
using SmartSchool.WebAPI.Repository.IRepository;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        ApplicationDbContext _db;

        private IQueryable<Teacher> _query;

        private IMapper _mapper;

        public TeacherRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _query = _db.Teacher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeacherDto>> Get() 
        {
            var teachers = await _query.Include(t => t.Disciplines)
                .ThenInclude(d => d.DisciplineStudents)
                .ThenInclude(ds => ds.Student).ToArrayAsync();

            return _mapper.Map<IEnumerable<TeacherDto>>(teachers);
        }

        public async Task<TeacherDto> GetById(int id)
        {
            var teacher = await _query.Include(t => t.Disciplines)
                    .ThenInclude(d => d.DisciplineStudents)
                    .ThenInclude(ds => ds.Student).Where(s => s.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<TeacherDto>(teacher);
        }

        public Teacher Post(Teacher teacher)
        {
            _db.Teacher.Add(teacher);
            _db.SaveChanges();

            return teacher;
        }

        public Teacher Put(Teacher teacher)
        {
            bool checkTeacher = _db.Student.FirstOrDefault(x => x.Id == teacher.Id) != null ? true : false;

            if (checkTeacher)
            {
                _db.Teacher.Update(teacher);
                _db.SaveChanges();
            }

            return teacher;
        }

        public bool Delete(int id)
        {
            try
            {
                var teacher = _db.Teacher.FirstOrDefault(x => x.Id == id);

                if (teacher == null) return false;

                _db.Teacher.Remove(teacher);
                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
