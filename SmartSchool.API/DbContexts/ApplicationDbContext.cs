using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Student { get; set; }

        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Course> Course { get; set; }
        
        public DbSet<CourseStudent> CourseStudent { get; set; }

        public DbSet<Discipline> Discipline { get; set; }

        public DbSet<DisciplineStudent> DisciplineStudent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisciplineStudent>().HasKey(x => new { x.StudentId, x.DisciplineId });

            modelBuilder.Entity<CourseStudent>().HasKey(x => new { x.StudentId, x.CourseId });

            modelBuilder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                    new Teacher() { Id = 1, Name = "Lauro", Surname = "Oliveira", Registration = 1 },
                    new Teacher() { Id = 2, Name = "Roberto", Surname = "Soares", Registration = 2 },
                    new Teacher() { Id = 3, Name ="Ronaldo", Surname = "Cristiano", Registration = 3},
                    new Teacher() { Id = 4, Name = "Rodrigo", Surname = "Carvalho", Registration = 4},
                    new Teacher() { Id = 5, Name = "Alexandre", Surname = "Montana", Registration = 5},
                });

            modelBuilder.Entity<Course>()
                .HasData(new List<Course>(){
                    new Course() { Id = 1, Name = "Tecnologia de Informação"},
                    new Course() { Id = 2, Name = "Sistemas de Informação"},
                    new Course() { Id = 3, Name ="Ciencia de Computação"},
                });

            modelBuilder.Entity<Discipline>()
                .HasData(new List<Discipline>{
                    new Discipline() { Id = 1, Name = "Matemática", TeacherId = 1, CourseId = 1},
                    new Discipline() { Id = 2, Name = "Matemática", TeacherId = 1, CourseId = 3},
                    new Discipline() { Id = 3, Name = "Física", TeacherId = 2, CourseId = 3},
                    new Discipline() { Id = 4, Name = "Português", TeacherId = 3, CourseId = 1},
                    new Discipline() { Id = 5, Name = "Inglês", TeacherId = 4, CourseId = 1},
                    new Discipline() { Id = 6, Name = "Inglês", TeacherId = 4, CourseId = 2},
                    new Discipline() { Id = 7, Name = "Inglês", TeacherId = 2, CourseId = 3},
                    new Discipline() { Id = 8, Name = "Programação", TeacherId = 5, CourseId = 1},
                    new Discipline() { Id = 9, Name = "Programação", TeacherId = 5, CourseId = 2},
                    new Discipline() { Id = 10, Name = "Programação", TeacherId = 3, CourseId = 3},                                                                            
                });

            modelBuilder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student() { Id = 1, Registration = 1 ,Name = "Marta", Surname = "Kent", Telephone = "33225555", DateBirth = DateTime.Parse("28/05/2005")},
                    new Student() { Id = 2, Registration = 2 ,Name = "Paula", Surname = "Isabela", Telephone = "3354288", DateBirth = DateTime.Parse("28/06/2005")},
                    new Student() { Id = 3, Registration = 3 ,Name = "Laura", Surname = "Antonia", Telephone = "55668899", DateBirth = DateTime.Parse("28/07/2005")},
                    new Student() { Id = 4, Registration = 4 ,Name = "Luiza", Surname = "Maria", Telephone = "6565659", DateBirth = DateTime.Parse("28/07/2005")},
                    new Student() { Id = 5, Registration = 5 ,Name = "Lucas", Surname = "Machado", Telephone = "565685415", DateBirth = DateTime.Parse("28/09/2005")},
                    new Student() { Id = 6, Registration = 6 ,Name = "Pedro", Surname = "Alvares", Telephone = "456454545", DateBirth = DateTime.Parse("28/11/2005")},
                    new Student() { Id = 7, Registration = 7 ,Name = "Paulo", Surname = "José", Telephone = "9874512", DateBirth = DateTime.Parse("28/12/2005")},
                });

            modelBuilder.Entity<DisciplineStudent>()
                .HasData(new List<DisciplineStudent>() {
                    new DisciplineStudent() {StudentId = 1, DisciplineId = 2 },
                    new DisciplineStudent() {StudentId = 1, DisciplineId = 4 },
                    new DisciplineStudent() {StudentId = 1, DisciplineId = 5 },
                    new DisciplineStudent() {StudentId = 2, DisciplineId = 1 },
                    new DisciplineStudent() {StudentId = 2, DisciplineId = 2 },
                    new DisciplineStudent() {StudentId = 2, DisciplineId = 5 },
                    new DisciplineStudent() {StudentId = 3, DisciplineId = 1 },
                    new DisciplineStudent() {StudentId = 3, DisciplineId = 2 },
                    new DisciplineStudent() {StudentId = 3, DisciplineId = 3 },
                    new DisciplineStudent() {StudentId = 4, DisciplineId = 1 },
                    new DisciplineStudent() {StudentId = 4, DisciplineId = 4 },
                    new DisciplineStudent() {StudentId = 4, DisciplineId = 5 },
                    new DisciplineStudent() {StudentId = 5, DisciplineId = 4 },
                    new DisciplineStudent() {StudentId = 5, DisciplineId = 5 },
                    new DisciplineStudent() {StudentId = 6, DisciplineId = 1 },
                    new DisciplineStudent() {StudentId = 6, DisciplineId = 2 },
                    new DisciplineStudent() {StudentId = 6, DisciplineId = 3 },
                    new DisciplineStudent() {StudentId = 6, DisciplineId = 4 },
                    new DisciplineStudent() {StudentId = 7, DisciplineId = 1 },
                    new DisciplineStudent() {StudentId = 7, DisciplineId = 2 },
                    new DisciplineStudent() {StudentId = 7, DisciplineId = 3 },
                    new DisciplineStudent() {StudentId = 7, DisciplineId = 4 },
                    new DisciplineStudent() {StudentId = 7, DisciplineId = 5 }
                });
        }
    }
}
