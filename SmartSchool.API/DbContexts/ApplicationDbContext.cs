using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Student { get; set; }

        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Discipline> Discipline { get; set; }

        public DbSet<DisciplineStudent> DisciplineStudent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisciplineStudent>().HasKey(x => new { x.StudentId, x.DisciplineId });

            modelBuilder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                    new Teacher() { Id = 1, Name = "Lauro" },
                    new Teacher() { Id = 2, Name = "Roberto" },
                    new Teacher() { Id = 3, Name ="Ronaldo"},
                    new Teacher() { Id = 4, Name = "Rodrigo"},
                    new Teacher() { Id = 5, Name = "Alexandre"},
                });

            modelBuilder.Entity<Discipline>()
                .HasData(new List<Discipline>{
                    new Discipline() { Id = 1, Name = "Matemática", TeacherId = 1},
                    new Discipline() { Id = 2, Name = "Física", TeacherId = 2},
                    new Discipline() { Id = 3, Name = "Português", TeacherId = 3},
                    new Discipline() { Id = 4, Name = "Inglês", TeacherId = 4},
                    new Discipline() { Id = 5, Name = "Programação", TeacherId = 5},
                });

            modelBuilder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student() { Id = 1, Name = "Marta", Surname = "Kent", Telephone = "33225555"},
                    new Student() { Id = 2, Name = "Paula", Surname = "Isabela", Telephone = "3354288"},
                    new Student() { Id = 3, Name = "Laura", Surname = "Antonia", Telephone = "55668899"},
                    new Student() { Id = 4, Name = "Luiza", Surname = "Maria", Telephone = "6565659"},
                    new Student() { Id = 5, Name = "Lucas", Surname = "Machado", Telephone = "565685415"},
                    new Student() { Id = 6, Name = "Pedro", Surname = "Alvares", Telephone = "456454545"},
                    new Student() { Id = 7, Name = "Paulo", Surname = "José", Telephone = "9874512"},
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
